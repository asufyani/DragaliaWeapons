﻿using AutoMapper;
using DragaliaApi.Data;
using DragaliaApi.Models;
using DragaliaApi.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragaliaApi.Controllers.Private
{
    [Authorize]
    [Route("api/AccountFacilities")]
    [ApiController]
    public class AccountFacilitiesController : AuthController
    {
        private readonly DragaliaContext _context;
        private readonly IMapper _mapper;

        public AccountFacilitiesController(DragaliaContext context, IMapper mapper, IConfiguration configuration) : base(context, mapper, configuration)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AccountFacilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountFacilityDTO>>> GetAccountFacilities()
        {
            var accountID = await GetAccountID();
            try
            {
                return await _context.AccountFacilities.Where(af => af.AccountId == accountID)
                                                       .Include(af => af.Facility)
                                                       .ThenInclude(f => f.Category)
                                                       .Where(af => af.Facility.Category.Category1 != "Decoration")
                                                       .OrderBy(af => af.Facility.Category.SortPath)
                                                       .ThenBy(af => af.FacilityId)
                                                       .ThenBy(af => af.CopyNumber)
                                                       .Select(af => _mapper.Map<AccountFacilityDTO>(af))
                                                       .ToListAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: 500);
            }
        }

        // GET: api/AccountFacilities/5
        [HttpGet("{facilityID}/{copyNumber}")]
        public async Task<ActionResult<AccountFacilityDTO>> GetAccountFacility(int facilityID, int copyNumber)
        {
            var accountID = await GetAccountID();
            try
            {
                var rval = await _context.AccountFacilities.Where(af => af.AccountId == accountID && af.FacilityId == facilityID && af.CopyNumber == copyNumber)
                                                           .Include(af => af.Facility)
                                                           .ThenInclude(f => f.Category)
                                                           .Where(af => af.Facility.Category.Category1 != "Decoration")
                                                           .Select(af => _mapper.Map<AccountFacilityDTO>(af))
                                                           .FirstAsync();

                if (rval == null)
                    return NotFound();
                return rval;
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: 500);
            }
        }

        // PUT: api/AccountFacilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{facilityID}/{copyNumber}")]
        public async Task<IActionResult> PutAccountFacility(int facilityID, int copyNumber, AccountFacilityDTO accountFacilityDTO)
        {
            var accountID = await GetAccountID();
            var accountFacility = await _context.AccountFacilities.FindAsync(accountID, facilityID, copyNumber);

            accountFacility.CurrentLevel = accountFacilityDTO.CurrentLevel;
            accountFacility.WantedLevel = accountFacilityDTO.WantedLevel;

            _context.Entry(accountFacility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AccountFacilityExists(accountID, facilityID, copyNumber))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/AccountFacilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountFacilityDTO>> PostAccountFacility(AccountFacilityDTO accountFacilityDTO)
        {
            var accountID = await GetAccountID();
            var accountFacility = _mapper.Map<AccountFacility>(accountFacilityDTO);
            accountFacility.AccountId = accountID;

            _context.AccountFacilities.Add(accountFacility);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) when (AccountFacilityExists(accountID, accountFacility.FacilityId, accountFacility.CopyNumber))
            {
                return Conflict();
            }

            return CreatedAtAction(
                nameof(GetAccountFacility),
                new { accountID = accountFacility.AccountId, facilityID = accountFacility.FacilityId, copyNumber = accountFacility.CopyNumber },
                _mapper.Map<AccountFacilityDTO>(accountFacility));
        }

        // DELETE: api/AccountFacilities/5
        [HttpDelete("{facilityID}/{copyNumber}")]
        public async Task<IActionResult> DeleteAccountFacility(int facilityID, int copyNumber)
        {
            var accountID = await GetAccountID();
            var accountFacility = await _context.AccountFacilities.FindAsync(accountID, facilityID, copyNumber);
            if (accountFacility == null)
            {
                return NotFound();
            }

            _context.AccountFacilities.Remove(accountFacility);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("costs")]
        public async Task<ActionResult<IEnumerable<MaterialCost>>> GetFacilityCosts(int? facilityID, int? copyNumber)
        {
            try
            {
                var accountID = await GetAccountID();

                return await _context.AccountFacilities
                    .Where(af => af.AccountId == accountID
                                 && (facilityID == null || af.FacilityId == facilityID)
                                 && (copyNumber == null || af.CopyNumber == copyNumber))
                    .Include(af => af.Facility)
                    .ThenInclude(f => f.FacilityUpgrades)
                    .ThenInclude(fu => fu.Material)
                    .Include(af => af.Facility)
                    .ThenInclude(f => f.Category)
                    .SelectMany(af => af.Facility.FacilityUpgrades,
                        (accountFacility, facilityUpgrade) => new { accountFacility, facilityUpgrade })
                    .Where(x => x.accountFacility.CurrentLevel < x.facilityUpgrade.FacilityLevel
                        && x.facilityUpgrade.FacilityLevel <= x.accountFacility.WantedLevel)
                    .OrderBy(x => x.accountFacility.Facility.Category.SortPath)
                    .ThenBy(x => x.accountFacility.FacilityId)
                    .ThenBy(x => x.accountFacility.CopyNumber)
                    .ThenBy(x => x.facilityUpgrade.FacilityLevel)
                    .ThenBy(x => x.facilityUpgrade.Material.SortPath)
                    .Select(x => new MaterialCost
                    {
                        Product = $"{x.accountFacility.Facility.Facility1} {(x.accountFacility.Facility.Limit > 1 ? $"#{x.accountFacility.CopyNumber} " : "")}Level {x.facilityUpgrade.FacilityLevel}",
                        Material = _mapper.Map<MaterialDTO>(x.facilityUpgrade.Material),
                        Quantity = x.facilityUpgrade.Quantity
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.ToString(), statusCode: 500);
            }
        }

        private bool AccountFacilityExists(int accountID, int facilityID, int copyNumber) => _context.AccountFacilities.Any(e => e.AccountId == accountID
                                                                                                                                 && e.FacilityId == facilityID
                                                                                                                                 && e.CopyNumber == copyNumber);
    }
}

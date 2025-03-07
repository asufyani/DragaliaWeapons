﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

#nullable disable

namespace DragaliaApi.Models
{
    public partial class Material
    {
        public Material()
        {
            AccountInventories = new HashSet<AccountInventory>();
            DragonUnbinds = new HashSet<DragonUnbind>();
            FacilityUpgrades = new HashSet<FacilityUpgrade>();
            ManaCircles = new HashSet<ManaCircle>();
            MaterialQuests = new HashSet<MaterialQuest>();
            PassiveCraftings = new HashSet<PassiveCrafting>();
            WeaponCraftings = new HashSet<WeaponCrafting>();
            WeaponLevels = new HashSet<WeaponLevel>();
            WeaponUpgrades = new HashSet<WeaponUpgrade>();
            WyrmprintLevels = new HashSet<WyrmprintLevel>();
            WyrmprintUpgrades = new HashSet<WyrmprintUpgrade>();
        }

        public string MaterialId { get; set; }
        public string Material1 { get; set; }
        public int? CategoryId { get; set; }
        public bool? Active { get; set; }
        public HierarchyId SortPath { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<AccountInventory> AccountInventories { get; set; }
        public virtual ICollection<DragonUnbind> DragonUnbinds { get; set; }
        public virtual ICollection<FacilityUpgrade> FacilityUpgrades { get; set; }
        public virtual ICollection<ManaCircle> ManaCircles { get; set; }
        public virtual ICollection<MaterialQuest> MaterialQuests { get; set; }
        public virtual ICollection<PassiveCrafting> PassiveCraftings { get; set; }
        public virtual ICollection<WeaponCrafting> WeaponCraftings { get; set; }
        public virtual ICollection<WeaponLevel> WeaponLevels { get; set; }
        public virtual ICollection<WeaponUpgrade> WeaponUpgrades { get; set; }
        public virtual ICollection<WyrmprintLevel> WyrmprintLevels { get; set; }
        public virtual ICollection<WyrmprintUpgrade> WyrmprintUpgrades { get; set; }
    }
}
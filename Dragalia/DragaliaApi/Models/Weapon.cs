﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace DragaliaApi.Models
{
    public partial class Weapon
    {
        public Weapon()
        {
            AccountWeapons = new HashSet<AccountWeapon>();
            WeaponCraftings = new HashSet<WeaponCrafting>();
            WeaponUpgrades = new HashSet<WeaponUpgrade>();
        }

        public int WeaponId { get; set; }
        public string Weapon1 { get; set; }
        public int WeaponSeriesId { get; set; }
        public int WeaponTypeId { get; set; }
        public int Rarity { get; set; }
        public int ElementId { get; set; }
        public bool? Active { get; set; }

        public virtual Element Element { get; set; }
        public virtual WeaponSeries WeaponSeries { get; set; }
        public virtual WeaponType WeaponType { get; set; }
        public virtual ICollection<AccountWeapon> AccountWeapons { get; set; }
        public virtual ICollection<WeaponCrafting> WeaponCraftings { get; set; }
        public virtual ICollection<WeaponUpgrade> WeaponUpgrades { get; set; }
    }
}
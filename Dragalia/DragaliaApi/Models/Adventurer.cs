﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace DragaliaApi.Models
{
    public partial class Adventurer
    {
        public Adventurer()
        {
            AccountAdventurers = new HashSet<AccountAdventurer>();
            ManaCircles = new HashSet<ManaCircle>();
        }

        public int AdventurerId { get; set; }
        public string Adventurer1 { get; set; }
        public int Rarity { get; set; }
        public int ElementId { get; set; }
        public int WeaponTypeId { get; set; }
        public int Mclimit { get; set; }
        public bool? Active { get; set; }

        public virtual Element Element { get; set; }
        public virtual WeaponType WeaponType { get; set; }
        public virtual ICollection<AccountAdventurer> AccountAdventurers { get; set; }
        public virtual ICollection<ManaCircle> ManaCircles { get; set; }
    }
}
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace DragaliaApi.Models
{
    public partial class Quest
    {
        public Quest()
        {
            MaterialQuests = new HashSet<MaterialQuest>();
        }

        public int QuestId { get; set; }
        public string Quest1 { get; set; }

        public virtual ICollection<MaterialQuest> MaterialQuests { get; set; }
    }
}
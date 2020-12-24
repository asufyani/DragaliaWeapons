﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DragaliaApi.Models;

#nullable disable

namespace DragaliaApi.Data
{
    public partial class DragaliaContext : DbContext
    {
        public DragaliaContext()
        {
        }

        public DragaliaContext(DbContextOptions<DragaliaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ability> Abilities { get; set; }
        public virtual DbSet<AbilityGroup> AbilityGroups { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountFacility> AccountFacilities { get; set; }
        public virtual DbSet<AccountInventory> AccountInventories { get; set; }
        public virtual DbSet<AccountPassive> AccountPassives { get; set; }
        public virtual DbSet<AccountWeapon> AccountWeapons { get; set; }
        public virtual DbSet<AccountWyrmprint> AccountWyrmprints { get; set; }
        public virtual DbSet<Affinity> Affinities { get; set; }
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<FacilityUpgrade> FacilityUpgrades { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Passive> Passives { get; set; }
        public virtual DbSet<PassiveCrafting> PassiveCraftings { get; set; }
        public virtual DbSet<UpgradeType> UpgradeTypes { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<WeaponCrafting> WeaponCraftings { get; set; }
        public virtual DbSet<WeaponLevel> WeaponLevels { get; set; }
        public virtual DbSet<WeaponLevelLimit> WeaponLevelLimits { get; set; }
        public virtual DbSet<WeaponSeries> WeaponSeries { get; set; }
        public virtual DbSet<WeaponType> WeaponTypes { get; set; }
        public virtual DbSet<WeaponUnbindLimit> WeaponUnbindLimits { get; set; }
        public virtual DbSet<WeaponUpgrade> WeaponUpgrades { get; set; }
        public virtual DbSet<Wyrmprint> Wyrmprints { get; set; }
        public virtual DbSet<WyrmprintAbility> WyrmprintAbilities { get; set; }
        public virtual DbSet<WyrmprintLevel> WyrmprintLevels { get; set; }
        public virtual DbSet<WyrmprintLevelLimit> WyrmprintLevelLimits { get; set; }
        public virtual DbSet<WyrmprintUpgrade> WyrmprintUpgrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>(entity =>
            {
                entity.ToTable("Ability", "core");

                entity.Property(e => e.AbilityId)
                    .ValueGeneratedNever()
                    .HasColumnName("AbilityID");

                entity.Property(e => e.Ability1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Ability");

                entity.Property(e => e.AbilityGroupId).HasColumnName("AbilityGroupID");

                entity.Property(e => e.GenericName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AbilityGroup)
                    .WithMany(p => p.Abilities)
                    .HasForeignKey(d => d.AbilityGroupId)
                    .HasConstraintName("FK_Ability_AbilityGroup");
            });

            modelBuilder.Entity<AbilityGroup>(entity =>
            {
                entity.ToTable("AbilityGroup", "core");

                entity.Property(e => e.AbilityGroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("AbilityGroupID");

                entity.Property(e => e.AbilityGroup1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("AbilityGroup");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountEmail)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<AccountFacility>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.FacilityId, e.CopyNumber });

                entity.ToTable("AccountFacility");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountFacilities)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountFacility_Account");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.AccountFacilities)
                    .HasForeignKey(d => d.FacilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountFacility_Facility");
            });

            modelBuilder.Entity<AccountInventory>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.MaterialId });

                entity.ToTable("AccountInventory");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountInventories)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountInventory_Account");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.AccountInventories)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountInventory_Material");
            });

            modelBuilder.Entity<AccountPassive>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.PassiveId });

                entity.ToTable("AccountPassive");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.PassiveId).HasColumnName("PassiveID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountPassives)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountPassive_Account");

                entity.HasOne(d => d.Passive)
                    .WithMany(p => p.AccountPassives)
                    .HasForeignKey(d => d.PassiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountPassive_Passive");
            });

            modelBuilder.Entity<AccountWeapon>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.WeaponId });

                entity.ToTable("AccountWeapon");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.WeaponId).HasColumnName("WeaponID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountWeapons)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountWeapon_Account");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.AccountWeapons)
                    .HasForeignKey(d => d.WeaponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountWeapon_CoreWeapon");
            });

            modelBuilder.Entity<AccountWyrmprint>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.WyrmprintId });

                entity.ToTable("AccountWyrmprint");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.WyrmprintId).HasColumnName("WyrmprintID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountWyrmprints)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountWyrmprint_Account");

                entity.HasOne(d => d.Wyrmprint)
                    .WithMany(p => p.AccountWyrmprints)
                    .HasForeignKey(d => d.WyrmprintId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountWyrmprint_Wyrmprint");
            });

            modelBuilder.Entity<Affinity>(entity =>
            {
                entity.ToTable("Affinity", "core");

                entity.Property(e => e.AffinityId)
                    .ValueGeneratedNever()
                    .HasColumnName("AffinityID");

                entity.Property(e => e.Affinity1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Affinity");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.ToTable("Element", "core");

                entity.Property(e => e.ElementId)
                    .ValueGeneratedNever()
                    .HasColumnName("ElementID");

                entity.Property(e => e.Element1)
                    .HasMaxLength(50)
                    .HasColumnName("Element");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.ToTable("Facility", "core");

                entity.Property(e => e.FacilityId)
                    .ValueGeneratedNever()
                    .HasColumnName("FacilityID");

                entity.Property(e => e.Facility1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Facility");
            });

            modelBuilder.Entity<FacilityUpgrade>(entity =>
            {
                entity.HasKey(e => new { e.FacilityId, e.MaterialId, e.FacilityLevel });

                entity.ToTable("FacilityUpgrade", "core");

                entity.Property(e => e.FacilityId).HasColumnName("FacilityID");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.FacilityUpgrades)
                    .HasForeignKey(d => d.FacilityId)
                    .HasConstraintName("FK_FacilityUpgrade_Facility");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.FacilityUpgrades)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_FacilityUpgrade_Material");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material", "core");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.Property(e => e.Material1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Material");
            });

            modelBuilder.Entity<Passive>(entity =>
            {
                entity.ToTable("Passive", "core");

                entity.Property(e => e.PassiveId)
                    .ValueGeneratedNever()
                    .HasColumnName("PassiveID");

                entity.Property(e => e.AbilityId).HasColumnName("AbilityID");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.WeaponTypeId).HasColumnName("WeaponTypeID");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.Passives)
                    .HasForeignKey(d => d.AbilityId)
                    .HasConstraintName("FK_Passive_Ability");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Passives)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK_Passive_Element");

                entity.HasOne(d => d.WeaponType)
                    .WithMany(p => p.Passives)
                    .HasForeignKey(d => d.WeaponTypeId)
                    .HasConstraintName("FK_Passive_WeaponType");
            });

            modelBuilder.Entity<PassiveCrafting>(entity =>
            {
                entity.HasKey(e => new { e.PassiveId, e.MaterialId });

                entity.ToTable("PassiveCrafting", "core");

                entity.Property(e => e.PassiveId).HasColumnName("PassiveID");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.PassiveCraftings)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_PassiveCrafting_Material");

                entity.HasOne(d => d.Passive)
                    .WithMany(p => p.PassiveCraftings)
                    .HasForeignKey(d => d.PassiveId)
                    .HasConstraintName("FK_PassiveCrafting_Passive");
            });

            modelBuilder.Entity<UpgradeType>(entity =>
            {
                entity.ToTable("UpgradeType", "core");

                entity.Property(e => e.UpgradeTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("UpgradeTypeID");

                entity.Property(e => e.UpgradeType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("UpgradeType");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.ToTable("Weapon", "core");

                entity.Property(e => e.WeaponId)
                    .ValueGeneratedNever()
                    .HasColumnName("WeaponID");

                entity.Property(e => e.ElementId).HasColumnName("ElementID");

                entity.Property(e => e.Weapon1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Weapon");

                entity.Property(e => e.WeaponSeriesId).HasColumnName("WeaponSeriesID");

                entity.Property(e => e.WeaponTypeId).HasColumnName("WeaponTypeID");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.ElementId)
                    .HasConstraintName("FK_Weapon_Element");

                entity.HasOne(d => d.WeaponSeries)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponSeriesId)
                    .HasConstraintName("FK_Weapon_WeaponSeries");

                entity.HasOne(d => d.WeaponType)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponTypeId)
                    .HasConstraintName("FK_Weapon_WeaponType");
            });

            modelBuilder.Entity<WeaponCrafting>(entity =>
            {
                entity.HasKey(e => new { e.WeaponId, e.MaterialId });

                entity.ToTable("WeaponCrafting", "core");

                entity.Property(e => e.WeaponId).HasColumnName("WeaponID");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.WeaponCraftings)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_WeaponCrafting_Material");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.WeaponCraftings)
                    .HasForeignKey(d => d.WeaponId)
                    .HasConstraintName("FK_WeaponCrafting_Weapon");
            });

            modelBuilder.Entity<WeaponLevel>(entity =>
            {
                entity.HasKey(e => new { e.Rarity, e.WeaponLevel1, e.MaterialId });

                entity.ToTable("WeaponLevel", "core");

                entity.Property(e => e.WeaponLevel1).HasColumnName("WeaponLevel");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.WeaponLevels)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_WeaponLevel_Material");
            });

            modelBuilder.Entity<WeaponLevelLimit>(entity =>
            {
                entity.HasKey(e => new { e.WeaponRarity, e.UnbindLevel });

                entity.ToTable("WeaponLevelLimit", "core");
            });

            modelBuilder.Entity<WeaponSeries>(entity =>
            {
                entity.ToTable("WeaponSeries", "core");

                entity.Property(e => e.WeaponSeriesId)
                    .ValueGeneratedNever()
                    .HasColumnName("WeaponSeriesID");

                entity.Property(e => e.WeaponSeries1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("WeaponSeries");
            });

            modelBuilder.Entity<WeaponType>(entity =>
            {
                entity.ToTable("WeaponType", "core");

                entity.Property(e => e.WeaponTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("WeaponTypeID");

                entity.Property(e => e.WeaponType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("WeaponType");
            });

            modelBuilder.Entity<WeaponUnbindLimit>(entity =>
            {
                entity.HasKey(e => new { e.WeaponRarity, e.RefinementLevel });

                entity.ToTable("WeaponUnbindLimit", "core");
            });

            modelBuilder.Entity<WeaponUpgrade>(entity =>
            {
                entity.HasKey(e => new { e.WeaponId, e.UpgradeTypeId, e.Step, e.MaterialId });

                entity.ToTable("WeaponUpgrade", "core");

                entity.Property(e => e.WeaponId).HasColumnName("WeaponID");

                entity.Property(e => e.UpgradeTypeId).HasColumnName("UpgradeTypeID");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.WeaponUpgrades)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_WeaponUpgrade_Material");

                entity.HasOne(d => d.UpgradeType)
                    .WithMany(p => p.WeaponUpgrades)
                    .HasForeignKey(d => d.UpgradeTypeId)
                    .HasConstraintName("FK_WeaponUpgrade_UpgradeType");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.WeaponUpgrades)
                    .HasForeignKey(d => d.WeaponId)
                    .HasConstraintName("FK_WeaponUpgrade_Weapon");
            });

            modelBuilder.Entity<Wyrmprint>(entity =>
            {
                entity.ToTable("Wyrmprint", "core");

                entity.Property(e => e.WyrmprintId)
                    .ValueGeneratedNever()
                    .HasColumnName("WyrmprintID");

                entity.Property(e => e.AffinityId).HasColumnName("AffinityID");

                entity.Property(e => e.Wyrmprint1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Wyrmprint");

                entity.HasOne(d => d.Affinity)
                    .WithMany(p => p.Wyrmprints)
                    .HasForeignKey(d => d.AffinityId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Wyrmprint_Affinity");
            });

            modelBuilder.Entity<WyrmprintAbility>(entity =>
            {
                entity.HasKey(e => new { e.WyrmprintId, e.AbilityLevel, e.AbilityId, e.AbilitySlot });

                entity.ToTable("WyrmprintAbility", "core");

                entity.Property(e => e.WyrmprintId).HasColumnName("WyrmprintID");

                entity.Property(e => e.AbilityId).HasColumnName("AbilityID");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.WyrmprintAbilities)
                    .HasForeignKey(d => d.AbilityId)
                    .HasConstraintName("FK_WyrmprintAbility_Ability");

                entity.HasOne(d => d.Wyrmprint)
                    .WithMany(p => p.WyrmprintAbilities)
                    .HasForeignKey(d => d.WyrmprintId)
                    .HasConstraintName("FK_WyrmprintAbility_Wyrmprint");
            });

            modelBuilder.Entity<WyrmprintLevel>(entity =>
            {
                entity.HasKey(e => new { e.Rarity, e.WyrmprintLevel1, e.MaterialId });

                entity.ToTable("WyrmprintLevel", "core");

                entity.Property(e => e.WyrmprintLevel1).HasColumnName("WyrmprintLevel");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.WyrmprintLevels)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_WyrmprintLevel_Material");
            });

            modelBuilder.Entity<WyrmprintLevelLimit>(entity =>
            {
                entity.HasKey(e => new { e.WyrmprintRarity, e.UnbindLevel });

                entity.ToTable("WyrmprintLevelLimit", "core");
            });

            modelBuilder.Entity<WyrmprintUpgrade>(entity =>
            {
                entity.HasKey(e => new { e.WyrmprintId, e.UpgradeTypeId, e.Step, e.MaterialId });

                entity.ToTable("WyrmprintUpgrade", "core");

                entity.Property(e => e.WyrmprintId).HasColumnName("WyrmprintID");

                entity.Property(e => e.UpgradeTypeId).HasColumnName("UpgradeTypeID");

                entity.Property(e => e.MaterialId)
                    .HasMaxLength(50)
                    .HasColumnName("MaterialID");

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.WyrmprintUpgrades)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_WyrmprintUpgrade_Material");

                entity.HasOne(d => d.UpgradeType)
                    .WithMany(p => p.WyrmprintUpgrades)
                    .HasForeignKey(d => d.UpgradeTypeId)
                    .HasConstraintName("FK_WyrmprintUpgrade_UpgradeType");

                entity.HasOne(d => d.Wyrmprint)
                    .WithMany(p => p.WyrmprintUpgrades)
                    .HasForeignKey(d => d.WyrmprintId)
                    .HasConstraintName("FK_WyrmprintUpgrade_Wyrmprint");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
﻿CREATE TABLE [dbo].[AccountWeapon] (
	[AccountID] INT NOT NULL
	,[WeaponID] INT NOT NULL
	,[Copies] INT NOT NULL CONSTRAINT [DF_Weapon_Copies] DEFAULT(0)
	,[CopiesWanted] INT NOT NULL CONSTRAINT [DF_Weapon_CopiesWanted] DEFAULT(0)
	,[WeaponLevel] INT NOT NULL CONSTRAINT [DF_Weapon_WeaponLevel] DEFAULT(0)
	,[WeaponLevelWanted] INT NOT NULL CONSTRAINT [DF_Weapon_WeaponLevelWanted] DEFAULT(0)
	,[Unbind] INT NOT NULL CONSTRAINT [DF_Weapon_Unbind] DEFAULT(0)
	,[UnbindWanted] INT NOT NULL CONSTRAINT [DF_Weapon_UnbindWanted] DEFAULT(0)
	,[Refine] INT NOT NULL CONSTRAINT [DF_Weapon_Refine] DEFAULT(0)
	,[RefineWanted] INT NOT NULL CONSTRAINT [DF_Weapon_RefineWanted] DEFAULT(0)
	,[Slot] INT NOT NULL CONSTRAINT [DF_Weapon_Slot] DEFAULT(0)
	,[SlotWanted] INT NOT NULL CONSTRAINT [DF_Weapon_SlotWanted] DEFAULT(0)
	,[Dominion] INT NOT NULL CONSTRAINT [DF_Weapon_Dominion] DEFAULT(0)
	,[DominionWanted] INT NOT NULL CONSTRAINT [DF_Weapon_DominionWanted] DEFAULT(0)
	,[Bonus] INT NOT NULL CONSTRAINT [DF_Weapon_Bonus] DEFAULT(0)
	,[BonusWanted] INT NOT NULL CONSTRAINT [DF_Weapon_BonusWanted] DEFAULT(0)
	,CONSTRAINT [FK_AccountWeapon_Account] FOREIGN KEY ([AccountID]) REFERENCES [Account]([AccountID])
	,CONSTRAINT [FK_AccountWeapon_CoreWeapon] FOREIGN KEY ([WeaponID]) REFERENCES [core].[Weapon]([WeaponID])
	,CONSTRAINT [PK_AccountWeapon] PRIMARY KEY (
		[AccountID]
		,[WeaponID]
		)
	)

GO

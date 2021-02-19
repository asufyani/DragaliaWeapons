﻿CREATE TABLE [core].[PassiveCrafting] (
	[PassiveID] INT NOT NULL
	,[MaterialID] NVARCHAR(50) NOT NULL
	,[Quantity] INT NOT NULL
	,[Active] BIT NOT NULL CONSTRAINT [DF_PassiveCrafting_Active] DEFAULT(1)
	,CONSTRAINT [PK_PassiveCrafting] PRIMARY KEY (
		[PassiveID]
		,[MaterialID]
		)
	,CONSTRAINT [FK_PassiveCrafting_Passive] FOREIGN KEY ([PassiveID]) REFERENCES [core].[Passive]([PassiveID]) ON DELETE CASCADE
	,CONSTRAINT [FK_PassiveCrafting_Material] FOREIGN KEY ([MaterialID]) REFERENCES [core].[Material]([MaterialID]) ON DELETE CASCADE
	)

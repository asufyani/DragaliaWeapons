﻿CREATE TABLE [dbo].[Account] (
	[AccountID] INT NOT NULL IDENTITY
	,[AccountName] NVARCHAR(255) NOT NULL
	,[AccountEmail] NVARCHAR(255) NOT NULL
	,[AuthID] NVARCHAR(255) NOT NULL
	,[Active] BIT NOT NULL CONSTRAINT [DF_Account_Active] DEFAULT(1)
	,CONSTRAINT [PK_Account] PRIMARY KEY ([AccountID])
	)
GO

CREATE UNIQUE INDEX [AK_Account_AuthID] ON [dbo].[Account] ([AuthID])
GO

CREATE TRIGGER [dbo].[Trigger_Account] ON [dbo].[Account]
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON

	EXEC dbo.spFillAdventurer

	EXEC dbo.spFillDragon

	EXEC dbo.spFillFacility

	EXEC dbo.spFillInventory

	EXEC dbo.spFillPassive

	EXEC dbo.spFillWeapon

	EXEC dbo.spFillWyrmprint
END

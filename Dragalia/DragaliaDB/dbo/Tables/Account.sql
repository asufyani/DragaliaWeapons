﻿CREATE TABLE [dbo].[Account] (
	[AccountID] INT NOT NULL IDENTITY
	,[AccountName] NVARCHAR(255) NOT NULL
	,[AccountEmail] NVARCHAR(255) NOT NULL
	,CONSTRAINT [PK_User] PRIMARY KEY ([AccountID])
	)

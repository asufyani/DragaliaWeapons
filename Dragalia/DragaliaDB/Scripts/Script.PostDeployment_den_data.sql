﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
			   SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
TRUNCATE TABLE den.TreeCosts

DECLARE @Json NVARCHAR(MAX) = 
	N'[{"Level":1,"Silver":20},{"Level":2,"Rupie":10000,"Silver":10},{"Level":3,"Rupie":20000,"Silver":10},{"Level":4,"Rupie":30000,"Silver":20},{"Level":5,"Rupie":40000,"Silver":20},{"Level":6,"Rupie":50000,"Silver":30},{"Level":7,"Rupie":60000,"Silver":30},{"Level":8,"Rupie":70000,"Silver":30},{"Level":9,"Rupie":80000,"Silver":30},{"Level":10,"Rupie":90000,"Silver":30},{"Level":11,"Rupie":100000,"Silver":35,"Gold":5},{"Level":12,"Rupie":110000,"Silver":35,"Gold":5},{"Level":13,"Rupie":120000,"Silver":35,"Gold":5},{"Level":14,"Rupie":130000,"Silver":35,"Gold":5},{"Level":15,"Rupie":140000,"Silver":35,"Gold":5},{"Level":16,"Rupie":160000,"Silver":40,"Gold":10},{"Level":17,"Rupie":180000,"Silver":40,"Gold":10},{"Level":18,"Rupie":200000,"Silver":40,"Gold":10},{"Level":19,"Rupie":220000,"Silver":40,"Gold":10},{"Level":20,"Rupie":240000,"Silver":40,"Gold":10},{"Level":21,"Rupie":260000,"Silver":40,"Gold":10},{"Level":22,"Rupie":280000,"Silver":40,"Gold":10},{"Level":23,"Rupie":300000,"Silver":40,"Gold":10},{"Level":24,"Rupie":320000,"Silver":40,"Gold":10},{"Level":25,"Rupie":340000,"Silver":40,"Gold":10}]'

INSERT den.TreeCosts (
	[Level]
	,[Rupie]
	,[Silver]
	,[Gold]
	)
SELECT [Level]
	,[Rupie]
	,[Silver]
	,[Gold]
FROM OPENJSON(@Json) WITH (
		[Level] INT
		,[Rupie] INT
		,[Silver] INT
		,[Gold] INT
		)
GO

TRUNCATE TABLE den.TreeMats

DECLARE @Json NVARCHAR(MAX) = N'[{"Facility":"Flame Tree","SilverMat":"Destitute One''s Mask Fragment","GoldMat":"Plagued One''s Mask Fragment"},{"Facility":"Shadow Tree","SilverMat":"Almighty One''s Mask Fragment","GoldMat":"Uprooting One''s Mask Fragment"},{"Facility":"Wind Tree","SilverMat":"Eliminating One''s Mask Fragment","GoldMat":"Despairing One''s Mask Fragment"},{"Facility":"Water Tree","SilverMat":"Soaring Ones'' Mask Fragment","GoldMat":"Liberated One''s Mask Fragment"},{"Facility":"Light Tree","SilverMat":"Remaining One''s Mask Fragment","GoldMat":"Vengeful One''s Mask Fragment"}]'

INSERT den.TreeMats (
	[Facility]
	,[SilverMat]
	,[GoldMat]
	)
SELECT [Facility]
	,[SilverMat]
	,[GoldMat]
FROM OPENJSON(@Json) WITH (
		[Facility] NVARCHAR(50)
		,[SilverMat] NVARCHAR(50)
		,[GoldMat] NVARCHAR(50)
		)
GO

TRUNCATE TABLE den.MineCosts

DECLARE @Json NVARCHAR(MAX) = 
	N'[{"Level":1,"Rupie":50},{"Level":2,"Rupie":100},{"Level":3,"Rupie":150},{"Level":4,"Rupie":200},{"Level":5,"Rupie":250},{"Level":6,"Rupie":300,"T1":1},{"Level":7,"Rupie":350,"T1":1},{"Level":8,"Rupie":400,"T1":1},{"Level":9,"Rupie":500,"T1":2},{"Level":10,"Rupie":600,"T1":2},{"Level":11,"Rupie":700,"T1":3},{"Level":12,"Rupie":800,"T1":3},{"Level":13,"Rupie":900,"T1":3},{"Level":14,"Rupie":1000,"T1":5},{"Level":15,"Rupie":1100,"T1":5},{"Level":16,"Rupie":1200,"T1":8,"T2":1},{"Level":17,"Rupie":1400,"T1":8,"T2":1},{"Level":18,"Rupie":1600,"T1":8,"T2":1},{"Level":19,"Rupie":1800,"T1":10,"T2":1},{"Level":20,"Rupie":2000,"T1":10,"T2":1},{"Level":21,"Rupie":2200,"T1":15,"T2":2},{"Level":22,"Rupie":2400,"T1":15,"T2":2},{"Level":23,"Rupie":2600,"T1":15,"T2":2},{"Level":24,"Rupie":2800,"T1":20,"T2":2},{"Level":25,"Rupie":3000,"T1":20,"T2":2},{"Level":26,"Rupie":3200,"T1":30,"T2":3,"T3":1},{"Level":27,"Rupie":3400,"T1":30,"T2":3,"T3":1},{"Level":28,"Rupie":3600,"T1":30,"T2":3,"T3":1},{"Level":29,"Rupie":3800,"T1":40,"T2":3,"T3":1},{"Level":30,"Rupie":4000,"T1":40,"T2":3,"T3":1},{"Level":31,"Rupie":4200,"T1":50,"T2":5,"T3":2,"T4":1},{"Level":32,"Rupie":4400,"T1":55,"T2":10,"T3":4,"T4":2},{"Level":33,"Rupie":4600,"T1":65,"T2":15,"T3":6,"T4":3},{"Level":34,"Rupie":4800,"T1":80,"T2":20,"T3":9,"T4":5},{"Level":35,"Rupie":5000,"T1":100,"T2":30,"T3":12,"T4":7},{"Level":36,"Rupie":5200,"T1":130,"T2":40,"T3":15,"T4":9},{"Level":37,"Rupie":5400,"T1":160,"T2":50,"T3":20,"T4":12},{"Level":38,"Rupie":5600,"T1":200,"T2":65,"T3":25,"T4":15},{"Level":39,"Rupie":5800,"T1":260,"T2":80,"T3":30,"T4":18},{"Level":40,"Rupie":6000,"T1":400,"T2":100,"T3":40,"T4":25}]'

INSERT den.MineCosts (
	[Level]
	,[Rupie]
	,[T1]
	,[T2]
	,[T3]
	,[T4]
	)
SELECT [Level]
	,[Rupie]
	,[T1]
	,[T2]
	,[T3]
	,[T4]
FROM OPENJSON(@Json) WITH (
		[Level] INT
		,[Rupie] INT
		,[T1] INT
		,[T2] INT
		,[T3] INT
		,[T4] INT
		)
GO

TRUNCATE TABLE den.DojoCosts

DECLARE @Json NVARCHAR(MAX) = 
	N'[{"Level":1},{"Level":2,"Rupie":3000,"Aes":10},{"Level":3,"Rupie":3500,"Aes":10},{"Level":4,"Rupie":4000,"Aes":10},{"Level":5,"Rupie":4500,"Aes":10},{"Level":6,"Rupie":5000,"Aes":20},{"Level":7,"Rupie":6000,"Aes":20},{"Level":8,"Rupie":7000,"Aes":20},{"Level":9,"Rupie":8000,"Aes":20},{"Level":10,"Rupie":9000,"Aes":20},{"Level":11,"Rupie":10000,"Aes":30,"Argentus":5,"Silver":10},{"Level":12,"Rupie":12000,"Aes":30,"Argentus":5,"Silver":10},{"Level":13,"Rupie":14000,"Aes":30,"Argentus":5,"Silver":10},{"Level":14,"Rupie":16000,"Aes":30,"Argentus":10,"Silver":20},{"Level":15,"Rupie":18000,"Aes":30,"Argentus":10,"Silver":20},{"Level":16,"Rupie":20000,"Aes":50,"Argentus":20,"Silver":40},{"Level":17,"Rupie":25000,"Aes":50,"Argentus":20,"Silver":40},{"Level":18,"Rupie":30000,"Aes":50,"Argentus":20,"Silver":40},{"Level":19,"Rupie":35000,"Aes":70,"Argentus":30,"Silver":60},{"Level":20,"Rupie":40000,"Aes":70,"Argentus":30,"Silver":60},{"Level":21,"Rupie":50000,"Aes":100,"Argentus":40,"Aureus":20,"Silver":80},{"Level":22,"Rupie":60000,"Aes":100,"Argentus":40,"Aureus":30,"Silver":80},{"Level":23,"Rupie":70000,"Aes":100,"Argentus":40,"Aureus":40,"Silver":80},{"Level":24,"Rupie":80000,"Aes":150,"Argentus":50,"Aureus":50,"Silver":100},{"Level":25,"Rupie":90000,"Aes":150,"Argentus":50,"Aureus":60,"Silver":100},{"Level":26,"Rupie":100000,"Aes":200,"Argentus":60,"Aureus":70,"Silver":120,"Gold":20},{"Level":27,"Rupie":110000,"Aes":200,"Argentus":60,"Aureus":80,"Silver":120,"Gold":30},{"Level":28,"Rupie":120000,"Aes":200,"Argentus":60,"Aureus":90,"Silver":120,"Gold":40},{"Level":29,"Rupie":130000,"Aes":300,"Argentus":80,"Aureus":100,"Silver":160,"Gold":50},{"Level":30,"Rupie":140000,"Aes":300,"Argentus":80,"Aureus":110,"Silver":160,"Gold":60},{"Level":31,"Rupie":160000,"Aes":300,"Argentus":80,"Aureus":120,"Silver":200,"Gold":80},{"Level":32,"Rupie":180000,"Aes":400,"Argentus":100,"Aureus":130,"Silver":200,"Gold":80},{"Level":33,"Rupie":200000,"Aes":400,"Argentus":100,"Aureus":140,"Silver":200,"Gold":80},{"Level":34,"Rupie":220000,"Aes":500,"Argentus":120,"Aureus":150,"Silver":240,"Gold":100},{"Level":35,"Rupie":240000,"Aes":500,"Argentus":120,"Aureus":160,"Silver":240,"Gold":100}]'

INSERT den.DojoCosts (
	[Level]
	,[Rupie]
	,[Aes]
	,[Argenteus]
	,[Aureus]
	,[Silver]
	,[Gold]
	)
SELECT [Level]
	,[Rupie]
	,[Aes]
	,[Argentus]
	,[Aureus]
	,[Silver]
	,[Gold]
FROM OPENJSON(@Json) WITH (
		[Level] INT
		,[Rupie] INT
		,[Aes] INT
		,[Argentus] INT
		,[Aureus] INT
		,[Silver] INT
		,[Gold] INT
		)
GO

TRUNCATE TABLE den.DojoMats

DECLARE @Json NVARCHAR(MAX) = N'[{"Facility":"Axe Dojo","SilverMat":"Jade Insignia","GoldMat":"Royal Jade Insignia"},{"Facility":"Blade Dojo","SilverMat":"Azure Insignia","GoldMat":"Royal Azure Insignia"},{"Facility":"Bow Dojo","SilverMat":"Vermilion Insignia","GoldMat":"Royal Vermilion Insignia"},{"Facility":"Dagger Dojo","SilverMat":"Violet Insignia","GoldMat":"Royal Violet Insignia"},{"Facility":"Lance Dojo","SilverMat":"Azure Insignia","GoldMat":"Royal Azure Insignia"},{"Facility":"Manacaster Dojo","SilverMat":"Violet Insignia","GoldMat":"Royal Violet Insignia"},{"Facility":"Staff Dojo","SilverMat":"Amber Insignia","GoldMat":"Royal Amber Insignia"},{"Facility":"Sword Dojo","SilverMat":"Vermilion Insignia","GoldMat":"Royal Vermilion Insignia"},{"Facility":"Wand Dojo","SilverMat":"Jade Insignia","GoldMat":"Royal Jade Insignia"}]'

INSERT den.DojoMats (
	[Facility]
	,[SilverMat]
	,[GoldMat]
	)
SELECT [Facility]
	,[SilverMat]
	,[GoldMat]
FROM OPENJSON(@JSON) WITH (
		[Facility] NVARCHAR(50)
		,[SilverMat] NVARCHAR(50)
		,[GoldMat] NVARCHAR(50)
		)
GO

TRUNCATE TABLE den.AltarCosts

DECLARE @Json NVARCHAR(MAX) = 
	N'[{"Level":1,"Rupie":200},{"Level":2,"Rupie":400},{"Level":3,"Rupie":600},{"Level":4,"Rupie":800,"T1":1},{"Level":5,"Rupie":1000,"T1":3},{"Level":6,"Rupie":1200,"T1":5},{"Level":7,"Rupie":1500,"T1":5},{"Level":8,"Rupie":2000,"T1":5},{"Level":9,"Rupie":2500,"T1":7},{"Level":10,"Rupie":3000,"T1":7},{"Level":11,"Rupie":4000,"T1":10,"T2":1},{"Level":12,"Rupie":5000,"T1":10,"T2":1},{"Level":13,"Rupie":6000,"T1":10,"T2":1},{"Level":14,"Rupie":7000,"T1":15,"T2":2},{"Level":15,"Rupie":8000,"T1":15,"T2":2},{"Level":16,"Rupie":10000,"T1":20,"T2":3},{"Level":17,"Rupie":12000,"T1":20,"T2":3},{"Level":18,"Rupie":14000,"T1":20,"T2":3},{"Level":19,"Rupie":16000,"T1":30,"T2":4},{"Level":20,"Rupie":18000,"T1":30,"T2":4},{"Level":21,"Rupie":20000,"T1":50,"T2":6,"T3":1},{"Level":22,"Rupie":22000,"T1":50,"T2":6,"T3":1},{"Level":23,"Rupie":24000,"T1":50,"T2":6,"T3":1},{"Level":24,"Rupie":26000,"T1":70,"T2":8,"T3":1},{"Level":25,"Rupie":28000,"T1":70,"T2":8,"T3":1},{"Level":26,"Rupie":30000,"T1":100,"T2":10,"T3":2},{"Level":27,"Rupie":32000,"T1":100,"T2":10,"T3":2},{"Level":28,"Rupie":34000,"T1":100,"T2":10,"T3":2},{"Level":29,"Rupie":36000,"T1":150,"T2":12,"T3":3},{"Level":30,"Rupie":38000,"T1":150,"T2":12,"T3":3},{"Level":31,"Rupie":42000,"T1":200,"T2":15,"T3":5},{"Level":32,"Rupie":46000,"T1":200,"T2":15,"T3":5},{"Level":33,"Rupie":50000,"T1":200,"T2":15,"T3":5},{"Level":34,"Rupie":54000,"T1":250,"T2":18,"T3":7},{"Level":35,"Rupie":58000,"T1":250,"T2":18,"T3":7},{"Level":36,"Rupie":100000,"T1":300,"T2":36,"T3":15,"T4":2,"Rainbow":6},{"Level":37,"Rupie":140000,"T1":350,"T2":72,"T3":30,"T4":4,"Rainbow":12},{"Level":38,"Rupie":190000,"T1":400,"T2":108,"T3":45,"T4":6,"Rainbow":18},{"Level":39,"Rupie":250000,"T1":450,"T2":144,"T3":60,"T4":8,"Rainbow":24},{"Level":40,"Rupie":320000,"T1":500,"T2":180,"T3":75,"T4":10,"Rainbow":30}]'

INSERT den.AltarCosts (
	[Level]
	,[Rupie]
	,[T1]
	,[T2]
	,[T3]
	,[T4]
	,[Rainbow]
	)
SELECT [Level]
	,[Rupie]
	,[T1]
	,[T2]
	,[T3]
	,[T4]
	,[Rainbow]
FROM OPENJSON(@Json) WITH (
		[Level] INT
		,[Rupie] INT
		,[T1] INT
		,[T2] INT
		,[T3] INT
		,[T4] INT
		,[Rainbow] INT
		)
GO

TRUNCATE TABLE den.AltarMats

DECLARE @Json NVARCHAR(MAX) = N'[{"Facility":"Flame Altar","T1Mat":"Flame Orb","T2Mat":"Blaze Orb","T3Mat":"Inferno Orb","T4Mat":"Orb"},{"Facility":"Light Altar","T1Mat":"Light Orb","T2Mat":"Radiance Orb","T3Mat":"Refulgence Orb","T4Mat":"Resplendence Orb"},{"Facility":"Shadow Altar","T1Mat":"Shadow Orb","T2Mat":"Nightfall Orb","T3Mat":"Nether Orb","T4Mat":"Abaddon Orb"},{"Facility":"Water Altar","T1Mat":"Water Orb","T2Mat":"Stream Orb","T3Mat":"Deluge Orb","T4Mat":"Tsunami"},{"Facility":"Wind Altar","T1Mat":"Wind Orb","T2Mat":"Storm Orb","T3Mat":"Maelstrom Orb","T4Mat":"Tempest Orb"}]'

INSERT den.AltarMats (
	[Facility]
	,[T1Mat]
	,[T2Mat]
	,[T3Mat]
	,[T4Mat]
	)
SELECT [Facility]
	,[T1Mat]
	,[T2Mat]
	,[T3Mat]
	,[T4Mat]
FROM OPENJSON(@Json) WITH (
		[Facility] NVARCHAR(50)
		,[T1Mat] NVARCHAR(50)
		,[T2Mat] NVARCHAR(50)
		,[T3Mat] NVARCHAR(50)
		,[T4Mat] NVARCHAR(50)
		)
GO

TRUNCATE TABLE den.DracolithCosts

DECLARE @Json NVARCHAR(MAX) = 
	N'[{"Level":1},{"Level":2,"Rupie":3000},{"Level":3,"Rupie":4000},{"Level":4,"Rupie":5000,"Sphere":5,"Scale":3,"Talonstone":1},{"Level":5,"Rupie":6000,"Sphere":10,"Scale":4,"Talonstone":1},{"Level":6,"Rupie":7000,"Sphere":15,"Scale":5,"Talonstone":1},{"Level":7,"Rupie":8000,"Sphere":20,"Scale":6,"Talonstone":3},{"Level":8,"Rupie":10000,"Sphere":25,"Scale":7,"Talonstone":3},{"Level":9,"Rupie":12000,"Sphere":30,"Scale":8,"Talonstone":3},{"Level":10,"Rupie":14000,"Sphere":35,"Scale":10,"Talonstone":3},{"Level":11,"Rupie":16000,"Sphere":40,"Scale":15,"Talonstone":5},{"Level":12,"Rupie":18000,"Sphere":50,"Scale":20,"Talonstone":5},{"Level":13,"Rupie":20000,"Sphere":60,"Scale":25,"Talonstone":5},{"Level":14,"Rupie":22000,"Sphere":90,"Scale":30,"Talonstone":8},{"Level":15,"Rupie":24000,"Sphere":120,"Scale":40,"Talonstone":8},{"Level":16,"Rupie":26000,"Sphere":150,"Scale":60,"Talonstone":8},{"Level":17,"Rupie":28000,"Sphere":200,"Scale":80,"Talonstone":10},{"Level":18,"Rupie":30000,"Sphere":250,"Scale":100,"Talonstone":10},{"Level":19,"Rupie":32000,"Sphere":300,"Scale":120,"Talonstone":10},{"Level":20,"Rupie":34000,"Sphere":350,"Scale":140,"Talonstone":10},{"Level":21,"Rupie":50000,"Greatsphere":10,"GoldScale":27,"Talonstone":14},{"Level":22,"Rupie":74000,"Greatsphere":14,"GoldScale":31,"Talonstone":19},{"Level":23,"Rupie":110000,"Greatsphere":20,"GoldScale":34,"Talonstone":26},{"Level":24,"Rupie":160000,"Greatsphere":29,"GoldScale":37,"Talonstone":35},{"Level":25,"Rupie":240000,"Greatsphere":41,"GoldScale":40,"Talonstone":48},{"Level":26,"Rupie":360000,"Greatsphere":60,"GoldScale":45,"Talonstone":66},{"Level":27,"Rupie":520000,"Greatsphere":86,"GoldScale":50,"Talonstone":91},{"Level":28,"Rupie":789999,"Greatsphere":122,"GoldScale":60,"Talonstone":124},{"Level":29,"Rupie":1150000,"Greatsphere":174,"GoldScale":66,"Talonstone":170},{"Level":30,"Rupie":1700000,"Greatsphere":250,"GoldScale":72,"Talonstone":233}]'

INSERT den.DracolithCosts (
	[Level]
	,[Rupie]
	,[Sphere]
	,[Greatsphere]
	,[Scale]
	,[GoldScale]
	,[Talonstone]
	)
SELECT [Level]
	,[Rupie]
	,[Sphere]
	,[Greatsphere]
	,[Scale]
	,[GoldScale]
	,[Talonstone]
FROM OPENJSON(@Json) WITH (
		[Level] INT
		,[Rupie] INT
		,[Sphere] INT
		,[Greatsphere] INT
		,[Scale] INT
		,[GoldScale] INT
		,[Talonstone] INT
		)
GO

TRUNCATE TABLE den.DracolithMats

DECLARE @Json NVARCHAR(MAX) = N'[{"Facility":"Flame Dracolith","SphereMat":"Flamewyrm''s Sphere","GreatsphereMat":"Flamewyrm''s Greatsphere","ScaleMat":"Flamewyrm''s Scale","GoldScaleMat":"Flamewyrm''s Scaldscale"},{"Facility":"Light Dracolith","SphereMat":"Lightwyrm''s Sphere","GreatsphereMat":"Lightwyrm''s Greatsphere","ScaleMat":"Lightwyrm''s Scale","GoldScaleMat":"Lightwyrm''s Glowscale"},{"Facility":"Shadow Dracolith","SphereMat":"Shadowwyrm''s Sphere","GreatsphereMat":"Shadowwyrm''s Greatsphere","ScaleMat":"Shadowwyrm''s Scale","GoldScaleMat":"Shadowwyrm''s Darkscale"},{"Facility":"Water Dracolith","SphereMat":"Waterwyrm''s Sphere","GreatsphereMat":"Waterwyrm''s Greatsphere","ScaleMat":"Waterwyrm''s Scale","GoldScaleMat":"Waterwyrm''s Glistscale"},{"Facility":"Wind Dracolith","SphereMat":"Windwyrm''s Sphere","GreatsphereMat":"Windwyrm''s Greatsphere","ScaleMat":"Windwyrm''s Scale","GoldScaleMat":"Windwyrm''s Squallscale"}]'

INSERT den.DracolithMats (
	[Facility]
	,[SphereMat]
	,[GreatsphereMat]
	,[ScaleMat]
	,[GoldScaleMat]
	)
SELECT [Facility]
	,[SphereMat]
	,[GreatsphereMat]
	,[ScaleMat]
	,[GoldScaleMat]
FROM OPENJSON(@Json) WITH (
		[Facility] NVARCHAR(50)
		,[SphereMat] NVARCHAR(50)
		,[GreatsphereMat] NVARCHAR(50)
		,[ScaleMat] NVARCHAR(50)
		,[GoldScaleMat] NVARCHAR(50)
		)
GO



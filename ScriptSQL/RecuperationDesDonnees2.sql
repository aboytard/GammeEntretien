USE [GammeEntretien]
GO


DELETE FROM [dbo].[R_Rex_EstResponsable_Site]

DELETE FROM [dbo].[R_Site_SuiviPar_Techniciens]

DELETE FROM [dbo].[T_Technicien]

DELETE FROM [dbo].[T_Rex]

DELETE FROM [dbo].[T_Ra]

DELETE FROM [dbo].[T_SousStation]
DELETE FROM [dbo].[T_Sites]

INSERT INTO [dbo].[T_Ra] 
		([RaNom])
SELECT distinct [RA]
  FROM [GammeEntretien].[dbo].[ImportSousStation]

INSERT INTO [dbo].[T_Rex]     
	([RexNom], [Rex_RaId])
SELECT    distinct     ImportSousStation.REX, T_Ra.RaId
FROM            ImportSousStation INNER JOIN
                         T_Ra ON ImportSousStation.RA = T_Ra.RaNom

INSERT INTO [dbo].[T_Technicien]
           ( [TechnicienNom], [Technicien_RexId])
SELECT DISTINCT ImportSousStation.TECH, T_Rex.RexId
FROM            ImportSousStation INNER JOIN
                         T_Rex ON ImportSousStation.REX = T_Rex.RexNom
GO

INSERT INTO [dbo].[T_Sites]
           ([SiteAdresse1]
           ,[SiteAdresseCodePostale]
           ,[SiteAdresseVille])
SELECT DISTINCT [Adresse],[Département], [Ville]
FROM            ImportSousStation 
GO

INSERT INTO [dbo].[T_SousStation]
           ([CodeSousStation]
           ,[SousStationLibelle]
		   , [SiteId])
SELECT        isnull(ImportSousStation.CodeSousStation, 0), T_Sites.SiteAdresse1, T_Sites.SiteId
FROM            ImportSousStation INNER JOIN
                         T_Sites ON ImportSousStation.Adresse = T_Sites.SiteAdresse1 AND ImportSousStation.Département = T_Sites.SiteAdresseCodePostale AND 
                         ImportSousStation.Ville = T_Sites.SiteAdresseVille


INSERT INTO [dbo].[R_Site_SuiviPar_Techniciens]
           ([SousStationId]
           ,[TechnicienId])
SELECT   distinct T_SousStation.SousStationId, T_Technicien.TechnicienId
FROM            ImportSousStation INNER JOIN
                         T_Technicien ON ImportSousStation.TECH = T_Technicien.TechnicienNom INNER JOIN
                         T_SousStation ON ImportSousStation.CodeSousStation = T_SousStation.CodeSousStation
GO

INSERT INTO [dbo].[R_Rex_EstResponsable_Site]
           ([RexId]
           ,[SiteId])
SELECT DISTINCT   T_Rex.RexId,T_Sites.SiteId
FROM            T_Rex INNER JOIN
                         ImportSousStation INNER JOIN
                         T_Sites INNER JOIN
                         T_SousStation ON T_Sites.SiteId = T_SousStation.SiteId ON ImportSousStation.CodeSousStation = T_SousStation.CodeSousStation ON 
                         T_Rex.RexNom = ImportSousStation.REX
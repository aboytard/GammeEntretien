USE [GammeEntretien]
GO

ALTER TABLE [dbo].[R_Rex_EstResponsable_Site] DROP CONSTRAINT [FK_R_Rex_EstResponsable_Site_T_Sites]
GO

ALTER TABLE [dbo].[R_Rex_EstResponsable_Site] DROP CONSTRAINT [FK_R_Rex_EstResponsable_Site_T_Rex]
GO

ALTER TABLE [dbo].[R_Rex_EstResponsable_Site] DROP CONSTRAINT [DF_R_Rex_EstResponsable_Site_DateCreation]
GO

ALTER TABLE [dbo].[R_Site_SuiviPar_Techniciens] DROP CONSTRAINT [FK_R_Site_SuiviPar_Techniciens_T_Technicien]
GO

ALTER TABLE [dbo].[R_Site_SuiviPar_Techniciens] DROP CONSTRAINT [FK_R_Site_SuiviPar_Techniciens_T_SousStation]
GO

ALTER TABLE [dbo].[R_Site_SuiviPar_Techniciens] DROP CONSTRAINT [DF_R_Site_SuiviPar_Techniciens_DateCreation]
GO

ALTER TABLE [dbo].[R_SousStations_Prevoit_Actions] DROP CONSTRAINT [FK_R_SitesActions_T_Actions]
GO

ALTER TABLE [dbo].[R_SousStations_Prevoit_Actions] DROP CONSTRAINT [FK_R_Sites_Prevoit_Actions_T_SousStation]
GO

ALTER TABLE [dbo].[R_SousStations_Prevoit_Actions] DROP CONSTRAINT [DF_R_SousStations_Prevoit_Actions_DateCreation]
GO

ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation] DROP CONSTRAINT [FK_R_TechnicienActionSite_T_Technicien]
GO

ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation] DROP CONSTRAINT [FK_R_TechnicienActionSite_T_SousStation]
GO

ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation] DROP CONSTRAINT [FK_R_TechnicienAction_T_Actions]
GO

ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation] DROP CONSTRAINT [DF_R_TechnicienAction_Programmer_SousStation_DateCreation]
GO

ALTER TABLE [dbo].[T_SousStation] DROP CONSTRAINT [FK_T_SousStation_T_Sites]
GO



USE [GammeEntretien]
GO

INSERT INTO [dbo].[R_Sites_Prevoit_Actions] 
           ([SiteId]
           ,[ActionId]
           ,[Frequence])
SELECT 2,[ActionId]
      ,[ActionFrequence]
  FROM [dbo].[T_Actions]

GO



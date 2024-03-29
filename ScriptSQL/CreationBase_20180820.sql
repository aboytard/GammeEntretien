USE [master]
GO
/****** Object:  Database [GammeEntretien]    Script Date: 20/08/2019 02:03:11 ******/

USE [GammeEntretien]
GO

/****** Object:  Table [dbo].[R_Rex_EstResponsable_Site]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_Rex_EstResponsable_Site](
	[RexId] [int] NOT NULL,
	[SiteId] [int] NOT NULL,
	[Description] [nvarchar](250) NULL,
	[DateCreation] [date] NULL,
 CONSTRAINT [PK_R_RexSite] PRIMARY KEY CLUSTERED 
(
	[RexId] ASC,
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[R_Site_SuiviPar_Techniciens]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_Site_SuiviPar_Techniciens](
	[SousStationId] [int] NOT NULL,
	[TechnicienId] [int] NOT NULL,
	[Description] [nchar](10) NULL,
	[DateCreation] [date] NULL,
 CONSTRAINT [PK_R_SiteTechnicien] PRIMARY KEY CLUSTERED 
(
	[SousStationId] ASC,
	[TechnicienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[R_SousStations_Prevoit_Actions]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_SousStations_Prevoit_Actions](
	[SousStationId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[Frequence] [int] NULL,
	[DPTO] [date] NULL,
	[DPTA] [date] NULL,
	[DerniereDateDeRealisation] [date] NULL,
	[DateCreation] [date] NULL,
 CONSTRAINT [PK_R_SitesActions] PRIMARY KEY CLUSTERED 
(
	[SousStationId] ASC,
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[R_TechnicienAction_Programmer_SousStation]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_TechnicienAction_Programmer_SousStation](
	[TechnicienId] [int] NOT NULL,
	[SousStationId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[DateRealisation] [int] NULL,
	[Commentaire] [nvarchar](500) NULL,
	[DatePrevisionnel] [date] NULL,
	[DateCreation] [date] NULL,
 CONSTRAINT [PK_R_TechnicienAction] PRIMARY KEY CLUSTERED 
(
	[TechnicienId] ASC,
	[SousStationId] ASC,
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Actions]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Actions](
	[ActionId] [int] NOT NULL,
	[ActionLibellé] [nvarchar](500) NOT NULL,
	[ActionDescription] [nvarchar](max) NULL,
	[ActionFrequence] [int] NULL,
	[Action_SecteurId] [int] NULL,
 CONSTRAINT [PK_T_Action] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Gammes]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Gammes](
	[GammeId] [int] NOT NULL,
	[GammeLibellé] [nvarchar](50) NOT NULL,
	[GammeDescription] [nvarchar](250) NULL,
 CONSTRAINT [PK_T_Gammes] PRIMARY KEY CLUSTERED 
(
	[GammeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Ra]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Ra](
	[RaId] [int] IDENTITY(1,1) NOT NULL,
	[RaNom] [nvarchar](50) NOT NULL,
	[RaDescription] [nvarchar](250) NULL,
 CONSTRAINT [PK_T_Ra] PRIMARY KEY CLUSTERED 
(
	[RaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Rex]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Rex](
	[RexId] [int] IDENTITY(1,1) NOT NULL,
	[RexNom] [nvarchar](50) NOT NULL,
	[RexDescription] [nvarchar](250) NULL,
	[Rex_RaId] [int] NULL,
 CONSTRAINT [PK_T_Rex] PRIMARY KEY CLUSTERED 
(
	[RexId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Secteurs]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Secteurs](
	[SecteurId] [int] NOT NULL,
	[SecteurLibellé] [nvarchar](250) NOT NULL,
	[SecteurDescription] [nvarchar](max) NULL,
	[Secteur_GammeId] [int] NULL,
 CONSTRAINT [PK_T_Secteur] PRIMARY KEY CLUSTERED 
(
	[SecteurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Sites]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Sites](
	[SiteId] [int] IDENTITY(1,1) NOT NULL,
	[SiteAdresse1] [nvarchar](80) NULL,
	[SiteAdresse2] [nvarchar](80) NULL,
	[SiteAdresseCodePostale] [nvarchar](10) NULL,
	[SiteAdresseVille] [nvarchar](80) NULL,
	[SiteTechnicienId] [int] NULL,
	[SiteRexId] [int] NULL,
 CONSTRAINT [PK_T_Sites] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SousStation]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SousStation](
	[SousStationId] [int] IDENTITY(1,1) NOT NULL,
	[CodeSousStation] [nvarchar](80) NOT NULL,
	[SousStationLibelle] [nvarchar](80) NOT NULL,
	[SiteId] [int] NULL,
 CONSTRAINT [PK_T_SousStation] PRIMARY KEY CLUSTERED 
(
	[SousStationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Technicien]    Script Date: 20/08/2019 02:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Technicien](
	[TechnicienId] [int] IDENTITY(1,1) NOT NULL,
	[Technicien_RexId] [int] NULL,
	[TechnicienNom] [nvarchar](50) NULL,
	[TechnicienDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_T_Technicien] PRIMARY KEY CLUSTERED 
(
	[TechnicienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[R_Rex_EstResponsable_Site] ADD  CONSTRAINT [DF_R_Rex_EstResponsable_Site_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO
ALTER TABLE [dbo].[R_Site_SuiviPar_Techniciens] ADD  CONSTRAINT [DF_R_Site_SuiviPar_Techniciens_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO
ALTER TABLE [dbo].[R_SousStations_Prevoit_Actions] ADD  CONSTRAINT [DF_R_SousStations_Prevoit_Actions_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO
ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation] ADD  CONSTRAINT [DF_R_TechnicienAction_Programmer_SousStation_DateCreation]  DEFAULT (getdate()) FOR [DateCreation]
GO
ALTER TABLE [dbo].[R_Rex_EstResponsable_Site]  WITH CHECK ADD  CONSTRAINT [FK_R_Rex_EstResponsable_Site_T_Rex] FOREIGN KEY([RexId])
REFERENCES [dbo].[T_Rex] ([RexId])
GO
ALTER TABLE [dbo].[R_Rex_EstResponsable_Site] CHECK CONSTRAINT [FK_R_Rex_EstResponsable_Site_T_Rex]
GO
ALTER TABLE [dbo].[R_Rex_EstResponsable_Site]  WITH CHECK ADD  CONSTRAINT [FK_R_Rex_EstResponsable_Site_T_Sites] FOREIGN KEY([SiteId])
REFERENCES [dbo].[T_Sites] ([SiteId])
GO
ALTER TABLE [dbo].[R_Rex_EstResponsable_Site] CHECK CONSTRAINT [FK_R_Rex_EstResponsable_Site_T_Sites]
GO
ALTER TABLE [dbo].[R_Site_SuiviPar_Techniciens]  WITH CHECK ADD  CONSTRAINT [FK_R_Site_SuiviPar_Techniciens_T_SousStation] FOREIGN KEY([SousStationId])
REFERENCES [dbo].[T_SousStation] ([SousStationId])
GO
ALTER TABLE [dbo].[R_Site_SuiviPar_Techniciens] CHECK CONSTRAINT [FK_R_Site_SuiviPar_Techniciens_T_SousStation]
GO
ALTER TABLE [dbo].[R_Site_SuiviPar_Techniciens]  WITH CHECK ADD  CONSTRAINT [FK_R_Site_SuiviPar_Techniciens_T_Technicien] FOREIGN KEY([TechnicienId])
REFERENCES [dbo].[T_Technicien] ([TechnicienId])
GO
ALTER TABLE [dbo].[R_Site_SuiviPar_Techniciens] CHECK CONSTRAINT [FK_R_Site_SuiviPar_Techniciens_T_Technicien]
GO
ALTER TABLE [dbo].[R_SousStations_Prevoit_Actions]  WITH CHECK ADD  CONSTRAINT [FK_R_Sites_Prevoit_Actions_T_SousStation] FOREIGN KEY([SousStationId])
REFERENCES [dbo].[T_SousStation] ([SousStationId])
GO
ALTER TABLE [dbo].[R_SousStations_Prevoit_Actions] CHECK CONSTRAINT [FK_R_Sites_Prevoit_Actions_T_SousStation]
GO
ALTER TABLE [dbo].[R_SousStations_Prevoit_Actions]  WITH CHECK ADD  CONSTRAINT [FK_R_SitesActions_T_Actions] FOREIGN KEY([ActionId])
REFERENCES [dbo].[T_Actions] ([ActionId])
GO
ALTER TABLE [dbo].[R_SousStations_Prevoit_Actions] CHECK CONSTRAINT [FK_R_SitesActions_T_Actions]
GO
ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation]  WITH CHECK ADD  CONSTRAINT [FK_R_TechnicienAction_T_Actions] FOREIGN KEY([ActionId])
REFERENCES [dbo].[T_Actions] ([ActionId])
GO
ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation] CHECK CONSTRAINT [FK_R_TechnicienAction_T_Actions]
GO
ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation]  WITH CHECK ADD  CONSTRAINT [FK_R_TechnicienActionSite_T_SousStation] FOREIGN KEY([SousStationId])
REFERENCES [dbo].[T_SousStation] ([SousStationId])
GO
ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation] CHECK CONSTRAINT [FK_R_TechnicienActionSite_T_SousStation]
GO
ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation]  WITH CHECK ADD  CONSTRAINT [FK_R_TechnicienActionSite_T_Technicien] FOREIGN KEY([TechnicienId])
REFERENCES [dbo].[T_Technicien] ([TechnicienId])
GO
ALTER TABLE [dbo].[R_TechnicienAction_Programmer_SousStation] CHECK CONSTRAINT [FK_R_TechnicienActionSite_T_Technicien]
GO
ALTER TABLE [dbo].[T_Actions]  WITH CHECK ADD  CONSTRAINT [FK_T_Action_T_Secteur] FOREIGN KEY([Action_SecteurId])
REFERENCES [dbo].[T_Secteurs] ([SecteurId])
GO
ALTER TABLE [dbo].[T_Actions] CHECK CONSTRAINT [FK_T_Action_T_Secteur]
GO
ALTER TABLE [dbo].[T_Rex]  WITH CHECK ADD  CONSTRAINT [FK_T_Rex_T_Ra] FOREIGN KEY([Rex_RaId])
REFERENCES [dbo].[T_Ra] ([RaId])
GO
ALTER TABLE [dbo].[T_Rex] CHECK CONSTRAINT [FK_T_Rex_T_Ra]
GO
ALTER TABLE [dbo].[T_Secteurs]  WITH CHECK ADD  CONSTRAINT [FK_T_Secteur_T_Gammes] FOREIGN KEY([Secteur_GammeId])
REFERENCES [dbo].[T_Gammes] ([GammeId])
GO
ALTER TABLE [dbo].[T_Secteurs] CHECK CONSTRAINT [FK_T_Secteur_T_Gammes]
GO
ALTER TABLE [dbo].[T_SousStation]  WITH CHECK ADD  CONSTRAINT [FK_T_SousStation_T_Sites] FOREIGN KEY([SiteId])
REFERENCES [dbo].[T_Sites] ([SiteId])
GO
ALTER TABLE [dbo].[T_SousStation] CHECK CONSTRAINT [FK_T_SousStation_T_Sites]
GO
ALTER TABLE [dbo].[T_Technicien]  WITH CHECK ADD  CONSTRAINT [FK_T_Technicien_T_Rex] FOREIGN KEY([Technicien_RexId])
REFERENCES [dbo].[T_Rex] ([RexId])
GO
ALTER TABLE [dbo].[T_Technicien] CHECK CONSTRAINT [FK_T_Technicien_T_Rex]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Technicien de référence pour un site' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Sites', @level2type=N'COLUMN',@level2name=N'SiteTechnicienId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rex de référence pour un site ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Sites', @level2type=N'COLUMN',@level2name=N'SiteRexId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[37] 4[24] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ImportSousStation"
            Begin Extent = 
               Top = 9
               Left = 137
               Bottom = 222
               Right = 606
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2040
         Alias = 900
         Table = 2340
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vtemp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vtemp'
GO
USE [master]
GO
ALTER DATABASE [GammeEntretien] SET  READ_WRITE 
GO

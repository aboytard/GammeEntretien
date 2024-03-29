--USE [master]
CREATE TABLE [dbo].[ImportSousStation](
	[id] [float] NULL,
	[Département] [float] NULL,
	[Ville] [nvarchar](255) NULL,
	[Adresse] [nvarchar](255) NULL,
	[CodeSousStation] [nvarchar](255) NULL,
	[RA] [nvarchar](255) NULL,
	[REX] [nvarchar](255) NULL,
	[TECH] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Vtemp]    Script Date: 16/08/2019 23:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vtemp]
AS
SELECT        id, CodeSite, CodeClient, CodeSousStation, Traite
FROM            dbo.ImportSousStation
WHERE        (Traite IS NULL) AND (CodeSite LIKE N'8001%')
GO
/****** Object:  Table [dbo].[Dual]    Script Date: 16/08/2019 23:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dual](
	[IdDual] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImportReferentiels]    Script Date: 16/08/2019 23:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportReferentiels](
	[GammeId] [float] NULL,
	[GammeLibelle] [nvarchar](255) NULL,
	[SecteurId] [float] NULL,
	[SecteurLibelle] [nvarchar](255) NULL,
	[ActionId] [float] NULL,
	[ActionLibelle] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[R_Rex_EstResponsable_Site]    Script Date: 16/08/2019 23:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_Rex_EstResponsable_Site](
	[RexId] [int] NOT NULL,
	[SiteId] [int] NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_R_RexSite] PRIMARY KEY CLUSTERED 
(
	[RexId] ASC,
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[R_Site_SuiviPar_Techniciens]    Script Date: 16/08/2019 23:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_Site_SuiviPar_Techniciens](
	[SousStationId] [int] NOT NULL,
	[TechnicienId] [int] NOT NULL,
	[Description] [nchar](10) NULL,
 CONSTRAINT [PK_R_SiteTechnicien] PRIMARY KEY CLUSTERED 
(
	[SousStationId] ASC,
	[TechnicienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[R_Sites_Prevoit_Actions]    Script Date: 16/08/2019 23:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_Sites_Prevoit_Actions](
	[SiteId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[Frequence] [int] NULL,
	[DPTO] [date] NULL,
	[DPTA] [date] NULL,
	[DerniereDateDeRealisation] [date] NULL,
 CONSTRAINT [PK_R_SitesActions] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC,
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[R_TechnicienActionSite]    Script Date: 16/08/2019 23:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_TechnicienActionSite](
	[TechnicienId] [int] NOT NULL,
	[SousStationId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[DateRealisation] [int] NULL,
	[Commentaire] [nvarchar](500) NULL,
	[DatePrevisionnel] [date] NULL,
 CONSTRAINT [PK_R_TechnicienAction] PRIMARY KEY CLUSTERED 
(
	[TechnicienId] ASC,
	[SousStationId] ASC,
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Actions]    Script Date: 16/08/2019 23:43:45 ******/
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
/****** Object:  Table [dbo].[T_Gammes]    Script Date: 16/08/2019 23:43:45 ******/
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
/****** Object:  Table [dbo].[T_Ra]    Script Date: 16/08/2019 23:43:45 ******/
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
/****** Object:  Table [dbo].[T_Rex]    Script Date: 16/08/2019 23:43:45 ******/
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
/****** Object:  Table [dbo].[T_Secteurs]    Script Date: 16/08/2019 23:43:45 ******/
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
/****** Object:  Table [dbo].[T_Sites]    Script Date: 16/08/2019 23:43:45 ******/
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
/****** Object:  Table [dbo].[T_SousStation]    Script Date: 16/08/2019 23:43:45 ******/
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
/****** Object:  Table [dbo].[T_Technicien]    Script Date: 16/08/2019 23:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Technicien](
	[TechnicienId] [int] IDENTITY(1,1) NOT NULL,
	[Technicien_RexId] [int] NULL,
	[TechnicienNom] [nvarchar](50) NULL,
	[TechnicienDescription] [nvarchar](max) NULL,
	[TechnicienAction] [nvarchar](max) NULL,
 CONSTRAINT [PK_T_Technicien] PRIMARY KEY CLUSTERED 
(
	[TechnicienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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
ALTER TABLE [dbo].[R_Sites_Prevoit_Actions]  WITH CHECK ADD  CONSTRAINT [FK_R_Sites_Prevoit_Actions_T_Sites] FOREIGN KEY([SiteId])
REFERENCES [dbo].[T_Sites] ([SiteId])
GO
ALTER TABLE [dbo].[R_Sites_Prevoit_Actions] CHECK CONSTRAINT [FK_R_Sites_Prevoit_Actions_T_Sites]
GO
ALTER TABLE [dbo].[R_Sites_Prevoit_Actions]  WITH CHECK ADD  CONSTRAINT [FK_R_SitesActions_T_Actions] FOREIGN KEY([ActionId])
REFERENCES [dbo].[T_Actions] ([ActionId])
GO
ALTER TABLE [dbo].[R_Sites_Prevoit_Actions] CHECK CONSTRAINT [FK_R_SitesActions_T_Actions]
GO
ALTER TABLE [dbo].[R_TechnicienActionSite]  WITH CHECK ADD  CONSTRAINT [FK_R_TechnicienAction_T_Actions] FOREIGN KEY([ActionId])
REFERENCES [dbo].[T_Actions] ([ActionId])
GO
ALTER TABLE [dbo].[R_TechnicienActionSite] CHECK CONSTRAINT [FK_R_TechnicienAction_T_Actions]
GO
ALTER TABLE [dbo].[R_TechnicienActionSite]  WITH CHECK ADD  CONSTRAINT [FK_R_TechnicienActionSite_T_SousStation] FOREIGN KEY([SousStationId])
REFERENCES [dbo].[T_SousStation] ([SousStationId])
GO
ALTER TABLE [dbo].[R_TechnicienActionSite] CHECK CONSTRAINT [FK_R_TechnicienActionSite_T_SousStation]
GO
ALTER TABLE [dbo].[R_TechnicienActionSite]  WITH CHECK ADD  CONSTRAINT [FK_R_TechnicienActionSite_T_Technicien] FOREIGN KEY([TechnicienId])
REFERENCES [dbo].[T_Technicien] ([TechnicienId])
GO
ALTER TABLE [dbo].[R_TechnicienActionSite] CHECK CONSTRAINT [FK_R_TechnicienActionSite_T_Technicien]
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

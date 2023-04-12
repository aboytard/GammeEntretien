SELECT        T_Sites.SiteAdresseCodePostale, T_Sites.SiteAdresseVille, T_Sites.SiteAdresse1, T_SousStation.CodeSousStation, T_Ra.RaNom, T_Rex.RexNom, 
                         T_Technicien.TechnicienNom
FROM            T_Ra INNER JOIN
                         T_Rex ON T_Ra.RaId = T_Rex.Rex_RaId INNER JOIN
                         R_Rex_EstResponsable_Site ON T_Rex.RexId = R_Rex_EstResponsable_Site.RexId INNER JOIN
                         T_Sites ON R_Rex_EstResponsable_Site.SiteId = T_Sites.SiteId INNER JOIN
                         T_SousStation ON T_Sites.SiteId = T_SousStation.SiteId INNER JOIN
                         R_Site_SuiviPar_Techniciens ON T_SousStation.SousStationId = R_Site_SuiviPar_Techniciens.SousStationId INNER JOIN
                         T_Technicien ON R_Site_SuiviPar_Techniciens.TechnicienId = T_Technicien.TechnicienId
order by 1,2, 3 ,4 ,5 ,6, 7
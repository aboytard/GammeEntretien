SELECT T_Actions.ActionId, T_Actions.ActionLibellé, T_Actions.ActionFrequence, T_Secteurs.SecteurLibellé, R_SitesActions.Frequence
FROM     R_SitesActions INNER JOIN
                  T_Actions ON R_SitesActions.ActionId = T_Actions.ActionId INNER JOIN
                  T_Secteurs ON T_Actions.Action_SecteurId = T_Secteurs.SecteurId INNER JOIN
                  T_Gammes ON T_Secteurs.Secteur_GammeId = T_Gammes.GammeId
Where isnull(T_Actions.ActionFrequence,0) <> isnull(R_SitesActions.Frequence, 0)
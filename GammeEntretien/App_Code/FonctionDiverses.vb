Imports System.Data
Imports System.Data.SqlClient

Public Module FonctionsDiverses

    Public Function DdlSitesRequete(ByVal VRexId As Integer) As String
        Return "SELECT  SiteId as Id , SiteAdresseVille + ' ' + SiteAdresse1 as Libelle FROM dbo.T_Sites ORDER by 2 "
    End Function

    'remarqueBa N°1
    ' Cette procedure n'est pas lié à une classe car elle peut être utilisée par C_Tecnicien et C_SousStation
    Public Sub AffecterUnTechnicienAUneSousStation(ByVal VTechnicienId As Integer,
                                                   ByVal VSousStationId As Integer,
                                                   ByRef VMessage As String)
        ' j'ai renommer la relation, je trouve que c'est plus parlant que l'ancien nom :  AjouterSousStationsDunTechnicien
        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                ' ----- On prépare la requete qui va faire un insert dansla table
                MaCommand.CommandText = " Insert INTO dbo.R_SousStation_SuiviPar_Techniciens (SousStationId, TechnicienId) " &
                        " Values (@SousStationId, @TechnicienId) "
                ' exemple requete sql avec valeurs d'affectation ==>  affecte technicien 22 à la sous station 11
                ' Insert INTO dbo.R_SousStation_SuiviPar_Techniciens (SousStationId, TechnicienId) Values (11,22)

                With MaCommand.Parameters
                    .Add(New SqlParameter("@SousStationId", VSousStationId))    ' on affecte id Sous Station
                    .Add(New SqlParameter("TechnicienId", VTechnicienId))      ' on affecte id du technicien
                End With
                MaCommand.ExecuteNonQuery()
                VMessage = "L'ajout a bien été pris en compte dans la base de données"
            End Using

            ' La requete précédente que tu avais fait n'etait pas correcte ... 
            '" Insert() INTO [dbo].[R_SousStation_SuiviPar_Techniciens] ([SousStationId],[TechnicienId]) " &
            '                        " Select  SousStationId, @Id " &
            '                        " From [dbo].[T_SousStation] "
            ' le where n'est pas utile quand on fait un insert de valeurs dans une table
            ' " where Action_SecteurId =  @Id "

        Catch ex As Exception
            VMessage += "Problème pour Ajouter l'enregistrement dans la base de données  : " & ex.Message
        End Try

    End Sub

    Public Sub DefinirParametreSousStationAction()

    End Sub

    Public Function DdlSousStationRequete() As String
        ' fonction qui renvoie la requete pour alimenter une ddlSousStation de cette manière,
        '  je ne suis pas obligé de refaire la requete si je retrouve cette ddl dans plusieurs formulaires
        Return "SELECT SousStationId AS Id, isnull(T_Sites.SiteAdresseVille,'') + ' ' + isnull(T_SousStation.SousStationLibelle,'') " &
        " + ' code : ' +  isnull(T_SousStation.CodeSousStation,'') as Libelle, 1  " &
        " FROM T_SousStation INNER JOIN T_Sites ON T_SousStation.SiteId = T_Sites.SiteId " &
        " Union Select 0, 'Sélectionnez une sous station ', 0 from dual order by 3, 2"

    End Function

    Public Function DdlTechniciensRequete() As String
        ' fonction qui renvoie la requete pour alimenter une ddlTechniciens de cette manière,
        '  je ne suis pas obligé de refaire la requete si je retrouve cette ddl dans plusieurs formulaires
        Return "SELECT TechnicienId as id , TechnicienNom as Libelle, 1 FROM  T_Technicien " &
        " Union Select 0, 'Sélectionnez un technicien ', 0 from dual order by 3,2"

    End Function

    Public Function DdlSecteursRequete() As String
        ' fonction qui renvoie la requete pour alimenter une ddlTechniciens de cette manière,
        '  je ne suis pas obligé de refaire la requete si je retrouve cette ddl dans plusieurs formulaires
        Return "SELECT SecteurId as Id, SecteurLibellé as Libelle, 1  FROM GammeEntretien.dbo.T_Secteurs " &
                             " union Select 0, 'Sélectionner un Secteur ', 0 from dual order by 3, 2"

    End Function

End Module

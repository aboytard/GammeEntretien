Imports System.Data
Imports System.Data.SqlClient

Public Class C_SousStation

#Region "Propriétés"
    Property Id As Integer
    Property CodeSousStations As String
    Property Libelle As String
    Property SiteId As Integer

    ' information récupérées du site
    Property Adresse1 As String
    Property Adresse2 As String
    Property Cp As String
    Property ville As String

    Property TechnicienId As Integer
    Property RexId As Integer

    Property Message As String
#End Region

    ' listes proposées en propriétés des instances
    Private _ListeActionsPrevisionnelle As DataTable
    Public ReadOnly Property ListeActionsPrevisionnelle(Optional ByVal VRefresh As Boolean = False) As DataTable
        Get
            If _ListeActionsPrevisionnelle Is Nothing Or VRefresh Then
                Dim vreq As String = "SELECT T_Actions.ActionLibellé, R_SousStations_Prevoit_Actions.ActionId, R_SousStations_Prevoit_Actions.Frequence,  " &
        " R_SousStations_Prevoit_Actions.DPTO, R_SousStations_Prevoit_Actions.DPTA, R_SousStations_Prevoit_Actions.DerniereDateDeRealisation, R_SousStations_Prevoit_Actions.DateCreation " &
        " From R_SousStations_Prevoit_Actions INNER Join " &
        " T_Actions On R_SousStations_Prevoit_Actions.ActionId = T_Actions.ActionId " &
        " Where R_SousStations_Prevoit_Actions.SousStationId = " & Id
                _ListeActionsPrevisionnelle = DataProvider.CreateDataSet(vreq).Tables(0)
            End If
            Return _ListeActionsPrevisionnelle
        End Get
    End Property


    Private _ListeTechniciensAffectes As DataTable
    Public ReadOnly Property ListeTechniciensAffectes(VRefresh) As DataTable
        Get
            If _ListeTechniciensAffectes Is Nothing Or VRefresh Then
                Dim vreq As String = "SELECT T_Technicien.TechnicienId, T_Technicien.TechnicienNom " &
    " FROM R_SousStation_SuiviPar_Techniciens INNER JOIN T_Technicien ON R_SousStation_SuiviPar_Techniciens.TechnicienId = T_Technicien.TechnicienId " &
    " WHERE R_SousStation_SuiviPar_Techniciens.SousStationId = " & Id
                _ListeTechniciensAffectes = DataProvider.CreateDataSet(vreq).Tables(0)
            End If
            Return _ListeTechniciensAffectes
        End Get
    End Property

    Public ReadOnly Property text() As String
        Get
            Return "code " & CodeSousStations & " ville : " & ville & " géré par " & RexId
        End Get
    End Property


#Region "constructeur"
    Public Sub New()
        ' initialise une nouvelle instance vierge pour la classe
        Id = 0
    End Sub
    Private Shared Function Requete() As String
        Return "SELECT SousStationId, CodeSousStation, SousStationLibelle, T_SousStation.SiteId, SiteAdresse1, SiteAdresse2, SiteAdresseCodePostale, SiteAdresseVille, " &
                                 " isnull(T_Sites.SiteTechnicienId, 0) as TechnicienId, isnull(T_Sites.SiteRexId,0) as RexId " &
                                  " FROM T_Sites INNER JOIN T_SousStation ON T_Sites.SiteId = T_SousStation.SiteId"
    End Function


    Public Sub New(ByVal VidSousStation As Integer)
        ' initialise une nouvelle instance pour la classe en récupérant les données dans la base de données
        Try
            Dim Vreq As String = Requete() & " WHERE SousStationId = " & VidSousStation
            Using vreader As IDataReader = DataProvider.CreateDataReader(Vreq)
                vreader.Read()
                InitSousStations(vreader)
            End Using
        Catch ex As Exception
            Message = ex.Message
        End Try
    End Sub
#End Region

    Private Sub InitSousStations(ByVal VReader As IDataReader)
        Try
            Id = VReader("SousStationId")
            CodeSousStations = RTrim(VReader("CodeSousStation").ToString)
            Libelle = RTrim(VReader("SousStationLibelle").ToString)
            SiteId = VReader("SiteId")
            Adresse1 = RTrim(VReader("SiteAdresse1").ToString)
            Adresse2 = RTrim(VReader("SiteAdresse2").ToString)
            Cp = RTrim(VReader("SiteAdresseCodePostale").ToString)
            ville = RTrim(VReader("SiteAdresseVille").ToString)
            TechnicienId = VReader("TechnicienId")
            RexId = VReader("RexId")
            'Message = RTrim(VReader("").ToString)
        Catch ex As Exception
            MsgBox("probleme InitSousStation " & ex.Message)
        End Try

    End Sub

    Public Shared Function SousStations(ByRef VMessage As String) As Generic.List(Of C_SousStation)
        ' function qui renvoit la liste des sous stations
        Dim VListe As New Generic.List(Of C_SousStation)
        VMessage = ""
        Try
            Using vreader As IDataReader = DataProvider.CreateDataReader(Requete())
                While vreader.Read() Or VMessage <> ""
                    Dim Site As New C_SousStation
                    Site.InitSousStations(vreader)
                    VMessage += Site.Message
                    VListe.Add(Site)
                End While
            End Using
        Catch ex As Exception
            VMessage = " Problème pour générer la liste des sites : " & ex.Message
        End Try
        Return VListe

    End Function

    'a refaire pour les sous stations
    Public Shared Function Insert(ByVal VLibelle As String,
                                  ByVal VCodeSousStations As String,
                                  ByVal VSiteId As Integer,
                                  ByRef VMessage As String) As Integer
        ' fonction qui crée un nouvel enregistrement et renvoi l'identifiant
        VMessage = ""
        Dim Vid As Integer = 0
        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("") 'on crée une commande
                ' ----- On prépare la requete qui va faire un insert dans la table
                ' exemple de insert : INSERT INTO dbo.T_SousStation (CodeSousStation ,SousStationLibelle ,SiteId) VALUES    ('N2479' ,'Nouvelle Sous-Stations du Site 2479' ,2479)

                MaCommand.CommandText = "INSERT INTO dbo.T_SousStation (CodeSousStation ,SousStationLibelle , SiteId ) VALUES (@CodeSousStation , @SousStationLibelle, @SiteId) "
                With MaCommand.Parameters
                    .Add(New SqlParameter("@CodeSousStation", VCodeSousStations))
                    .Add(New SqlParameter("@SousStationLibelle", VLibelle))
                    .Add(New SqlParameter("@SiteId", VSiteId))
                End With

                MaCommand.ExecuteNonQuery()   ' execute la requete de type insert (qui ne renvoi pas de valeur)
                ' ---- on récupère l'identifiant qui vient d'être créé

                MaCommand.CommandText = "Select max(SousStationId) from dbo.T_SousStation"
                MaCommand.Parameters.Clear()
                Vid = MaCommand.ExecuteScalar    ' execute une requete pour récupérer la valeur demandée
                ' On indique le message qui sera retourné dans VMessage
                VMessage = "La sous station " & VCodeSousStations & "_" & Vid & " a bien été enregistrée"
            End Using
        Catch ex As Exception
            VMessage += "Problème pour créer le site : " & ex.Message
        End Try
        Return Vid
    End Function

    Public Sub Update(ByVal VLibelle As String,
                      ByVal VCodeSousStations As String,
                      ByVal VSiteId As Integer,
                      ByRef VMessage As String)
        ' fonction qui crée un nouvel enregistrement et renvoi l'identifiant
        VMessage = ""
        MsgBox("zeubi")
        Try
            MsgBox("zeubi")
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                ' ----- On prépare la requete qui va faire un insert dansla table
                MsgBox("bonne création des commandes : @CodeSousStation" & VCodeSousStations & "@SousStationLibelle" & VLibelle & "@SiteId" & VSiteId)
                MaCommand.CommandText = " UPDATE [dbo].[T_SousStation]" &
                                        " SET [CodeSousStation] = @CodeSousStation" &
                                        " ,[SousStationLibelle] = @SousStationLibelle" &
                                        " ,[SiteId] = @SiteId " &
                                        " WHERE [SousStationId]= " & Id
                MsgBox("")
                With MaCommand.Parameters
                    .Add(New SqlParameter("@CodeSousStation", VCodeSousStations))
                    .Add(New SqlParameter("@SousStationLibelle", VLibelle))
                    .Add(New SqlParameter("@SiteId", VSiteId))
                End With

                MaCommand.ExecuteNonQuery()   ' execute la requete de type insert (qui ne renvoi pas de valeur
                ' ---- on récupère l'identifiant qui vient d'être créé
                ' On indique le message qui sera retourné dans VMessage
                VMessage = "La sous-station " & Id & " a bien été modifié"
            End Using
        Catch ex As Exception
            VMessage += "Problème enregistrer la modification de la sous-station : " & ex.Message
        End Try
    End Sub

    Public Sub delete(ByRef VMessage As String)
        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                ' ----- On prépare la requete qui va faire un insert dansla table
                MaCommand.CommandText = "DELETE FROM dbo.T_SousStation Where SousStationId = " & Id
                MaCommand.ExecuteNonQuery()
                VMessage = "La sous-station " & Id & " a bien été supprimé dans la base de données"
            End Using
        Catch ex As Exception
            VMessage += "Problème pour supprimer la sous-station : " & ex.Message
        End Try
    End Sub

    Public Sub AjouterActionsDunSecteur(ByVal VSecteurId As Integer,
                                        ByRef VMessage As String)

        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                ' ----- On prépare la requete qui va faire un insert dansla table
                MaCommand.CommandText = "INSERT INTO dbo.R_SousStations_Prevoit_Actions (SousStationId, ActionId, Frequence) " &
                    " SELECT @Id, ActionId, ActionFrequence  FROM GammeEntretien.dbo.T_Actions  " &
                    " where Action_SecteurId = @Action_SecteurId"
                With MaCommand.Parameters
                    .Add(New SqlParameter("@Id", Id))
                    .Add(New SqlParameter("@Action_SecteurId", VSecteurId))
                End With
                MaCommand.ExecuteNonQuery()
                VMessage = "Les actions du secteur " & VSecteurId & " ont bien été ajouté dans la base de données"
            End Using
        Catch ex As Exception
            VMessage += "Problème pour AjouterActionsDunSecteur à la sous-station : " & ex.Message
        End Try

    End Sub

    Public Sub AjouterTechnicienAUneSousStation(ByVal VTechnicienId As Integer,
                                               ByRef VMessage As String)
        FonctionsDiverses.AffecterUnTechnicienAUneSousStation(VTechnicienId, Id, VMessage)

    End Sub
End Class


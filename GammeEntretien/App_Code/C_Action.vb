Imports System.Data
Imports System.Data.SqlClient

Public Class C_Action

#Region "Propriétés"
    Property Id As Integer
    Property ActionLibelle As String
    Property ActionDescription As String
    Property ActionFrequence As String
    Property Action_SecteurId As Integer

    ' informations récupérées sur le secteur

    Property SecteurLibelle As String
    Property Secteur_GammeId As Integer

    ' informations récupérées sur la gamme

    Property GammeLibelle As String

    Property Message As String
    Private _ListeSousStationAttribuéesAction As DataTable
    Public ReadOnly Property ListeSousStationAttribuéesAction(Optional ByVal VRefresh As Boolean = False) As DataTable
        Get
            If _ListeSousStationAttribuéesAction Is Nothing Or VRefresh Then

                Dim vreq As String = "SELECT R_SousStations_Prevoit_Actions.SousStationId, T_SousStation.CodeSousStation, T_SousStation.SousStationLibelle, T_SousStation.SiteId, R_SousStations_Prevoit_Actions.Frequence, " &
                                     " R_SousStations_Prevoit_Actions.DPTO, R_SousStations_Prevoit_Actions.DPTA, R_SousStations_Prevoit_Actions.DerniereDateDeRealisation, R_SousStations_Prevoit_Actions.DateCreation  " &
                                     " From R_SousStations_Prevoit_Actions INNER Join T_SousStation On R_SousStations_Prevoit_Actions.SousStationId = T_SousStation.SousStationId" &
                                     " Where R_SousStations_Prevoit_Actions.ActionId = " & Id
                _ListeSousStationAttribuéesAction = DataProvider.CreateDataSet(vreq).Tables(0)
            End If
            Return _ListeSousStationAttribuéesAction
        End Get
    End Property
    Public ReadOnly Property text() As String
        Get
            Return "Action " & ActionLibelle & " ActionId : " & Id & " du secteur " & Action_SecteurId
        End Get
    End Property
#End Region

    Public Sub New()
        ' initialise une nouvelle instance vierge pour la classe
        Id = 0
    End Sub

    Private Shared Function Requete() As String 'définir une requête la plus globale possible que je vais réutiliser par la suite
        Return "SELECT T_Actions.ActionId as Id, T_Actions.ActionLibellé as Libelle, T_Actions.ActionDescription, T_Actions.ActionFrequence, T_Actions.Action_SecteurId, T_Secteurs.SecteurLibellé as SecteurLibelle,T_Secteurs.Secteur_GammeId, T_Gammes.GammeLibellé as GammeLibelle" &
               " FROM     T_Actions INNER JOIN T_Secteurs ON T_Actions.Action_SecteurId = T_Secteurs.SecteurId INNER JOIN T_Gammes ON T_Secteurs.Secteur_GammeId = T_Gammes.GammeId"
    End Function


    Public Sub New(ByVal VidAction As Integer)
        ' initialise une nouvelle instance pour la classe en récupérant les données dans la base de données

        Try
            Dim Vreq As String = Requete() & " WHERE T_Actions.ActionId = " & VidAction
            Using vreader As IDataReader = DataProvider.CreateDataReader(Vreq)
                vreader.Read()
                InitAction(vreader)
            End Using
        Catch ex As Exception
            Message = "probleme New(" & VidAction & " )" & ex.Message
        End Try
    End Sub

    Private Sub InitAction(ByVal VReader As IDataReader)
        Try
            Id = VReader("Id")
            ActionLibelle = RTrim(VReader("Libelle").ToString)
            ActionDescription = RTrim(VReader("ActionDescription").ToString)
            ActionFrequence = RTrim(VReader("ActionFrequence").ToString)
            Action_SecteurId = VReader("Action_SecteurId")
            SecteurLibelle = RTrim(VReader("SecteurLibelle").ToString)
            Secteur_GammeId = VReader("Secteur_GammeId")
            GammeLibelle = RTrim(VReader("GammeLibelle").ToString)
        Catch ex As Exception
            MsgBox("probleme InitAction " & ex.Message)
        End Try

    End Sub

    Public Function Insert(ByVal VActionLibelle As String,
                          ByVal VActionDescription As String,
                          ByVal VActionFrequence As String,
                          ByVal VAction_SecteurId As Integer,
                          ByRef VMessage As String) As Integer

        Dim vretour As Boolean = False
        Dim VId As Integer = 0
        Try
            Using VCommand As SqlCommand = DataProvider.CreateCommand("")
                ' Recupere prochain Id pour créer un nouvel enregistrement convention​
                VCommand.CommandText = "SELECT Max(ActionId) FROM T_Actions "
                VCommand.Parameters.Clear()
                Try
                    VId = VCommand.ExecuteScalar + 1
                Catch ex As Exception
                    VId = 1
                End Try



                ' ajoute la convention dans la table
                VCommand.CommandText = "INSERT INTO dbo.T_Actions (ActionId,ActionLibellé, ActionDescription, ActionFrequence, Action_SecteurId)" &
                                        " VALUES (@ActionId,@ActionLibelle , @ActionDescription,@ActionFrequence,@Action_SecteurId)"
                With VCommand.Parameters
                    .Add(New SqlParameter("@ActionId", VId))
                    .Add(New SqlParameter("@ActionLibelle", VActionLibelle))
                    .Add(New SqlParameter("@ActionDescription", VActionDescription))
                    .Add(New SqlParameter("@ActionFrequence", VActionFrequence))
                    .Add(New SqlParameter("@Action_SecteurId", VAction_SecteurId))
                End With
                VCommand.ExecuteNonQuery()
                ' Si commande ok je garde le Id dansla propriété de l'instance
                VMessage = "L'action " & VActionLibelle & "_" & VId & " a bien été enregistrée"

                Id = VId
                ActionLibelle = VActionLibelle
                ActionDescription = VActionDescription
                ActionFrequence = VActionFrequence
                Action_SecteurId = VAction_SecteurId

                VMessage = "L'Action " & ActionLibelle & "_" & Id & " a bien été créée"
                vretour = True
                Return VId
            End Using
        Catch ex As Exception
            VMessage = " Erreur création action : " & ex.Message
        End Try
        Return vretour
    End Function


    Public Sub Update(ByVal VActionLibelle As String,
                      ByVal VActionDescription As String,
                      ByVal VActionFrequence As String,
                      ByVal VAction_SecteurId As Integer,
                      ByRef VMessage As String)
        ' fonction qui crée un nouvel enregistrement et renvoi l'identifiant
        VMessage = ""
        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                ' ----- On prépare la requete qui va faire un insert dansla table

                MaCommand.CommandText = " Update [dbo].[T_Actions]" &
                                       " SET ActionLibellé = @ActionLibelle" &
                                       ", ActionDescription = @ActionDescription" &
                                       ", ActionFrequence = @ActionFrequence" &
                                       ", Action_SecteurId = @Action_SecteurId" &
                                       " WHERE ActionId = " & Id
                With MaCommand.Parameters
                    .Add(New SqlParameter("@ActionLibelle", VActionLibelle))
                    .Add(New SqlParameter("@ActionDescription", VActionDescription))
                    .Add(New SqlParameter("@ActionFrequence", VActionFrequence))
                    .Add(New SqlParameter("@Action_SecteurId", VAction_SecteurId))
                End With

                MaCommand.ExecuteNonQuery()

                ' la command insert est passé sans erreur donc je récupère mes valeurs dans les propriétés de l'instance

                ' id = la valeur est déjà renseigné car je l'utilise dans la condition dela requete, 

                ' il faudra le faire pour insert car la clé est caluculée dans la méthode id =​VId

                ActionLibelle = VActionLibelle
                ActionDescription = VActionDescription
                ActionFrequence = VActionFrequence
                Action_SecteurId = VAction_SecteurId

                VMessage = "L'Action " & ActionLibelle & "_" & Id & " a bien été modifié"
            End Using
        Catch ex As Exception
            VMessage += "Problème enregistrer la modification de l'action : " & ex.Message
        End Try
    End Sub

    Public Sub delete(ByRef VMessage As String)
        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                ' ----- On prépare la requete qui va faire un insert dansla table
                MaCommand.CommandText = "DELETE FROM dbo.T_Actions Where ActionId = " & Id
                MaCommand.ExecuteNonQuery()
                VMessage = "L'action " & Id & " a bien été supprimé dans la base de données"
            End Using
        Catch ex As Exception
            VMessage += "Problème pour supprimer l'action : " & ex.Message
        End Try
    End Sub

    Public Sub AffecterUneSousStationAUneAction(ByVal VSousStationId As Integer,
                                                ByRef VMessage As String)

        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                ' ----- On prépare la requete qui va faire un insert dansla table
                MaCommand.CommandText = " Insert INTO [dbo].[R_SousStations_Prevoit_Actions]  (ActionId, SousStationId)" &
                                        " Select @Id , SousStationId FROM GammeEntretien.dbo.T_SousStation " &
                                        " WHERE SousStationId = @SousStationId"
                With MaCommand.Parameters
                    .Add(New SqlParameter("@Id", Id))
                    .Add(New SqlParameter("@SousStationId", VSousStationId))
                End With
                MaCommand.ExecuteNonQuery()
                VMessage = "La Sous-Station " & VSousStationId & " ont bien été ajouté dans la base de données"
            End Using
        Catch ex As Exception
            VMessage += "Problème pour AffecterUneSousStationAUneAction : " & ex.Message
        End Try

    End Sub

End Class

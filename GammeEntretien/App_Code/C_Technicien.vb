Imports System.Data
Imports System.Data.SqlClient


Public Class C_Technicien


#Region "Propriétés"
    Property Id As Integer
    Property TechnicienNom As String
    Property TechnicienDescription As String
    Property RexId As Integer
    ' information récupérées du Rex


    Property RexNom As String

    Property Message As String

    Private _ListeSousStationAttribuées As DataTable
    Public ReadOnly Property ListeSousStationAttribuées(Optional ByVal VRefresh As Boolean = False) As DataTable
        Get
            If _ListeSousStationAttribuées Is Nothing Or VRefresh Then

                Dim vreq As String = " Select R_SousStation_SuiviPar_Techniciens.SousStationId, R_SousStation_SuiviPar_Techniciens.Description, T_SousStation.CodeSousStation, T_SousStation.SousStationLibelle, T_SousStation.SiteId" &
        " From R_SousStation_SuiviPar_Techniciens INNER Join T_SousStation On R_SousStation_SuiviPar_Techniciens.SousStationId = T_SousStation.SousStationId" &
        " Where R_SousStation_SuiviPar_Techniciens.TechnicienId = " & Id
                _ListeSousStationAttribuées = DataProvider.CreateDataSet(vreq).Tables(0)
            End If
            Return _ListeSousStationAttribuées
        End Get
    End Property
    Public ReadOnly Property text() As String
        Get
            Return "Technicien " & TechnicienNom & " TechnicienId : " & Id & " géré par " & RexNom
        End Get
    End Property

#End Region
    Public Sub New()
        ' initialise une nouvelle instance vierge pour la classe
        Id = 0
    End Sub

    Private Shared Function Requete() As String 'définir une requête la plus globale possible que je vais réutiliser par la suite
        Return "SELECT T_Technicien.TechnicienId as Id, T_Technicien.TechnicienNom, T_Technicien.TechnicienDescription, isnull(T_Technicien.Technicien_RexId,0) as RexId , T_Rex.RexNom " &
               " FROM T_Rex INNER JOIN T_Technicien ON T_Rex.RexId = T_Technicien.Technicien_RexId"
    End Function

    Public Sub New(ByVal VidTechnicien As Integer)
        ' initialise une nouvelle instance pour la classe en récupérant les données dans la base de données

        Try
            Dim Vreq As String = Requete() & " WHERE T_Technicien.TechnicienId = " & VidTechnicien
            Using vreader As IDataReader = DataProvider.CreateDataReader(Vreq)
                vreader.Read()
                InitTechnicien(vreader)
            End Using
        Catch ex As Exception
            Message = "probleme New(" & VidTechnicien & " )" & ex.Message
        End Try
    End Sub

    Private Sub InitTechnicien(ByVal VReader As IDataReader)
        Try
            Id = VReader("Id")
            TechnicienNom = RTrim(VReader("TechnicienNom").ToString)
            TechnicienDescription = RTrim(VReader("TechnicienDescription").ToString)
            RexId = VReader("RexId")
            RexNom = RTrim(VReader("RexNom").ToString)
        Catch ex As Exception
            MsgBox("probleme InitTechnicien " & ex.Message)
        End Try

    End Sub

    Public Shared Function Insert(ByVal VTechnicienNom As String,
                              ByVal VTechnicienDescription As String,
                              ByVal VRexId As Integer,
                              ByRef VMessage As String) As Integer
        ' fonction qui crée un nouvel enregistrement et renvoi l'identifiant
        VMessage = ""
        Dim Vid As Integer = 0
        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("") 'on crée une commande
                ' ----- On prépare la requete qui va faire un insert dans la table
                ' exemple de insert : INSERT INTO dbo.T_SousStation (CodeSousStation ,SousStationLibelle ,SiteId) VALUES    ('N2479' ,'Nouvelle Sous-Stations du Site 2479' ,2479)


                MaCommand.CommandText = "Insert INTO dbo.T_Technicien (Technicien_RexId,TechnicienNom,TechnicienDescription)VALUES(@Technicien_RexId,@TechnicienNom,@TechnicienDescription)"
                With MaCommand.Parameters
                    .Add(New SqlParameter("@Technicien_RexId", VRexId))
                    .Add(New SqlParameter("@TechnicienNom", VTechnicienNom))
                    .Add(New SqlParameter("@TechnicienDescription", VTechnicienDescription))
                End With

                MaCommand.ExecuteNonQuery()   ' execute la requete de type insert (qui ne renvoi pas de valeur)
                ' ---- on récupère l'identifiant qui vient d'être créé

                MaCommand.CommandText = "Select max(TechnicienId) from dbo.T_Technicien"
                MaCommand.Parameters.Clear()
                Vid = MaCommand.ExecuteScalar    ' execute une requete pour récupérer la valeur demandée
                '' On indique le message qui sera retourné dans VMessage
                VMessage = "Le technicien " & VTechnicienNom & "_" & Vid & " a bien été enregistrée"
            End Using
        Catch ex As Exception
            VMessage += "Problème pour créer le technicien : " & ex.Message
        End Try
        Return Vid
    End Function


    Public Sub Update(ByVal VTechnicienNom As String,
                      ByVal VTechnicienDescription As String,
                      ByVal VRexId As Integer,
                      ByRef VMessage As String)
        ' fonction qui crée un nouvel enregistrement et renvoi l'identifiant
        VMessage = ""
        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                ' ----- On prépare la requete qui va faire un insert dansla table

                MaCommand.CommandText = "  Update [dbo].[T_Technicien]" &
                                       " SET [Technicien_RexId] = @Technicien_RexId" &
                                       " ,[TechnicienNom] = @TechnicienNom" &
                                       " ,[TechnicienDescription] = @TechnicienDescription" &
                                       " WHERE TechnicienId = " & Id
                With MaCommand.Parameters
                    .Add(New SqlParameter("@Technicien_RexId", VRexId))
                    .Add(New SqlParameter("@TechnicienNom", VTechnicienNom))
                    .Add(New SqlParameter("@TechnicienDescription", VTechnicienDescription))
                End With

                MaCommand.ExecuteNonQuery()   ' execute la requete de type insert (qui ne renvoi pas de valeur
                ' ---- on récupère l'identifiant qui vient d'être créé
                ' On indique le message qui sera retourné dans VMessage
                VMessage = "Le Technicien " & TechnicienNom & "_" & Id & " a bien été modifié"
            End Using
        Catch ex As Exception
            VMessage += "Problème enregistrer la modification du technicien : " & ex.Message
        End Try
    End Sub


    Public Sub delete(ByRef VMessage As String)
        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                ' ----- On prépare la requete qui va faire un insert dansla table
                MaCommand.CommandText = "DELETE FROM dbo.T_Technicien Where TechnicienId = " & Id
                MaCommand.ExecuteNonQuery()
                VMessage = "Le Technicien " & Id & " a bien été supprimé dans la base de données"
            End Using
        Catch ex As Exception
            VMessage += "Problème pour supprimer le Technicien : " & ex.Message
        End Try
    End Sub

    Public Sub AffecterUneSousStationAuTechnicien(ByVal VSousStationId As Integer,
                                                   ByRef VMessage As String)
        FonctionsDiverses.AffecterUnTechnicienAUneSousStation(Id, VSousStationId, VMessage)
    End Sub




End Class



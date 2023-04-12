Imports System.Data
Imports System.Data.SqlClient

Public Class C_Prevoir

#Region "Propriétés"


    Property Id As Integer
    Property SousStationId As Integer
    Property ActionId As Integer
    Property Frequence As Integer
    Property DPTO As Date
    Property DPTA As Date
    Property DerniereDateDeRealisation As Date
    Property DateCreation As Date

    Property Message As String


#End Region

    Private Shared Function Requete() As String
        Return "SELECT 1 as Id, SousStationId, ActionId, Frequence, DPTO, DPTA, DerniereDateDeRealisation, DateCreation" &
                " FROM dbo.R_SousStations_Prevoit_Actions"
    End Function

    Public Sub New(ByVal VidSouStation As Integer, ByVal VidAction As Integer)

        ' initialise une nouvelle instance pour la classe en récupérant les données dans la base de données

        Try
            Dim Vreq As String = Requete() & " WHERE SousStationId = " & VidSouStation & "AND ActionId = " & VidAction
            Using vreader As IDataReader = DataProvider.CreateDataReader(Vreq)
                vreader.Read()
                InitActionParSousStation(vreader)
            End Using
        Catch ex As Exception
            Message = "probleme New(" & Id & " )" & ex.Message
        End Try
    End Sub

    Private Sub InitActionParSousStation(ByVal VReader As IDataReader)
        Try
            Id = VReader("Id")
            SousStationId = VReader("SousStationId")
            ActionId = VReader("ActionId")
            Frequence = VReader("Frequence")
            DPTO = RTrim(VReader("DPTO").ToString)
            DPTA = RTrim(VReader("DPTA").ToString)
            DerniereDateDeRealisation = RTrim(VReader("DerniereDateDeRealisation").ToString)
            DateCreation = RTrim(VReader("DateCreation").ToString)
        Catch ex As Exception
            MsgBox("probleme InitActionParSouStation " & ex.Message)
        End Try
    End Sub

    Public Sub Update(ByVal VFrequence As Integer,
                  ByVal VDPTO As Date,
                  ByVal VDPTA As Date,
                  ByVal VDerniereDateDeRealisation As Date,
                  ByRef VMessage As String)
        ' fonction qui crée un nouvel enregistrement et renvoi l'identifiant
        VMessage = ""

        Try
            Using MaCommand As SqlCommand = DataProvider.CreateCommand("")
                'MaCommand.CommandText = "SELECT SousStationId & ActionId as Id FROM dbo.R_SousStations_Prevoit_Actions "
                'MaCommand.Parameters.Clear()

                ' ----- On prépare la requete qui va faire un insert dansla table

                MaCommand.CommandText = " Update [dbo].[R_SousStations_Prevoit_Actions] " &
                                        " SET Frequence = @Frequence " &
                                        " ,DPTO = @DPTO " &
                                        " ,DPTA = @DPTA " &
                                        " ,DerniereDateDeRealisation = @DerniereDateDeRealisation " &
                                        " WHERE SousStationId = " & SousStationId & " AND ActionId =" & ActionId

                With MaCommand.Parameters
                    .Add(New SqlParameter("@Frequence", VFrequence))
                    .Add(New SqlParameter("@DPTO", VDPTO))
                    .Add(New SqlParameter("@DPTA", VDPTA))
                    .Add(New SqlParameter("@DerniereDateDeRealisation", VDerniereDateDeRealisation))
                End With

                MaCommand.ExecuteNonQuery()
                ' Si commande ok je garde le Id dansla propriété de l'instance

                VMessage = "Les propriétés de l'action " & ActionId & "pour la sous-station" & SousStationId & " ont bien été mise à jour"

                Frequence = VFrequence
                DPTO = VDPTO
                DPTA = VDPTA
                DerniereDateDeRealisation = VDerniereDateDeRealisation
            End Using
        Catch ex As Exception
            VMessage = " Erreur modification des propriétés de l'action : " & ex.Message
        End Try
    End Sub
End Class

Imports System.Data
Imports System.Data.SqlClient

Public Class C_Programmer

#Region "Propriétés"

    Property Id As Integer
    Property TechnicienId As Integer
    Property SousStationId As Integer
    Property ActionId As Integer
    Property DateRealisation As Date
    Property Commentaire As String
    Property DatePrevisionnel As Date
    Property DateCreation As Date
    Property Message As String


    Private _ListeActionProgrammePourUnTechnicienSurUneSousStation As DataTable
    Public ReadOnly Property ListeActionProgrammePourUnTechnicienSurUneSousStation(ByVal VIdTechicien As Integer, ByVal VIdSousStation As Integer, ByVal VIdAction As Integer, Optional ByVal VRefresh As Boolean = False) As DataTable
        Get
            If _ListeActionProgrammePourUnTechnicienSurUneSousStation Is Nothing Or VRefresh Then

                Dim Vreq As String = " SELECT R_TechnicienAction_Programmer_SousStation.ActionId, T_Actions.ActionLibellé, R_TechnicienAction_Programmer_SousStation.DateRealisation, R_TechnicienAction_Programmer_SousStation.Commentaire, " &
                         " R_TechnicienAction_Programmer_SousStation.DatePrevisionnel, R_TechnicienAction_Programmer_SousStation.DateCreation" &
                         " FROM     R_TechnicienAction_Programmer_SousStation INNER JOIN" &
                         " T_Actions ON R_TechnicienAction_Programmer_SousStation.ActionId = T_Actions.ActionId INNER JOIN" &
                         " T_SousStation ON R_TechnicienAction_Programmer_SousStation.SousStationId = T_SousStation.SousStationId INNER JOIN" &
                         " T_Technicien ON R_TechnicienAction_Programmer_SousStation.TechnicienId = T_Technicien.TechnicienId" &
                                     "WHERE R_TechnicienAction_Programmer_SousStation.SousStationId = " & VIdSousStation &
                                     " AND R_TechnicienAction_Programmer_SousStation.TechnicienId = " & VIdTechicien &
                                     " AND R_TechnicienAction_Programmer_SousStation.ActionId = " & VIdAction
                _ListeActionProgrammePourUnTechnicienSurUneSousStation = DataProvider.CreateDataSet(Vreq).Tables(0)
            End If
            Return _ListeActionProgrammePourUnTechnicienSurUneSousStation
        End Get
    End Property



#End Region

    Public Sub New()
        ' initialise une nouvelle instance vierge pour la classe
        Id = 0
    End Sub

    Private Shared Function Requete() As String 'définir une requête la plus globale possible que je vais réutiliser par la suite
        Return " SELECT 1 as Id, TechnicienId, SousStationId, ActionId, DateRealisation, Commentaire, DatePrevisionnel, DateCreation " &
               " FROM     R_TechnicienAction_Programmer_SousStation"
    End Function

    Public Sub New(ByVal VidTechnicien As Integer, ByVal VidSousStation As Integer, ByVal VidAction As Integer)
        ' initialise une nouvelle instance pour la classe en récupérant les données dans la base de données
        ActionId = VidAction

        Try
            Dim Vreq As String = Requete() & " WHERE TechnicienId = " & VidTechnicien & "AND SousStationId = " & VidSousStation
            Using vreader As IDataReader = DataProvider.CreateDataReader(Vreq)
                vreader.Read()
                InitAction(vreader)
            End Using
        Catch ex As Exception
            Message = "probleme New(" & VidTechnicien & VidSousStation & " )" & ex.Message
        End Try
    End Sub


    Private Sub InitAction(ByVal VReader As IDataReader)
        Try
            Id = VReader("Id")
            TechnicienId = VReader("TechnicienId")
            SousStationId = VReader("SousStationId")
            ActionId = VReader("ActionId")
            DateRealisation = VReader("DateRealisation")
            Commentaire = RTrim(VReader("Commentaire").ToString)
            DatePrevisionnel = VReader("DatePrevisionnel")
            DateCreation = VReader("DateCreation")



        Catch ex As Exception
            MsgBox("probleme InitAction " & ex.Message)
        End Try

    End Sub




End Class

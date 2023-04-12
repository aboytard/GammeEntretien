Public Class ActionSousStationAffecte
    Inherits System.Web.UI.Page


    Dim MonAction As C_Action
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                initDdlSite()
                initDdlSousStation()
                MonAction = Session("MonAction")
                InitGw()

            Catch ex As Exception
                MonAction = New C_Action()
            End Try
        End If

    End Sub

    Protected Sub InitGw()
        GwStlisteSousStation.DataSource = MonAction.ListeSousStationAttribuéesAction(True)
        GwStlisteSousStation.DataBind()
        LbRecap.Text = MonAction.text
    End Sub

    Protected Sub DdlVilles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlVilles.SelectedIndexChanged
        initDdlSousStation()
    End Sub

    Protected Sub DdlSousStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlSousStation.SelectedIndexChanged

    End Sub

    Protected Sub initDdlSite()
        DdlVilles.DataSource = DataProvider.CreateDataSet("SELECT SiteAdresseVille as ville, 1 FROM dbo.T_Sites " &
                                                          " union SELECT 'Sélectionner une Ville ', 0 from dual order by 2, 1")
        DdlVilles.DataTextField = "ville"
        DdlVilles.DataValueField = "ville"
        DdlVilles.DataBind()
    End Sub

    Protected Sub initDdlSousStation()
        'MsgBox("DdlVilles.SelectedValue = " & DdlVilles.SelectedValue)
        DdlSousStation.DataSource = DataProvider.CreateDataSet(" SELECT T_SousStation.SousStationId as Id, T_SousStation.CodeSousStation + ' ' + T_SousStation.SousStationLibelle as Libelle, 0" &
                                                               " From T_SousStation INNER Join T_Sites On T_SousStation.SiteId = T_Sites.SiteId" &
                                                               " Where T_Sites.SiteAdresseVille ='" & DdlVilles.SelectedValue & "'" &
                                                               " union Select 0,'Selectionner une sous station' , 0 from dual order by 3, 1")
        DdlSousStation.DataTextField = "Libelle"
        DdlSousStation.DataValueField = "Id"
        DdlSousStation.DataBind()
    End Sub

    Protected Sub BtAjoutSousStation_Click(sender As Object, e As EventArgs) Handles BtAjoutSousStation.Click
        MonAction = Session("MonAction")
        MonAction.AffecterUneSousStationAUneAction(DdlSousStation.SelectedValue, LbMessage.Text)
        InitGw()
    End Sub

    Protected Sub BtRetour_Click(sender As Object, e As EventArgs) Handles BtRetour.Click
        MonAction = Session("MonAction")
        Dim IdDemande As Integer = MonAction.Id
        Response.Redirect("/Admin/Action.aspx?Id=" & IdDemande)
    End Sub

    Protected Sub GwStlisteSousStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GwStlisteSousStation.SelectedIndexChanged

    End Sub

    Protected Sub ZoomActionSousStation(sender As Object, e As EventArgs)
        '
    End Sub
End Class

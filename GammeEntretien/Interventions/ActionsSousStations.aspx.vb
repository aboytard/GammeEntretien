Public Class ActionsSousStations
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Try
                initDdlSite()
                initDdlSousStation()


                If Not Session("Ville") Is Nothing Then
                    DdlVilles.SelectedValue = Session("Ville")
                    initDdlSousStation()
                End If

                If Not Session("SousStationId") Is Nothing Then
                    DdlSousStation.SelectedValue = Session("SousStationId")
                End If

            Catch ex As Exception
                '
            End Try
        End If

        InitGw()

    End Sub

    Protected Sub initDdlSite()
        DdlVilles.DataSource = DataProvider.CreateDataSet("SELECT SiteAdresseVille as ville, 1 FROM dbo.T_Sites " &
                                                          " union SELECT 'Sélectionner une Ville ', 0 from dual order by 2, 1")
        DdlVilles.DataTextField = "ville"
        DdlVilles.DataValueField = "ville"
        DdlVilles.DataBind()

    End Sub

    Protected Sub initDdlSousStation()
        DdlSousStation.DataSource = DataProvider.CreateDataSet(" SELECT T_SousStation.SousStationId as Id, T_SousStation.CodeSousStation + ' ' + T_SousStation.SousStationLibelle as Libelle, 0" &
                                                               " From T_SousStation INNER Join T_Sites On T_SousStation.SiteId = T_Sites.SiteId" &
                                                               " Where T_Sites.SiteAdresseVille ='" & DdlVilles.SelectedValue & "'" &
                                                               " union Select 0,'Selectionner une sous station' , 0 from dual order by 3, 1")
        DdlSousStation.DataTextField = "Libelle"
        DdlSousStation.DataValueField = "Id"
        DdlSousStation.DataBind()
    End Sub

    Protected Sub InitGw()
        Dim Vreq As String = " SELECT str(R_SousStations_Prevoit_Actions.SousStationId) +';'+ str(R_SousStations_Prevoit_Actions.ActionId) as Id, T_Actions.ActionLibellé, R_SousStations_Prevoit_Actions.Frequence, " &
                             " R_SousStations_Prevoit_Actions.DPTO, R_SousStations_Prevoit_Actions.DPTA, R_SousStations_Prevoit_Actions.DerniereDateDeRealisation" &
                             " From R_SousStations_Prevoit_Actions INNER Join" &
                             " T_Actions On R_SousStations_Prevoit_Actions.ActionId = T_Actions.ActionId" &
                             " Where (R_SousStations_Prevoit_Actions.SousStationId ='" & DdlSousStation.SelectedValue & "')"
        GwActionParSousStation.DataSource = DataProvider.CreateDataSet(Vreq)
        GwActionParSousStation.DataBind()
    End Sub

    Protected Sub ZoomActionParSousStation(sender As Object, e As EventArgs)
        ' récupère la valeur de la propriété id
        Dim LnBouton As LinkButton = DirectCast(sender, LinkButton)
        Dim VIdRecupere = LnBouton.CommandArgument

        Response.Redirect("/Interventions/ActionSousStation.aspx?VIdRecupere=" & VIdRecupere)
    End Sub

    Protected Sub DdlVilles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlVilles.SelectedIndexChanged
        initDdlSousStation()
        Session("Ville") = DdlVilles.SelectedValue
    End Sub

    Protected Sub DdlSousStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlSousStation.SelectedIndexChanged
        Session("SousStationId") = DdlSousStation.SelectedValue
    End Sub
End Class
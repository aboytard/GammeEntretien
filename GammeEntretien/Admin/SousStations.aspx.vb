Public Class SousStations
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            initDdlVilles()
            If Not Session("VilleRecherche") Is Nothing Then
                DdlVilles.SelectedValue = Session("VilleRecherche")
            End If
        End If

        'MsgBox("ville du page load " & Session("VilleRecherche"))

        If Not Session("VilleRecherche") Is Nothing Then
            'DdlVilles.SelectedValue = Session("VilleRecherche")
        End If

        initGwSites()

    End Sub

    Protected Sub initGwSites()
        Dim Vreq As String = " SELECT SousStationId as Id, CodeSousStation, isnull(SiteAdresseVille,'') + ' ' +  SiteAdresse1 + ' ' + isnull(SiteAdresse2,'')  as Adresse, T_Sites.SiteId " &
                                  " FROM T_Sites INNER JOIN T_SousStation ON T_Sites.SiteId = T_SousStation.SiteId " &
                                  " Where SiteAdresseVille = '" & DdlVilles.SelectedValue & "'"
        GwSites.DataSource = DataProvider.CreateDataSet(Vreq)
        GwSites.DataBind()
    End Sub
    Protected Sub initDdlVilles()
        DdlVilles.DataSource = DataProvider.CreateDataSet("SELECT distinct SiteAdresseVille as ville FROM dbo.T_Sites order by 1")
        DdlVilles.DataTextField = "ville"
        DdlVilles.DataValueField = "ville"
        DdlVilles.DataBind()
    End Sub

    Protected Sub ZoomSite(ByVal sender As Object, ByVal e As EventArgs)
        'renvoie à la page de Gestion des Sous-Stations
        Dim LnBouton As LinkButton = DirectCast(sender, LinkButton)
        'MsgBox(LnBouton.CommandArgument)
        Dim VIdRecupere = LnBouton.CommandArgument

        'Response.Redirect("/Admin/SousStation.aspx?Id=" & VIdRecupere)
        ' J'initialise la varible session qui sera utilisé pour tout les formulaire "enfant"
        Dim st As C_SousStation = New C_SousStation(VIdRecupere)
        Session("MonSt") = st 'initialise une variable de session qui s'appelle MonSt
        Response.Redirect("/Admin/SousStation.aspx")

    End Sub

    Protected Sub CreerSousStations(sender As Object, e As EventArgs) Handles BtCreer.Click
        'MsgBox("CreerSousStations tourne bien")
        Response.Redirect("/Admin/SousStation.aspx?Id=0")
    End Sub

    Protected Sub DdlVilles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlVilles.SelectedIndexChanged
        ' MsgBox("DdlVilles_SelectedIndexChanged1 " & DdlVilles.SelectedValue)
        Session("VilleRecherche") = DdlVilles.SelectedValue
        ' MsgBox("DdlVilles_SelectedIndexChanged2 " & DdlVilles.SelectedValue)
    End Sub
End Class
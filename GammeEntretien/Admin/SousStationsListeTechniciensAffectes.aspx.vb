Public Class SousStationsListeTechniciensAffectes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'LbId.Text = Request.QueryString("Id")
            'Dim MonTECH As New C_Technicien(LbId.Text)
            ' remarqueBa N°4 : j'utilise la variable de session pour récupérer l'instance de technicien (voir initGw)


            'RemarqueBa N°5 : j'ai créé une fonction qui renvoie la requete pour alimenter une ddlSousStation
            ' de cette manière, je ne suis pas obligé de refaire la requete si je retrouve cette ddl dans
            ' plusieurs formulaire
            DdlTechniciens.DataSource = DataProvider.CreateDataSet(DdlTechniciensRequete())
            DdlTechniciens.DataTextField = "Libelle"
            DdlTechniciens.DataValueField = "Id"
            DdlTechniciens.DataBind()
            InitGw()
            Dim MonSt As C_SousStation
            Try
                MonSt = Session("MonSt")
            Catch ex As Exception
                MonSt = New C_SousStation()
            End Try
        End If

    End Sub

    Protected Sub InitGw()
        Dim MonSt As C_SousStation = Session("MonSt")
        GwTechniciensAffectes.DataSource = MonSt.ListeTechniciensAffectes(True)
        GwTechniciensAffectes.DataBind()
        LbRecap.Text = MonSt.text
    End Sub


    Protected Sub BtAjoutSousStation_Click(sender As Object, e As EventArgs) Handles BtAjoutSousStation.Click
        Dim MonSt As C_SousStation = Session("MonSt")
        MonSt.AjouterTechnicienAUneSousStation(DdlTechniciens.SelectedValue, LbMessage.Text)
        InitGw()
    End Sub

    Protected Sub BtRetour_Click(sender As Object, e As EventArgs) Handles BtRetour.Click
        Dim MonSt As C_SousStation = Session("MonSt")
        Dim IdDemande As Integer = MonSt.Id
        Response.Redirect("/Admin/SousStation.aspx?Id=" & IdDemande)
    End Sub
End Class
Public Class TechnicienSousStationAttribuer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'LbId.Text = Request.QueryString("Id")
            'Dim MonTECH As New C_Technicien(LbId.Text)
            ' remarqueBa N°4 : j'utilise la variable de session pour récupéer l'instance de technicien
            Dim MonTECH As C_Technicien = Session("MonTECH")
            GwTechnicienListeSousStationAttribuer.DataSource = MonTECH.ListeSousStationAttribuées(True)
            GwTechnicienListeSousStationAttribuer.DataBind()
            LbRecap.Text = MonTECH.text

            'RemarqueBa N°5 : j'ai créé une fonction qui renvoie la requete pour alimenter une ddlSousStation
            ' de cette manière, je ne suis pas obligé de refaire la requete si je retrouve cette ddl dans
            ' plusieurs formulaire
            DdlSousStation.DataSource = DataProvider.CreateDataSet(DdlSousStationRequete())
            DdlSousStation.DataTextField = "Libelle"
            DdlSousStation.DataValueField = "Id"
            DdlSousStation.DataBind()
        End If

    End Sub

    Protected Sub BtAjoutSousStation_Click(sender As Object, e As EventArgs) Handles BtAjoutSousStation.Click
        Dim MonTECH As C_Technicien = Session("MonTECH")
        MonTECH.AffecterUneSousStationAuTechnicien(DdlSousStation.SelectedValue, LbMessage.Text)
    End Sub
End Class
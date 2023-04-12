Public Class ActionSousStation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LbId.Text = Request.QueryString("VIdRecupere")
            Dim VSousStationId As Integer = Split(LbId.Text, ";")(0) ' récupère le integer avant le;
            Dim VActionId As Integer = Split(LbId.Text, ";")(1)
            Dim VId As Integer = VSousStationId & VActionId
            Try
                InitProprieteActionPourSousStation(VSousStationId, VActionId)
            Catch ex As Exception
                MsgBox("On a pas gardé les informations de la session")
            End Try
        End If
    End Sub


    Protected Sub InitProprieteActionPourSousStation(VSousStationId, VActionId)
        Dim ActionPourSousStation As C_Prevoir = New C_Prevoir(VSousStationId, VActionId)
        ActionPourSousStation.Id = ActionPourSousStation.SousStationId & ActionPourSousStation.ActionId
        TbFrequence.Text = ActionPourSousStation.Frequence
        TbDPTO.Text = ActionPourSousStation.DPTO
        TbDPTA.Text = ActionPourSousStation.DPTA
        TbDerniereDateDeRealisation.Text = ActionPourSousStation.DerniereDateDeRealisation
        TbDateDeCreation.Text = ActionPourSousStation.DateCreation
        Session("ActionPourSousStation") = ActionPourSousStation

    End Sub

    Protected Sub BtEnregistrer_Click(sender As Object, e As EventArgs) Handles BtEnregistrer.Click
        Dim MonActionPourSousStation As C_Prevoir = Session("ActionPourSousStation")
        MonActionPourSousStation.Update(TbFrequence.Text, TbDPTO.Text, TbDPTA.Text, TbDerniereDateDeRealisation.Text, LbMessage.Text)
    End Sub

    Protected Sub BtRetour_Click(sender As Object, e As EventArgs) Handles BtRetour.Click
        Response.Redirect("/Interventions/ActionsSousStations.aspx")
    End Sub
End Class
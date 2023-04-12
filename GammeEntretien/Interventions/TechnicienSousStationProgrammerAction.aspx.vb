Public Class TechnicienSousStationProgrammerAction
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LbId.Text = Request.QueryString("VIdRecupere")
            Dim VSousStationId As Integer = Split(LbId.Text, ";")(1) ' récupère le integer avant le;
            Dim VActionId As Integer = Split(LbId.Text, ";")(2)
            InitGwActionPrevisionnelleSousStation(VSousStationId, VActionId)
        End If
    End Sub

    Protected Sub BtEnregistrer_Click(sender As Object, e As EventArgs) Handles BtEnregistrer.Click
        'Dim MonActionPourSousStation As C_Prevoir = Session("ActionPourSousStation")
        'MonActionPourSousStation.Update(TbFrequence.Text, TbDPTO.Text, TbDPTA.Text, TbDerniereDateDeRealisation.Text, LbMessage.Text)
    End Sub

    Protected Sub BtRetour_Click(sender As Object, e As EventArgs) Handles BtRetour.Click
        'Response.Redirect("/Interventions/ActionsSousStations.aspx")
    End Sub

    Protected Sub InitGwActionPrevisionnelleSousStation(ByVal VidSousStation As Integer, ByVal VidAction As Integer)
        Dim Vreq As String = " SELECT SousStationId, ActionId, Frequence, DPTO, DPTA, DerniereDateDeRealisation, DateCreation" &
                            " From [GammeEntretien].[dbo].[R_SousStations_Prevoit_Actions]" &
                            " WHERE SousStationId ='" & VidSousStation & "'" &
                            " And ActionId = '" & VidAction & "'"
        GwActionPrevisionnelleSousStation.DataSource = DataProvider.CreateDataSet(Vreq)
        GwActionPrevisionnelleSousStation.DataBind()
    End Sub

End Class
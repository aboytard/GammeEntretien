Public Class SousStation
    Inherits System.Web.UI.Page

    Dim MonSt As C_SousStation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' remplcé les 5 lignes par
            'LbId.Text = Request.QueryString("Id")
            'If LbId.Text = "0" Or LbId.Text = "" Then
            '    '
            'Else
            '    InitFormulaire()
            'End If

            Try
                MonSt = Session("MonSt")
            Catch ex As Exception
                MonSt = New C_SousStation()
            End Try


            Try
                InitFormulaire()
                'MsgBox("initformulaire tourne bien")
            Catch ex As Exception
                'MsgBox("problème initformulaire")
            End Try


            InitDdl()


        End If

        'PnSite.Visible = (LbId.Text <> 0)
        'If LbId.Text=0 Then
        '    PnSite.Visible = False
        'Else
        '    PnSite.Visible = True

        'End If

    End Sub

    Protected Sub InitFormulaire()
        'Dim st As C_SousStation = New C_SousStation(LbId.Text)
        'Session("MonSt") = st 'initialise une variable de session qui s'appelle MonSt
        'MsgBox("MonSt.Id =" & MonSt.Id)
        'Affiche le contenu de la variable de session.
        'Response.Write(Session("MonSt"))
        LbId.Text = MonSt.Id
        TbCodeSousStation.Text = MonSt.CodeSousStations
        TbLibelle.Text = MonSt.Libelle
        TbSiteId.Text = MonSt.SiteId
        TbAdresse1.Text = MonSt.Adresse1
        TbAdresse2.Text = MonSt.Adresse2
        TbVille.Text = MonSt.ville
        TbCodePostal.Text = MonSt.Cp
        DdlRex.SelectedValue = MonSt.RexId
        DdlTechnicien.SelectedValue = MonSt.TechnicienId 'Technicien de référence pour un site
        LbMessage.Text = MonSt.Message
        Dim Identifiant As Integer
        MsgBox("MonSt.Id = " & Identifiant = MonSt.Id)
    End Sub

    Protected Sub InitDdl()
        Dim VReq As String = "SELECT RexId as Id, RexNom as Libelle, 1  FROM GammeEntretien.dbo.T_Rex " &
                            " union Select 0, 'Sélectionner un Rex ', 0 from dual order by 3, 2"
        DdlRex.DataSource = DataProvider.CreateDataSet(VReq)
        DdlRex.DataValueField = "Id"
        DdlRex.DataTextField = "Libelle"
        DdlRex.DataBind()

        Dim VReq1 As String = "SELECT TechnicienId as Id, TechnicienNom as Libelle, 1 FROM GammeEntretien.dbo.T_Technicien " &
                             " union Select 0, 'Sélectionner un Technicien ', 0 from dual order by 3, 2"
        DdlTechnicien.DataSource = DataProvider.CreateDataSet(VReq1)
        DdlTechnicien.DataValueField = "Id"
        DdlTechnicien.DataTextField = "Libelle"
        DdlTechnicien.DataBind()


    End Sub

    Protected Sub BtRetour_Click(sender As Object, e As EventArgs) Handles BtRetour.Click
        Response.Redirect("/Admin/SousStations.aspx")
    End Sub

    Protected Sub BtEnregistrer_Click(sender As Object, e As EventArgs) Handles BtEnregistrer.Click
        If (LbId.Text = 0) Then
            LbId.Text = C_SousStation.Insert(TbLibelle.Text, TbCodeSousStation.Text, TbSiteId.Text, LbMessage.Text)
        Else
            'Dim St As C_SousStation = New C_SousStation(LbId.Text)
            'MsgBox("Dans la fonction BtEnregistrer, pas de problème avant update")
            'MsgBox("Les variables que l'on va utiliser: TbLibelle.Text = " & TbLibelle.Text & " TbCodeSousStation.Text = " & TbCodeSousStation.Text & " TbSiteId.Text = " & TbSiteId.Text & " LbMessage.Text = " & LbMessage.Text)
            MonSt.Update(TbLibelle.Text, TbCodeSousStation.Text, TbSiteId.Text, LbMessage.Text)
        End If




    End Sub

    Private Sub BtSupprimer_Click(sender As Object, e As EventArgs) Handles BtSupprimer.Click
        'Dim St As C_SousStation = Session("MonSt")
        MonSt.delete(LbMessage.Text)
    End Sub

    Protected Sub LkListeActionsAPrevoir_Click(sender As Object, e As EventArgs) Handles LkListeActionsAPrevoir.Click
        'Response.Redirect("/Admin/SousStationActionsPrevisionnelles.aspx?Id=" & LbId.Text)
        Response.Redirect("/Admin/SousStationActionsPrevisionnelles.aspx")

    End Sub

    Protected Sub LkListeTechniciens_Click(sender As Object, e As EventArgs) Handles LkListeTechniciens.Click
        Response.Redirect("/Admin/SousStationsListeTechniciensAffectes.aspx")

    End Sub
End Class
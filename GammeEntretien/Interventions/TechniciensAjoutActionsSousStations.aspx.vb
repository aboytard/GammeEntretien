Public Class TechniciensAjoutActionsSousStations
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LbId.Text = Request.QueryString("VIds")
            InitDdlGamme()
            InitDdlSecteur()
            InitDdlAction()
            Try


                ' InitGw()
            Catch ex As Exception
                '
            End Try

        End If

    End Sub



    'A utiliser

    '    INSERT INTO [dbo].[R_TechnicienAction_Programmer_SousStation] (TechnicienId, SousStationId, ActionId)
    'Select Case TechnicienId, SousStationId, 12 FROM     R_SousStation_SuiviPar_Techniciens 
    'GO



    Protected Sub InitDdlGamme()
        DdlGamme.DataSource = DataProvider.CreateDataSet("SELECT distinct GammeId as Id ,GammeLibellé as Libelle, GammeDescription FROM dbo.T_Gammes" &
                                                 " Union Select 0, 'Sélectionnez une gamme ', 0 from dual order by 1, 2 ")
        DdlGamme.DataTextField = "Libelle"
        DdlGamme.DataValueField = "Id"
        DdlGamme.DataBind()
    End Sub

    Protected Sub InitDdlSecteur()
        DdlSecteur.DataSource = DataProvider.CreateDataSet("SELECT SecteurId as Id, SecteurLibellé as Libelle,1  FROM GammeEntretien.dbo.T_Secteurs " &
                             " WHERE T_Secteurs.Secteur_GammeId = '" & DdlGamme.SelectedValue & "'" &
                             " union Select 0, 'Sélectionner un Secteur ',0 from dual order by 1, 2")
        DdlSecteur.DataTextField = "Libelle"
        DdlSecteur.DataValueField = "Id"
        DdlSecteur.DataBind()

    End Sub

    Protected Sub InitDdlAction()
        DdlAction.DataSource = DataProvider.CreateDataSet(" SELECT ActionId as Id, ActionLibellé as Libelle " &
                             " FROM dbo.T_Actions" &
                             " WHERE Action_SecteurId = '" & DdlSecteur.SelectedValue & "'" &
                             " union select 0,'Selectionner une action' from dual order by 1,2")
        DdlAction.DataTextField = "Libelle"
        DdlAction.DataValueField = "Id"
        DdlAction.DataBind()
    End Sub

    Protected Sub BtRetour_Click(sender As Object, e As EventArgs) Handles BtRetour.Click
        Response.Redirect("/Interventions/TechniciensActionsSousStations.aspx?")
    End Sub

    Protected Sub DdlSecteur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlSecteur.SelectedIndexChanged
        InitDdlAction()
    End Sub

    Protected Sub DdlGamme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlGamme.SelectedIndexChanged
        InitDdlSecteur()
    End Sub

    Protected Sub DdlAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlAction.SelectedIndexChanged
        Dim VSousStationId As Integer = Split(LbId.Text, ";")(0) ' récupère le integer avant le;
        Dim VTechnicienId As Integer = Split(LbId.Text, ";")(1)
        Dim VActionId As Integer = DdlAction.SelectedValue
        Dim ActionPourUnTechnicienSurUneSousStation As C_Programmer = New C_Programmer(VTechnicienId, VSousStationId, VActionId)
        Session("ActionPourUnTechnicienSurUneSousStation") = ActionPourUnTechnicienSurUneSousStation
        ActionPourUnTechnicienSurUneSousStation.Id = VTechnicienId & VSousStationId & VActionId
        InitGwProgrammer(VTechnicienId, VSousStationId, VActionId)

    End Sub

    Protected Sub InitGwProgrammer(ByVal VIdTechicien As Integer, ByVal VIdSousStation As Integer, ByVal VIdAction As Integer)
        Dim Vreq As String = " SELECT str(R_TechnicienAction_Programmer_SousStation.TechnicienId) + ';' +  str(R_TechnicienAction_Programmer_SousStation.SousStationId) + ';' + str(R_TechnicienAction_Programmer_SousStation.ActionId) as Id," &
         " R_TechnicienAction_Programmer_SousStation.ActionId, T_Actions.ActionLibellé, R_TechnicienAction_Programmer_SousStation.DateRealisation, R_TechnicienAction_Programmer_SousStation.Commentaire, " &
         " R_TechnicienAction_Programmer_SousStation.DatePrevisionnel, R_TechnicienAction_Programmer_SousStation.DateCreation" &
         " FROM R_TechnicienAction_Programmer_SousStation INNER JOIN" &
         " T_Actions ON R_TechnicienAction_Programmer_SousStation.ActionId = T_Actions.ActionId INNER JOIN" &
         " T_SousStation ON R_TechnicienAction_Programmer_SousStation.SousStationId = T_SousStation.SousStationId INNER JOIN" &
         " T_Technicien ON R_TechnicienAction_Programmer_SousStation.TechnicienId = T_Technicien.TechnicienId" &
                     " WHERE R_TechnicienAction_Programmer_SousStation.SousStationId = '" & VIdSousStation & "'" &
                     " AND R_TechnicienAction_Programmer_SousStation.TechnicienId = '" & VIdTechicien & "'" &
                     " AND R_TechnicienAction_Programmer_SousStation.ActionId = '" & VIdAction & "'"
        GwProgrammer.DataSource = DataProvider.CreateDataSet(Vreq)
        GwProgrammer.DataBind()

    End Sub

    Protected Sub ZoomProgrammerAction(sender As Object, e As EventArgs)
        Dim LnBouton As LinkButton = DirectCast(sender, LinkButton)
        Dim VIdRecupere = LnBouton.CommandArgument
    End Sub

End Class
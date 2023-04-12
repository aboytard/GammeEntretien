Public Class TechniciensActionsSousStations
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            initDdlRex()
            initDdlTechnicien()
            InitDdlVilles()
            initDdlSousStation()
        End If
        InitGwActionParSousStationPourUnTechnicienDonne()
    End Sub

    Protected Sub initDdlRex()
        Dim Vreq As String = "SELECT distinct RexId as Id, RexNom as Libelle, RexDescription, Rex_RaId FROM GammeEntretien.dbo.T_Rex" &
                             " union Select 0,'Selectionner un Rex','0',0 order by 1,2 "
        DdlREX.DataSource = DataProvider.CreateDataSet(Vreq)
        DdlREX.DataTextField = "Libelle"
        DdlREX.DataValueField = "Id"
        DdlREX.DataBind()
    End Sub

    Protected Sub initDdlTechnicien()
        Dim Vreq As String = "SELECT TechnicienId as Id, Technicien_RexId, TechnicienNom as Libelle, TechnicienDescription FROM [dbo].[T_Technicien]" &
                             " WHERE Technicien_RexId = '" & DdlREX.SelectedValue & "'" &
                             "union Select 0,0,'Selectionner un Technicien','0' from dual order by 1,2"
        DdlTechnicien.DataSource = DataProvider.CreateDataSet(Vreq)
        DdlTechnicien.DataTextField = "Libelle"
        DdlTechnicien.DataValueField = "Id"
        DdlTechnicien.DataBind()
    End Sub

    Protected Sub DdlREX_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlREX.SelectedIndexChanged
        initDdlTechnicien()
    End Sub

    Protected Sub InitDdlVilles()
        Dim Vreq As String = "SELECT 1 ,T_Sites.SiteAdresseVille as ville From R_SousStation_SuiviPar_Techniciens INNER Join" &
                  " T_SousStation On R_SousStation_SuiviPar_Techniciens.SousStationId = T_SousStation.SousStationId INNER Join" &
                  " T_Sites On T_SousStation.SiteId = T_Sites.SiteId INNER Join" &
                  " T_Technicien On R_SousStation_SuiviPar_Techniciens.TechnicienId = T_Technicien.TechnicienId" &
                  " Where R_SousStation_SuiviPar_Techniciens.TechnicienId ='" & DdlTechnicien.SelectedValue & "'" &
                  " union Select 0, 'Selectionner une ville' from dual order by 1,2"
        DdlVilles.DataSource = DataProvider.CreateDataSet(Vreq)
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

    Protected Sub DdlVilles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlVilles.SelectedIndexChanged
        initDdlSousStation()
    End Sub

    Protected Sub InitGwActions()
        Dim Vreq As String = " SELECT R_TechnicienAction_Programmer_SousStation.TechnicienId, R_TechnicienAction_Programmer_SousStation.SousStationId, R_TechnicienAction_Programmer_SousStation.ActionId, T_Actions.ActionLibellé, " &
                            " R_TechnicienAction_Programmer_SousStation.DateRealisation, R_TechnicienAction_Programmer_SousStation.Commentaire" &
                            " From R_TechnicienAction_Programmer_SousStation INNER Join T_Actions On R_TechnicienAction_Programmer_SousStation.ActionId = T_Actions.ActionId INNER Join T_SousStation On R_TechnicienAction_Programmer_SousStation.SousStationId = T_SousStation.SousStationId INNER Join" &
                            " T_Technicien On R_TechnicienAction_Programmer_SousStation.TechnicienId = T_Technicien.TechnicienId" &
                            " Where "
    End Sub

    Protected Sub AttribuerUneActionAUnTechnicienPourUneSousStation()
        Dim VIds As String = (DdlSousStation.SelectedValue).ToString & ";" & (DdlTechnicien.SelectedValue).ToString

        Response.Redirect("/Interventions/TechniciensAjoutActionsSousStations.aspx?VIds=" & VIds)
    End Sub

    Protected Sub DdlTechnicien_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlTechnicien.SelectedIndexChanged
        InitDdlVilles()
    End Sub

    Protected Sub InitGwActionParSousStationPourUnTechnicienDonne()
        Dim Vreq As String = " SELECT str(R_TechnicienAction_Programmer_SousStation.TechnicienId) + ';' +  str(R_TechnicienAction_Programmer_SousStation.SousStationId) + ';' + str(R_TechnicienAction_Programmer_SousStation.ActionId) as Id," &
                            " R_TechnicienAction_Programmer_SousStation.ActionId, T_Actions.ActionLibellé, R_TechnicienAction_Programmer_SousStation.DateRealisation, R_TechnicienAction_Programmer_SousStation.Commentaire," &
                            " R_TechnicienAction_Programmer_SousStation.DatePrevisionnel, R_TechnicienAction_Programmer_SousStation.DateCreation" &
                            " From R_TechnicienAction_Programmer_SousStation INNER Join" &
                            " T_Actions On R_TechnicienAction_Programmer_SousStation.ActionId = T_Actions.ActionId INNER Join" &
                            " T_SousStation On R_TechnicienAction_Programmer_SousStation.SousStationId = T_SousStation.SousStationId INNER Join" &
                            " T_Technicien On R_TechnicienAction_Programmer_SousStation.TechnicienId = T_Technicien.TechnicienId" &
                            " Where R_TechnicienAction_Programmer_SousStation.SousStationId ='" & DdlSousStation.SelectedValue & "'" &
                            " And R_TechnicienAction_Programmer_SousStation.TechnicienId ='" & DdlTechnicien.SelectedValue & "'"
        GwActionParSousStationPourUnTechnicienDonne.DataSource = DataProvider.CreateDataSet(Vreq)
        GwActionParSousStationPourUnTechnicienDonne.DataBind()
    End Sub

    Protected Sub ZoomActionPourUnTechnicienSousStation(sender As Object, e As EventArgs)
        Dim LnBouton As LinkButton = DirectCast(sender, LinkButton)
        Dim VIdRecupere = LnBouton.CommandArgument
        MsgBox("VIdRecupere = " & VIdRecupere)
        MsgBox("VIdRecupere = " & VIdRecupere)
        Response.Redirect("/Interventions/TechnicienSousStationProgrammerAction.aspx?VIdRecupere= " & VIdRecupere)
    End Sub
End Class
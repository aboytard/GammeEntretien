Public Class Techniciens
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            initDdlRex()
        End If
        initGwTechnicien()
    End Sub

    Protected Sub initGwTechnicien()
        Dim Vreq As String = "SELECT TechnicienId as id, Technicien_RexId, TechnicienNom, TechnicienDescription FROM T_Technicien" &
                             " WHERE Technicien_RexId = '" & DdlRex.SelectedValue & "'"
        GwTechnicien.DataSource = DataProvider.CreateDataSet(Vreq)
        GwTechnicien.DataBind()
    End Sub

    Protected Sub initDdlRex()
        DdlRex.DataSource = DataProvider.CreateDataSet("SELECT distinct RexId, RexNom, RexDescription, Rex_RaId FROM GammeEntretien.dbo.T_Rex")
        DdlRex.DataTextField = "RexNom"
        DdlRex.DataValueField = "RexId"
        DdlRex.DataBind()
    End Sub

    Protected Sub CreerTechnicien(sender As Object, e As EventArgs) Handles BtCreer.Click
        Response.Redirect("/Admin/Technicien.aspx?Id=0")
    End Sub

    Protected Sub ZoomTechnicien(sender As Object, e As EventArgs)
        'renvoie à la page de Gestion des Sous-Stations
        Dim LnBouton As LinkButton = DirectCast(sender, LinkButton)
        'MsgBox(LnBouton.CommandArgument)
        Dim VIdRecupere = LnBouton.CommandArgument
        Response.Redirect("/Admin/Technicien.aspx?Id=" & VIdRecupere)
    End Sub

End Class
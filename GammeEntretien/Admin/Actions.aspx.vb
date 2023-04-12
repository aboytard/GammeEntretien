Public Class Actions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Not Session("ActionGamme") Is Nothing Then
                DdlGamme.SelectedValue = Session("ActionGamme")
            End If
            If Not Session("MonSecteur") Is Nothing Then
                DdlSecteur.SelectedValue = Session("MonSecteur")
            End If
            initDdlGamme()
            initDdlSecteur()
        End If

        initGwAction()
    End Sub

    Protected Sub initDdlGamme()
        DdlGamme.DataSource = DataProvider.CreateDataSet("SELECT distinct GammeId as Id ,GammeLibellé as Libelle, GammeDescription FROM dbo.T_Gammes" &
                                                         " Union Select 0, 'Sélectionnez une gamme ', 0 from dual order by 1, 2 ")
        DdlGamme.DataTextField = "Libelle"
        DdlGamme.DataValueField = "Id"
        DdlGamme.DataBind()
    End Sub

    Protected Sub initDdlSecteur()
        DdlSecteur.DataSource = DataProvider.CreateDataSet(" SELECT SecteurId as Id, SecteurLibellé as Libelle, 1 FROM GammeEntretien.dbo.T_Secteurs" &
                                                           " WHERE T_Secteurs.Secteur_GammeId ='" & DdlGamme.SelectedValue & "'" &
                                                           " Union Select 0, 'Sélectionnez un secteur ', 0 from dual order by 3, 2 ")
        DdlSecteur.DataTextField = "Libelle"
        DdlSecteur.DataValueField = "Id"
        DdlSecteur.DataBind()
    End Sub

    Protected Sub initGwAction()
        Dim Vreq As String = "SELECT ActionId as Id, ActionLibellé, ActionDescription, ActionFrequence ,Action_SecteurId FROM dbo.T_Actions" &
                             " WHERE T_Actions.Action_SecteurId = '" & DdlSecteur.SelectedValue & "'"
        GwAction.DataSource = DataProvider.CreateDataSet(Vreq)
        GwAction.DataBind()
    End Sub

    Protected Sub CreerAction(sender As Object, e As EventArgs) Handles BtCreer.Click
        Response.Redirect("/Admin/Action.aspx?Id=0")
    End Sub

    Protected Sub ZoomAction(sender As Object, e As EventArgs)
        Dim LnBouton As LinkButton = DirectCast(sender, LinkButton)
        Dim VIdRecupere = LnBouton.CommandArgument
        Response.Redirect("/Admin/Action.aspx?Id=" & VIdRecupere)
    End Sub

    Protected Sub DdlGamme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlGamme.SelectedIndexChanged
        'Dim ActionGamme As C_Action = Session("ActionGamme")
        Session("ActionGamme") = DdlGamme.SelectedValue
        initDdlSecteur()
    End Sub

    Protected Sub DdlSecteur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DdlSecteur.SelectedIndexChanged
        'Dim ActionSecteur As C_Action = Session("ActionSecteur")
        Session("MonSecteur") = DdlSecteur.SelectedValue
    End Sub
End Class
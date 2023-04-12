Public Class Action
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LbId.Text = Request.QueryString("Id")
            If LbId.Text = "0" Or LbId.Text = "" Then
                Session("MonAction") = New C_Action()
            Else
                InitFormulaire()
            End If
        End If
    End Sub

    Protected Sub InitFormulaire()
        Dim Action As C_Action = New C_Action(LbId.Text)
        Session("MonAction") = Action 'initialise une variable de session qui s'appelle Action
        TbLibelle.Text = Action.ActionLibelle
        TbFrequence.Text = Action.ActionFrequence
        TbDescription.Text = Action.ActionDescription
        TbSecteurId.Text = Action.Action_SecteurId
        TbSecteurLibelle.Text = Action.SecteurLibelle
        TbGammeId.Text = Action.Secteur_GammeId
        TbGammeLibelle.Text = Action.GammeLibelle
        LbMessage.Text = Action.Message
        Session("ActionGamme") = TbGammeId.Text
        Session("MonSecteur") = TbSecteurId.Text
        'MsgBox("Session(MonSecteur) =" & TbSecteurId.Text)
    End Sub



    Protected Sub BtRetour_Click(sender As Object, e As EventArgs) Handles BtRetour.Click
        'MsgBox("on a bien lancé la fonction du bouton retour")
        'Dim ActionGamme As C_Action = Session("ActionGamme")
        'MsgBox("Session Gamme Secteur =" & ActionGamme.Secteur_GammeId & ActionGamme.Action_SecteurId)
        ' Session("ActionSecteur") = TbSecteurId.Text INUTILE??
        Response.Redirect("/Admin/Actions.aspx")
    End Sub

    Protected Sub BtEnregistrer_Click(sender As Object, e As EventArgs) Handles BtEnregistrer.Click
        If (LbId.Text = 0) Then
            Dim MonAction As C_Action = Session("MonAction")
            MonAction.Insert(TbLibelle.Text, TbDescription.Text, TbFrequence.Text, TbSecteurId.Text, LbMessage.Text)
            LbId.Text = MonAction.Id
        Else
            '    'Dim MonTECH As C_Technicien = New C_Technicien(LbId.Text)
            '    ' remarqueBa N°2 : pas besoin de recharger MonTech car il a été mémorisé dans Session("MonTECH")
            Dim MonAction As C_Action = Session("MonAction")
            MonAction.Update(TbLibelle.Text, TbDescription.Text, TbFrequence.Text, TbSecteurId.Text, LbMessage.Text)
            LbId.Text = MonAction.Id
        End If

    End Sub

    Protected Sub BtSupprimer_Click(sender As Object, e As EventArgs) Handles BtSupprimer.Click
        Dim MonAction As C_Action = Session("MonAction") 'voir si on peut enlever cette ligne car on a déjà déclaré la 
        'variable de session dans la méthode initformulaire()
        MonAction.delete(LbMessage.Text)
    End Sub

    Protected Sub LkListeActionsAPrevoir_Click(sender As Object, e As EventArgs) Handles LkListeActionsAPrevoir.Click
        Response.Redirect("/Admin/ActionSousStationAffecte.aspx")
    End Sub
End Class
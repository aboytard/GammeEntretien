Public Class Technicien
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LbId.Text = Request.QueryString("Id")
            If LbId.Text = "0" Or LbId.Text = "" Then
                '
            Else
                InitFormulaire()
            End If
        End If
    End Sub

    Protected Sub BtRetour_Click(sender As Object, e As EventArgs) Handles BtRetour.Click
        Response.Redirect("/Admin/Techniciens.aspx")
    End Sub

    Protected Sub InitFormulaire()
        Dim TECH As C_Technicien = New C_Technicien(LbId.Text)
        Session("MonTECH") = TECH 'initialise une variable de session qui s'appelle MonTECH
        TbTechnicienNom.Text = TECH.TechnicienNom
        TbTechnicienDescription.Text = TECH.TechnicienDescription
        TbRexId.Text = TECH.RexId
        TbRexNom.Text = TECH.RexNom
        LbMessage.Text = TECH.Message
    End Sub

    Protected Sub BtEnregistrer_Click(sender As Object, e As EventArgs) Handles BtEnregistrer.Click
        If (LbId.Text = 0) Then
            LbId.Text = C_Technicien.Insert(TbTechnicienNom.Text, TbTechnicienDescription.Text, TbRexId.Text, LbMessage.Text)
        Else
            'Dim MonTECH As C_Technicien = New C_Technicien(LbId.Text)
            ' remarqueBa N°2 : pas besoin de recharger MonTech car il a été mémorisé dans Session("MonTECH")
            Dim MonTECH As C_Technicien = Session("MonTECH")
            MonTECH.Update(TbTechnicienNom.Text, TbTechnicienDescription.Text, TbRexId.Text, LbMessage.Text)
        End If

    End Sub

    Protected Sub BtSupprimer_Click(sender As Object, e As EventArgs) Handles BtSupprimer.Click
        Dim MonTECH As C_Technicien = Session("MonTECH")
        MonTECH.delete(LbMessage.Text)
    End Sub

    Protected Sub LkListeSousStationAAtribuer_Click(sender As Object, e As EventArgs) Handles LkListeSousStationAAtribuer.Click
        ' Response.Redirect("/Admin/TechnicienSousStationAttribuer.aspx?Id=" & LbId.Text)
        ' remarqueBa N°3 : MonTech a été mémorisé dans Session("MonTECH"), on pourra le récupérer dans le formulaire appelé
        ' donc plus besoin de mettre ?Id=" & LbId.Text 
        ' voir dans load de la page TechnicienSousStationAttribuer.aspx comment on récupère Session("MonTECH")
        Response.Redirect("/Admin/TechnicienSousStationAttribuer.aspx")
    End Sub

End Class
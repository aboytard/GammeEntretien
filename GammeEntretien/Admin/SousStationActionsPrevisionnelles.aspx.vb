Public Class SousStationActionsPrevisionnelles
    Inherits System.Web.UI.Page

    Dim MonSt As C_SousStation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'LbId.Text = Request.QueryString("Id")
            'Dim st As New C_SousStation(LbId.Text)
            ' remarqueBa N°4 : j'utilise la variable de session pour récupérer l'instance de technicien (voir initGw)
            Try
                MonSt = Session("MonSt")
            Catch ex As Exception
                MonSt = New C_SousStation()
            End Try


            Dim VReq2 As String = DdlSecteursRequete()
            DdlSecteurs.DataSource = DataProvider.CreateDataSet(VReq2)
            DdlSecteurs.DataValueField = "Id"
            DdlSecteurs.DataTextField = "Libelle"
            DdlSecteurs.DataBind()

            InitGw()
        End If
    End Sub

    Protected Sub InitGw()
        'Dim MonSt As C_SousStation = Session("MonSt")
        GwStlisteActionsPrevisionnelles.DataSource = MonSt.ListeActionsPrevisionnelle(True)
        GwStlisteActionsPrevisionnelles.DataBind()
        LbRecap.Text = MonSt.text
    End Sub

    Protected Sub BtAjoutActionsSousSecteur_Click(sender As Object, e As EventArgs) Handles BtAjoutActionsSousSecteur.Click
        MonSt = Session("MonSt")
        MonSt.AjouterActionsDunSecteur(DdlSecteurs.SelectedValue, LbMessage.Text)
        InitGw()
    End Sub

    Protected Sub BtRetour_Click(sender As Object, e As EventArgs) Handles BtRetour.Click
        MonSt = Session("MonSt")
        Dim IdDemande As Integer = MonSt.Id
        Response.Redirect("/Admin/SousStation.aspx?Id=" & IdDemande)
    End Sub
End Class
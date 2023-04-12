Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridView1.DataSource = From st In C_SousStation.SousStations("toto")
                               Where st.ville = "PARIS 19"
                               Select st.Id, st.ville, st.Adresse1

        GridView1.DataBind()
    End Sub

End Class
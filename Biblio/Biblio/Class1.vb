Imports System.Data
Imports System.Data.SqlClient


Public Class DataProvider

    Public Shared Property _Activertrace As Boolean = False

    Public Shared Function CreateConnection() As SqlConnection
        Try
            Dim connection As New SqlConnection
            'connection.ConnectionString = "Data Source = 10.1.0.92,1433; Initial Catalog = Referentiel;User ID=sa;Password=5Q13xpR3ss;Initial Catalog=FacturationLa"
            ' connection.ConnectionString = "Data Source=.\SQLEXPRESS;Password=117rdc6rgb;Persist Security Info=true;User ID=sa;Initial Catalog=FacturationLa"

            connection.ConnectionString = ConfigurationManager.ConnectionStrings("GammesEntretien").ConnectionString
            connection.Open()
            Return connection
        Catch ex As Exception
            MsgBox(" problème open connection : " & ex.Message)
        End Try
    End Function

    Public Shared Function CreateCommand(commandText As String) As SqlCommand
        Dim command As SqlCommand = CreateConnection().CreateCommand()
        command.CommandText = commandText

        Return command
    End Function

    Public Shared Function CreateDataReader(commandText As String) As SqlDataReader
        ' après execution, la connection est fermée
        Return CreateCommand(commandText).ExecuteReader(System.Data.CommandBehavior.CloseConnection)
    End Function

    Public Shared Function CreateDataReader(command As SqlCommand) As SqlDataReader
        ' après execution, la connection est fermée
        Return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
    End Function

    Public Shared Function CreateDataSet(commandText As String) As DataSet
        ' après execution, la connection est fermée
        Try
            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = CreateCommand(commandText)
            Dim ds As New DataSet()
            adapter.Fill(ds)
            adapter.SelectCommand.Connection.Close()

            Return ds
        Catch ex As Exception
            MsgBox("erreur CreateDataSet " & commandText & " : " & ex.Message)
            Return Nothing

        Finally
            ' déplacer ici : adapter.SelectCommand.Connection.Close()
        End Try

    End Function

    Public Shared Function CreateDataSet(command As SqlCommand, ByVal CloseConnection As Boolean) As DataSet
        ' après execution, la connection est fermée si CloseConnection est true ou reste ouverte si false
        ' permet d'enchainer plusieurs requetes sur une même commande sans fermer la connection
        Try

            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = command

            Dim ds As New DataSet()
            adapter.Fill(ds)
            If CloseConnection Then
                adapter.SelectCommand.Connection.Close()
            End If
            Return ds
        Catch ex As Exception
            MsgBox("erreur CreateDataSet avec close " & command.CommandText & " : " & ex.Message)
            Return Nothing
        End Try

    End Function

    Public Shared Function ExecuteScalarInteger(commandText As String) As Integer
        ' après execution, la connection est fermée
        Try
            Return CType(CreateCommand(commandText).ExecuteScalar, Integer)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function ExecuteScalarTexte(commandText As String) As String
        Try
            Return CType(CreateCommand(commandText).ExecuteScalar, String)
        Catch ex As Exception
            Return ""
            'Return "Erreur ExecuteScalarTexte " & ex.Message
        End Try
    End Function

    Public Shared Function ExecuteScalarInteger(ByVal command As SqlCommand) As Integer
        Try
            Return CType(command.ExecuteScalar, Integer)
        Catch ex As Exception
            Return 0

        Finally
            'fermeture de la connexion ?

        End Try
    End Function
    Public Shared Function ExecuteScalarTexte(ByVal command As SqlCommand) As String
        Try
            Return CType(command.ExecuteScalar, String)
        Catch ex As Exception
            Return "Erreur ExecuteScalarTexte " & ex.Message
        End Try
    End Function

End Class



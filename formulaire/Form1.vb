Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Form1
    Dim con As New SqlClient.SqlConnection
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = "Data Source=RAMI\SQLEXPRESS;Initial Catalog=Client;Integrated Security=True"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Champs obligatoires doivent être rempli", vbInformation)
        Else
            Dim pas As String
            pas = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
            If Regex.IsMatch(TextBox4.Text, pas) Then
                con.Open()
                Dim com As New SqlClient.SqlCommand
                com.Connection = con
                com.CommandText = "INSERT INTO inscription VALUES ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')"
                com.ExecuteNonQuery()
                com.Dispose()
                con.Close()
                MsgBox("New Record", vbInformation)
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
            Else
                MsgBox("l'adresse email doit etre  ****@**.***", vbInformation)
            End If


        End If

    End Sub
End Class
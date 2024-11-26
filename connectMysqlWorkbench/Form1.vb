Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim connectionString As String = "Server=localhost;Database=dbuser;Uid=root;Pwd=12Yellow34!;"

        ' Create a connection to the database
        Using connection As New MySqlConnection(connectionString)
            Try
                ' Open the connection
                connection.Open()

                ' SQL query to retrieve all records from tbluser
                Dim query As String = "SELECT * FROM tbluser"

                ' Create a command object
                Dim command As New MySqlCommand(query, connection)

                ' Execute the query and read the results
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Display column names and data in a TextBox or Console
                    While reader.Read()
                        Dim rowData As String = ""
                        For i As Integer = 0 To reader.FieldCount - 1
                            rowData &= $"{reader.GetName(i)}: {reader.GetValue(i).ToString()}  "
                        Next
                        ' Output each row (e.g., to a TextBox or Debug Console)
                        Console.WriteLine(rowData)
                    End While
                End Using

            Catch ex As Exception
                ' Handle connection or query errors
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

    End Sub
End Class

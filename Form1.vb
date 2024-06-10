Public Class Form1

    Private Property Blot As Boolean = False
    Private Property LastSize As Size = Nothing
    Private Property LastLocation As Point = Nothing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Blot Then
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.Location = LastLocation
            Me.Size = LastSize

            Blot = False
        Else
            For Each scr As Screen In Screen.AllScreens
                If scr.Bounds.Contains(Me.Location) Then
                    LastSize = Me.Size
                    LastLocation = Me.Location

                    Me.FormBorderStyle = FormBorderStyle.None
                    Me.Location = scr.Bounds.Location
                    Me.Size = scr.Bounds.Size

                    Blot = True
                    Exit For
                End If
            Next
        End If
    End Sub
End Class

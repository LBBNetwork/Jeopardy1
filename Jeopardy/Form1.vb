Imports System.Windows.Forms.Control.ControlCollection
Public Class Form1
    Public Shared GlobalScoreP1 As Integer
    Public Shared GlobalScoreP2 As Integer
    Public Shared GlobalScoreP3 As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim screen As Screen

        Try
            screen = Screen.AllScreens(1)
            Me.Location = screen.Bounds.Location + New Point(0, 0)
        Catch ex As Exception
            screen = screen.AllScreens(0)
            Me.Location = screen.Bounds.Location + New Point(0, 0)
        End Try

        QuestionPic.Image = New System.Drawing.Bitmap("data\cards\Splash.png")

        mcp.Show()
        LogWindow.Show()

        For ClearLine As Integer = 1 To 36
            Dim formLabel As Label = CType(Me.Controls("Label" & ClearLine), Label)
            formLabel.Text = ""
        Next
        'QuestionPic.Image = New System.Drawing.Bitmap("C:\Users\neko\Pictures\5lumbc.jpg")
        ' QuestionPic.Visible = False 'Tickle the stable branch; see what happens
    End Sub
End Class

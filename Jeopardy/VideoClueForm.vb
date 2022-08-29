Public Class VideoClueForm

    Public Shared VideoClueURI As String
    Public Sub New(VidURI As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        VideoClueURI = VidURI
    End Sub
    Private Sub VideoClueForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VideoClue.uiMode = "none"

        Dim screen As Screen

        Try
            screen = Screen.AllScreens(1)
            Me.Location = screen.Bounds.Location + New Point(0, 0)
        Catch ex As Exception
            screen = Screen.AllScreens(0)
            Me.Location = screen.Bounds.Location + New Point(0, 0)
        End Try

        VideoClue.URL = VideoClueURI
        VideoClue.Ctlcontrols.play()
    End Sub

    Public Sub VideoClue_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles VideoClue.PlayStateChange
        Select Case e.newState
            Case 1 ' stopped
                Close()
        End Select
    End Sub
End Class
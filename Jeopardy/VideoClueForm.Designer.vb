<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoClueForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VideoClueForm))
        Me.VideoClue = New AxWMPLib.AxWindowsMediaPlayer()
        CType(Me.VideoClue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VideoClue
        '
        Me.VideoClue.Enabled = True
        Me.VideoClue.Location = New System.Drawing.Point(0, 0)
        Me.VideoClue.Name = "VideoClue"
        Me.VideoClue.OcxState = CType(resources.GetObject("VideoClue.OcxState"), System.Windows.Forms.AxHost.State)
        Me.VideoClue.Size = New System.Drawing.Size(1024, 768)
        Me.VideoClue.TabIndex = 0
        '
        'VideoClueForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.VideoClue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "VideoClueForm"
        Me.Text = "VideoClueForm"
        CType(Me.VideoClue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VideoClue As AxWMPLib.AxWindowsMediaPlayer
End Class

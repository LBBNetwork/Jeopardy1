<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogWindow))
        Me.LogBox = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'LogBox
        '
        Me.LogBox.FormattingEnabled = True
        Me.LogBox.Location = New System.Drawing.Point(12, 12)
        Me.LogBox.Name = "LogBox"
        Me.LogBox.ScrollAlwaysVisible = True
        Me.LogBox.Size = New System.Drawing.Size(483, 238)
        Me.LogBox.TabIndex = 0
        '
        'LogWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 261)
        Me.Controls.Add(Me.LogBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LogWindow"
        Me.Text = "Log"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LogBox As System.Windows.Forms.ListBox
End Class

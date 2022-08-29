Public Class GraphicalThings
    Public Shared Sub GraphicalStuff(StuffToDo As String)
        Select Case StuffToDo
            Case "G_ClearScreen"
                For ClearLine As Integer = 1 To 36
                    Dim formLabel As Label = CType(Form1.Controls("Label" & ClearLine), Label)
                    formLabel.Text = ""
                Next
            Case "J_MakeScores"
                Form1.Label7.Text = "$200"
                Form1.Label8.Text = "$200"
                Form1.Label9.Text = "$200"
                Form1.Label10.Text = "$200"
                Form1.Label11.Text = "$200"
                Form1.Label12.Text = "$200"

                Form1.Label18.Text = "$400"
                Form1.Label17.Text = "$400"
                Form1.Label16.Text = "$400"
                Form1.Label15.Text = "$400"
                Form1.Label14.Text = "$400"
                Form1.Label13.Text = "$400"

                Form1.Label24.Text = "$600"
                Form1.Label23.Text = "$600"
                Form1.Label22.Text = "$600"
                Form1.Label21.Text = "$600"
                Form1.Label20.Text = "$600"
                Form1.Label19.Text = "$600"

                Form1.Label30.Text = "$800"
                Form1.Label29.Text = "$800"
                Form1.Label28.Text = "$800"
                Form1.Label27.Text = "$800"
                Form1.Label26.Text = "$800"
                Form1.Label25.Text = "$800"

                Form1.Label36.Text = "$1000"
                Form1.Label35.Text = "$1000"
                Form1.Label34.Text = "$1000"
                Form1.Label33.Text = "$1000"
                Form1.Label32.Text = "$1000"
                Form1.Label31.Text = "$1000"
            Case "DJ_MakeScores"
                Form1.Label7.Text = "$400"
                Form1.Label8.Text = "$400"
                Form1.Label9.Text = "$400"
                Form1.Label10.Text = "$400"
                Form1.Label11.Text = "$400"
                Form1.Label12.Text = "$400"

                Form1.Label18.Text = "$800"
                Form1.Label17.Text = "$800"
                Form1.Label16.Text = "$800"
                Form1.Label15.Text = "$800"
                Form1.Label14.Text = "$800"
                Form1.Label13.Text = "$800"

                Form1.Label24.Text = "$1200"
                Form1.Label23.Text = "$1200"
                Form1.Label22.Text = "$1200"
                Form1.Label21.Text = "$1200"
                Form1.Label20.Text = "$1200"
                Form1.Label19.Text = "$1200"

                Form1.Label30.Text = "$1600"
                Form1.Label29.Text = "$1600"
                Form1.Label28.Text = "$1600"
                Form1.Label27.Text = "$1600"
                Form1.Label26.Text = "$1600"
                Form1.Label25.Text = "$1600"

                Form1.Label36.Text = "$2000"
                Form1.Label35.Text = "$2000"
                Form1.Label34.Text = "$2000"
                Form1.Label33.Text = "$2000"
                Form1.Label32.Text = "$2000"
                Form1.Label31.Text = "$2000"

                mcp.Button1.Text = "$400"
                mcp.Button2.Text = "$400"
                mcp.Button3.Text = "$400"
                mcp.Button4.Text = "$400"
                mcp.Button5.Text = "$400"
                mcp.Button6.Text = "$400"

                mcp.Button7.Text = "$800"
                mcp.Button8.Text = "$800"
                mcp.Button9.Text = "$800"
                mcp.Button10.Text = "$800"
                mcp.Button11.Text = "$800"
                mcp.Button12.Text = "$800"

                mcp.Button13.Text = "$1200"
                mcp.Button14.Text = "$1200"
                mcp.Button15.Text = "$1200"
                mcp.Button16.Text = "$1200"
                mcp.Button17.Text = "$1200"
                mcp.Button18.Text = "$1200"

                mcp.Button19.Text = "$1600"
                mcp.Button20.Text = "$1600"
                mcp.Button21.Text = "$1600"
                mcp.Button22.Text = "$1600"
                mcp.Button23.Text = "$1600"
                mcp.Button24.Text = "$1600"

                mcp.Button25.Text = "$2000"
                mcp.Button26.Text = "$2000"
                mcp.Button27.Text = "$2000"
                mcp.Button28.Text = "$2000"
                mcp.Button29.Text = "$2000"
                mcp.Button30.Text = "$2000"

                For ClearLine As Integer = 1 To 30
                    Dim moneybutton As Button = CType(mcp.Controls("Button" & ClearLine), Button)
                    moneybutton.Enabled = True
                Next
        End Select
    End Sub
End Class

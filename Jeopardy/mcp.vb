Imports Jeopardy.GraphicalThings

Public Class mcp
    Public Shared JeopardyMode As String
    Public Shared CurrentClueValue As Integer
    Public Shared FinalTimeInt As Integer = 30
    Public Shared QString As String
    Public Shared TextReader As String
    Public Shared BoardFill As New ArrayList
    Public Shared FilledLabels As Integer = 0

    Public Shared C1Index As Integer = 0
    Public Shared C2Index As Integer = 0
    Public Shared C3Index As Integer = 0
    Public Shared C4Index As Integer = 0
    Public Shared C5Index As Integer = 0
    Public Shared C6Index As Integer = 0

    Private RoundEndtimer As DateTime
    Dim AudioClue As New System.Media.SoundPlayer()
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim myCp As CreateParams = MyBase.CreateParams
            myCp.ClassStyle = myCp.ClassStyle Or CP_NOCLOSE_BUTTON
            Return myCp
        End Get
    End Property
    Private Sub mcp_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        For ClearLine As Integer = 1 To 30
            Dim moneybutton As Button = CType(Controls("Button" & ClearLine), Button)
            moneybutton.Enabled = False
            ShowC.Enabled = False
            ShowQ.Enabled = False
        Next
        TimeLabel.Text = DateTime.Now.ToLongTimeString


    End Sub
    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cat1.Click
        Dim Cat1Str As String
        Dim Cat1Reader As New System.IO.StreamReader("data\cards\" + JeopardyMode + "\1.txt")
        Cat1Str = Cat1Reader.ReadToEnd()
        Form1.Label1.Text = Cat1Str
        Me.Cat1.Text = Cat1Str
        Cat1Reader.Close()
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cat2.Click
        Dim Cat2Str As String
        Dim Cat1Reader As New System.IO.StreamReader("data\cards\" + JeopardyMode + "\2.txt")
        Cat2Str = Cat1Reader.ReadToEnd()
        Form1.Label2.Text = Cat2Str
        Cat2.Text = Cat2Str
        Cat1Reader.Close()
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cat3.Click
        Dim cat3str As String
        Dim Cat1Reader As New System.IO.StreamReader("data\cards\" + JeopardyMode + "\3.txt")
        cat3str = Cat1Reader.ReadToEnd()
        Form1.Label3.Text = cat3str
        Cat3.Text = cat3str
        Cat1Reader.Close()
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cat4.Click
        Dim cat4str As String
        Dim Cat1Reader As New System.IO.StreamReader("data\cards\" + JeopardyMode + "\4.txt")
        cat4str = Cat1Reader.ReadToEnd()
        Form1.Label4.Text = cat4str
        Cat4.Text = cat4str
        Cat1Reader.Close()
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cat5.Click
        Dim cat5str As String

        Dim Cat1Reader As New System.IO.StreamReader("data\cards\" + JeopardyMode + "\5.txt")
        cat5str = Cat1Reader.ReadToEnd()
        Form1.Label5.Text = cat5str
        Cat5.Text = cat5str
        Cat1Reader.Close()
    End Sub

    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cat6.Click
        Dim cat6str As String
        Dim Cat1Reader As New System.IO.StreamReader("data\cards\" + JeopardyMode + "\6.txt")
        cat6str = Cat1Reader.ReadToEnd()

        If cat6str.Substring(0, 1) = "%" Then
            Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\category.mp4")
            VidClue.Show()
            Form1.Label6.Text = cat6str.Remove(0, 1)
        Else
            Form1.Label6.Text = cat6str
        End If

        Cat6.Text = cat6str
        Cat1Reader.Close()

        If JeopardyMode = "dj" Then
            GraphicalStuff("DJ_MakeScores")
        Else
            'GraphicalStuff("J_MakeScores")
        End If

        For ClearLine As Integer = 1 To 30
            Dim moneybutton As Button = CType(Controls("Button" & ClearLine), Button)
            moneybutton.Enabled = True
        Next
    End Sub
    Private Sub JeopardyRB_CheckedChanged(sender As Object, e As EventArgs) Handles JeopardyRB.CheckedChanged
        Dim Sound As New System.Media.SoundPlayer()

        C1Index = 4
        C2Index = 4
        C3Index = 4
        C4Index = 4
        C5Index = 4
        C6Index = 4

        Form1.QuestionPic.Visible = False

        JeopardyMode = "j"

        If JeopardyRB.Checked = True Then
            If Dingy.Checked = False Then
                Timer1.Start()

                Sound.SoundLocation = "data\sounds\beepboop.wav"  'ex.: c:\mysound.wav  
            Else
                DingyTest.Start()

                Sound.SoundLocation = "data\sounds\dingy.wav"

            End If
            Sound.Load()
            Sound.Play()
        End If

        DD2btn.Enabled = False

        Cat1.Enabled = True
        Cat2.Enabled = True
        Cat3.Enabled = True
        Cat4.Enabled = True
        Cat5.Enabled = True
        Cat6.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Label7.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 200
                QString = "data\cards\" + JeopardyMode + "\c1\200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\200.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c1\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\400.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 400
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\200.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\400.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        ElseIf TextReader.Substring(0, 1) = "%" Then
            Dim VidClue As New VideoClueForm("c1\theking.mp4")
            VidClue.Show()

        End If

        Button1.Enabled = False

        If C1Index = 0 Then
            Form1.Label1.Text = ""
        Else
            C1Index = C1Index - 1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Label8.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 200
                QString = "data\cards\" + JeopardyMode + "\c2\200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\200.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c2\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\400.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 400
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\200.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\400.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button2.Enabled = False

        If C2Index = 0 Then
            Form1.Label2.Text = ""
        Else
            C2Index = C2Index - 1
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Label9.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 200
                QString = "data\cards\" + JeopardyMode + "\c3\200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\200.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c3\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\400.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 400
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\200.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\400.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button3.Enabled = False

        If C3Index = 0 Then
            Form1.Label3.Text = ""
        Else
            C3Index = C3Index - 1
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Label10.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 200
                QString = "data\cards\" + JeopardyMode + "\c4\200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\200.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c4\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\400.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 400
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\200.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\400.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button4.Enabled = False

        If C4Index = 0 Then
            Form1.Label4.Text = ""
        Else
            C4Index = C4Index - 1
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form1.Label11.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 200
                QString = "data\cards\" + JeopardyMode + "\c5\200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\200.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c5\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\400.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 400
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\200.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\400.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button5.Enabled = False

        If C5Index = 0 Then
            Form1.Label5.Text = ""
        Else
            C5Index = C5Index - 1
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.Label12.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 200
                QString = "data\cards\" + JeopardyMode + "\c6\200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\200.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c6\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\400.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 400
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\200.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\400.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        ElseIf TextReader.Substring(0, 1) = "%" Then
            If JeopardyMode = "j" Then
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\200.mp4")
                VidClue.Show()
            Else
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\400.mp4")
                VidClue.Show()
            End If
        End If
        Button6.Enabled = False

        If C6Index = 0 Then
            '  MessageBox.Show(C6Index.ToString)
            Form1.Label6.Text = ""
        Else
            C6Index = C6Index - 1
            '  MessageBox.Show(C6Index.ToString)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form1.Label18.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 400
                QString = "data\cards\" + JeopardyMode + "\c1\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\400.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c1\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\800.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 800
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\400.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\800.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button7.Enabled = False

        If C1Index = 0 Then
            Form1.Label1.Text = ""
        Else
            C1Index = C1Index - 1
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Form1.Label17.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 400
                QString = "data\cards\" + JeopardyMode + "\c2\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\400.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c2\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\800.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 800
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\400.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\800.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button8.Enabled = False

        If C2Index = 0 Then
            Form1.Label2.Text = ""
        Else
            C2Index = C2Index - 1
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form1.Label16.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 400
                QString = "data\cards\" + JeopardyMode + "\c3\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\400.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c3\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\800.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 800
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\400.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\800.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button9.Enabled = False

        If C3Index = 0 Then
            Form1.Label3.Text = ""
        Else
            C3Index = C3Index - 1
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form1.Label15.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 400
                QString = "data\cards\" + JeopardyMode + "\c4\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\400.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c4\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\800.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 800
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\400.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\800.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button10.Enabled = False

        If C4Index = 0 Then
            Form1.Label4.Text = ""
        Else
            C4Index = C4Index - 1
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form1.Label14.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 400
                QString = "data\cards\" + JeopardyMode + "\c5\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\400.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c5\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\800.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 800
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\400.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\800.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button11.Enabled = False

        If C5Index = 0 Then
            Form1.Label5.Text = ""
        Else
            C5Index = C5Index - 1
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Form1.Label13.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 400
                QString = "data\cards\" + JeopardyMode + "\c6\400.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\400.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c6\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\800.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 800
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\400.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\800.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        ElseIf TextReader.Substring(0, 1) = "%" Then
            If JeopardyMode = "j" Then
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\400.mp4")
                VidClue.Show()
            Else
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\800.mp4")
                VidClue.Show()
            End If
        End If
        Button12.Enabled = False

        If C6Index = 0 Then
            '   MessageBox.Show(C6Index.ToString)
            Form1.Label6.Text = ""
        Else
            C6Index = C6Index - 1
            '   MessageBox.Show(C6Index.ToString)
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Form1.Label24.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 600
                QString = "data\cards\" + JeopardyMode + "\c1\600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\600.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c1\1200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\1200.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1200
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\600.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\1200.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button13.Enabled = False

        If C1Index = 0 Then
            Form1.Label1.Text = ""
        Else
            C1Index = C1Index - 1
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Form1.Label23.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 600
                QString = "data\cards\" + JeopardyMode + "\c2\600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\600.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c2\1200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\1200.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1200
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\600.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\1200.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button14.Enabled = False

        If C2Index = 0 Then
            Form1.Label2.Text = ""
        Else
            C2Index = C2Index - 1
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Form1.Label22.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 600
                QString = "data\cards\" + JeopardyMode + "\c3\600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\600.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c3\1200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\1200.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1200
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\600.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\1200.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button15.Enabled = False

        If C3Index = 0 Then
            Form1.Label3.Text = ""
        Else
            C3Index = C3Index - 1
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Form1.Label21.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 600
                QString = "data\cards\" + JeopardyMode + "\c4\600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\600.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c4\1200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\1200.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1200
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\600.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\1200.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button16.Enabled = False

        If C4Index = 0 Then
            Form1.Label4.Text = ""
        Else
            C4Index = C4Index - 1
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Form1.Label20.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 600
                QString = "data\cards\" + JeopardyMode + "\c5\600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\600.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c5\1200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\1200.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1200
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\600.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\1200.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button17.Enabled = False

        If C5Index = 0 Then
            Form1.Label5.Text = ""
        Else
            C5Index = C5Index - 1
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Form1.Label19.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 600
                QString = "data\cards\" + JeopardyMode + "\c6\600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\600.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c6\1200.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\1200.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1200
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\600.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\1200.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        ElseIf TextReader.Substring(0, 1) = "%" Then
            If JeopardyMode = "j" Then
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\600.mp4")
                VidClue.Show()
            Else
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\1200.mp4")
                VidClue.Show()
            End If
        End If
        Button18.Enabled = False

        If C6Index = 0 Then
            '   MessageBox.Show(C6Index.ToString)
            Form1.Label6.Text = ""
        Else
            C6Index = C6Index - 1
            '  MessageBox.Show(C6Index.ToString)
        End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Form1.Label30.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 800
                QString = "data\cards\" + JeopardyMode + "\c1\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\800.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c1\1600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\1600.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1600
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\800.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\1600.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button19.Enabled = False

        If C1Index = 0 Then
            Form1.Label1.Text = ""
        Else
            C1Index = C1Index - 1
        End If
    End Sub
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Form1.Label29.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 800
                QString = "data\cards\" + JeopardyMode + "\c2\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\800.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c2\1600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\1600.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1600
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\800.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\1600.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button20.Enabled = False

        If C2Index = 0 Then
            Form1.Label2.Text = ""
        Else
            C2Index = C2Index - 1
        End If
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Form1.Label28.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 800
                QString = "data\cards\" + JeopardyMode + "\c3\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\800.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c3\1600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\1600.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1600
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\800.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\1600.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button21.Enabled = False

        If C3Index = 0 Then
            Form1.Label3.Text = ""
        Else
            C3Index = C3Index - 1
        End If
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Form1.Label27.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 800
                QString = "data\cards\" + JeopardyMode + "\c4\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\800.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c4\1600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\1600.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1600
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\800.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\1600.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button22.Enabled = False

        If C4Index = 0 Then
            Form1.Label4.Text = ""
        Else
            C4Index = C4Index - 1
        End If
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Form1.Label26.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 800
                QString = "data\cards\" + JeopardyMode + "\c5\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\800.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c5\1600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\1600.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1600
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\800.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\1600.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button23.Enabled = False

        If C5Index = 0 Then
            Form1.Label5.Text = ""
        Else
            C5Index = C5Index - 1
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Form1.Label25.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 800
                QString = "data\cards\" + JeopardyMode + "\c6\800.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\800.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c6\1600.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\1600.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 1600
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\800.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\1600.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        ElseIf TextReader.Substring(0, 1) = "%" Then
            If JeopardyMode = "j" Then
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\800.mp4")
                VidClue.Show()
            Else
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\1600.mp4")
                VidClue.Show()
            End If
        End If
        Button24.Enabled = False

        If C6Index = 0 Then
            '   MessageBox.Show(C6Index.ToString)
            Form1.Label6.Text = ""
        Else
            C6Index = C6Index - 1
            '    MessageBox.Show(C6Index.ToString)
        End If
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Form1.Label36.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 1000
                QString = "data\cards\" + JeopardyMode + "\c1\1000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\1000.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c1\2000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c1\2000.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 2000
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\1000.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c1\2000.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button25.Enabled = False

        If C1Index = 0 Then
            Form1.Label1.Text = ""
        Else
            C1Index = C1Index - 1
        End If
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Form1.Label35.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 1000
                QString = "data\cards\" + JeopardyMode + "\c2\1000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\1000.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c2\2000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c2\2000.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 2000
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\1000.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c2\2000.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button26.Enabled = False

        If C2Index = 0 Then
            Form1.Label2.Text = ""
        Else
            C2Index = C2Index - 1
        End If
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Form1.Label34.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 1000
                QString = "data\cards\" + JeopardyMode + "\c3\1000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\1000.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c3\2000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c3\2000.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 2000
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\1000.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c3\2000.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button27.Enabled = False

        If C3Index = 0 Then
            Form1.Label3.Text = ""
        Else
            C3Index = C3Index - 1
        End If
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        Form1.Label33.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 1000
                QString = "data\cards\" + JeopardyMode + "\c4\1000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\1000.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c4\2000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c4\2000.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 2000
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\1000.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c4\2000.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If
        Button28.Enabled = False

        If C4Index = 0 Then
            Form1.Label4.Text = ""
        Else
            C4Index = C4Index - 1
        End If
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Form1.Label32.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 1000
                QString = "data\cards\" + JeopardyMode + "\c5\1000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\1000.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c5\2000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c5\2000.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 2000
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\1000.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c5\2000.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        End If

        Button29.Enabled = False

        If C5Index = 0 Then
            Form1.Label5.Text = ""
        Else
            C5Index = C5Index - 1
        End If
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        Form1.Label31.Text = ""
        Select Case JeopardyMode
            Case "j"
                CurrentClueValue = 1000
                QString = "data\cards\" + JeopardyMode + "\c6\1000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\1000.png")
                Form1.QuestionPic.Visible = True
            Case "dj"
                QString = "data\cards\" + JeopardyMode + "\c6\2000.txt"
                Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\c6\2000.png")
                Form1.QuestionPic.Visible = True
                CurrentClueValue = 2000
        End Select
        Dim QuestionReader As New System.IO.StreamReader(QString)
        TextReader = QuestionReader.ReadToEnd
        QuestionLabel.Text = TextReader
        QuestionReader.Close()

        If TextReader.Substring(0, 1) = "[" Then
            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\dailydouble.wav"
            Sound.Load()
            Sound.Play()
        ElseIf TextReader.Substring(0, 1) = "{" Then
            If JeopardyMode = "j" Then
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\1000.wav"
            Else
                AudioClue.SoundLocation = "data\cards\" + JeopardyMode + "\c6\2000.wav"
            End If
            AudioClue.Load()
            AudioCluePlay.Enabled = True
        ElseIf TextReader.Substring(0, 1) = "%" Then
            If JeopardyMode = "j" Then
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\1000.mp4")
                VidClue.Show()
            Else
                Dim VidClue As New VideoClueForm("data\cards\" + JeopardyMode + "\c6\2000.mp4")
                VidClue.Show()
            End If
        End If
        Button30.Enabled = False

        If C6Index = 0 Then
            '    MessageBox.Show(C6Index.ToString)
            Form1.Label6.Text = ""
        Else
            C6Index = C6Index - 1
            '   MessageBox.Show(C6Index.ToString)
        End If
    End Sub
    Private Sub P1_AddWager_Click(sender As Object, e As EventArgs) Handles P1_AddWager.Click
        If P1_wager.Text = "" Then

        Else
            Form1.GlobalScoreP1 = Form1.GlobalScoreP1 + P1_wager.Text
            P1_Score.Text = "$" & Form1.GlobalScoreP1
            Form1.P1Score.Text = "$" & Form1.GlobalScoreP1

            If Form1.GlobalScoreP1 > -1 Then
                Form1.P1Score.ForeColor = Color.White
            End If

            Form1.QuestionPic.Visible = False
        End If

        P1_wager.Text = ""
    End Sub
    Private Sub P1_DecWager_Click(sender As Object, e As EventArgs) Handles P1_DecWager.Click
        If P1_wager.Text = "" Then

        Else
            Form1.GlobalScoreP1 = Form1.GlobalScoreP1 - P1_wager.Text
            P1_Score.Text = "$" & Form1.GlobalScoreP1
            Form1.P1Score.Text = "$" & Form1.GlobalScoreP1

            If Form1.GlobalScoreP1 < 0 Then
                Form1.P1Score.ForeColor = Color.Red
            End If

            Form1.QuestionPic.Visible = False
        End If

        P1_wager.Text = ""
    End Sub
    Private Sub P2_AddWager_Click(sender As Object, e As EventArgs) Handles P2_AddWager.Click
        If P2_wager.Text = "" Then

        Else
            Form1.GlobalScoreP2 = Form1.GlobalScoreP2 + P2_wager.Text
            P2_Score.Text = "$" & Form1.GlobalScoreP2
            Form1.P2Score.Text = "$" & Form1.GlobalScoreP2

            If Form1.GlobalScoreP2 > -1 Then
                Form1.P2Score.ForeColor = Color.White
            End If

            Form1.QuestionPic.Visible = False
        End If

        P2_wager.Text = ""
    End Sub
    Private Sub P2_DecWager_Click(sender As Object, e As EventArgs) Handles P2_DecWager.Click
        If P2_wager.Text = "" Then

        Else
            Form1.GlobalScoreP2 = Form1.GlobalScoreP2 - P2_wager.Text
            P2_Score.Text = "$" & Form1.GlobalScoreP2
            Form1.P2Score.Text = "$" & Form1.GlobalScoreP2

            If Form1.GlobalScoreP2 < 0 Then
                Form1.P2Score.ForeColor = Color.Red
            End If

            Form1.QuestionPic.Visible = False
        End If

        P2_wager.Text = ""
    End Sub
    Private Sub P3_AddWager_Click(sender As Object, e As EventArgs) Handles P3_AddWager.Click
        If P3_wager.Text = "" Then

        Else
            Form1.GlobalScoreP3 = Form1.GlobalScoreP3 + P3_wager.Text
            P3_Score.Text = "$" & Form1.GlobalScoreP3
            Form1.P3Score.Text = "$" & Form1.GlobalScoreP3

            If Form1.GlobalScoreP3 > -1 Then
                Form1.P3Score.ForeColor = Color.White
            End If

            Form1.QuestionPic.Visible = False
        End If

        P3_wager.Text = ""
    End Sub
    Private Sub P3_DecWager_Click(sender As Object, e As EventArgs) Handles P3_DecWager.Click
        If P3_wager.Text = "" Then

        Else
            Form1.GlobalScoreP3 = Form1.GlobalScoreP3 - P3_wager.Text
            P3_Score.Text = "$" & Form1.GlobalScoreP3
            Form1.P3Score.Text = "$" & Form1.GlobalScoreP3

            If Form1.GlobalScoreP3 < 0 Then
                Form1.P3Score.ForeColor = Color.Red
            End If

            Form1.QuestionPic.Visible = False
        End If

        P3_wager.Text = ""
    End Sub
    Private Sub DoubleJeopardyRB_CheckedChanged(sender As Object, e As EventArgs) Handles DoubleJeopardyRB.CheckedChanged
        C1Index = 4
        C2Index = 4
        C3Index = 4
        C4Index = 4
        C5Index = 4
        C6Index = 4

        Cat1.Text = "Category 1"
        Cat2.Text = "Category 2"
        Cat3.Text = "Category 3"
        Cat4.Text = "Category 4"
        Cat5.Text = "Category 5"
        Cat6.Text = "Category 6"

        DD2btn.Enabled = True
        JeopardyMode = "dj"
        GraphicalStuff("G_ClearScreen")
        GraphicalStuff("DJ_MakeScores")
        JeopardyRB.Enabled = False
    End Sub
    Private Sub FinalJeopardyRB_CheckedChanged(sender As Object, e As EventArgs) Handles FinalJeopardyRB.CheckedChanged
        JeopardyMode = "fj"
        GraphicalStuff("G_ClearScreen")
        Form1.QuestionPic.Visible = False
        ShowQ.Enabled = True
        ShowC.Enabled = True
        DD1btn.Enabled = False
        DD2btn.Enabled = False
        StartFinal.Enabled = True

        For ClearLine As Integer = 1 To 30
            Dim moneybutton As Button = CType(Controls("Button" & ClearLine), Button)
            moneybutton.Enabled = False
        Next

        Cat1.Enabled = False
        Cat2.Enabled = False
        Cat3.Enabled = False
        Cat4.Enabled = False
        Cat5.Enabled = False
        Cat6.Enabled = False

        P1_AddScore.Enabled = False
        P1_DecScore.Enabled = False
        P2_AddScore.Enabled = False
        P2_DecScore.Enabled = False
        P3_AddScore.Enabled = False
        P3_DecScore.Enabled = False


    End Sub

    Private Sub P1_AddScore_Click(sender As Object, e As EventArgs) Handles P1_AddScore.Click
        Form1.QuestionPic.Visible = False
        Form1.GlobalScoreP1 = Form1.GlobalScoreP1 + CurrentClueValue

        LogWindow.LogBox.Items.Add("[" + DateTime.Now + "] " + P1NameBox.Text + " responded correctly for $" + CurrentClueValue.ToString)
        LogWindow.LogBox.TopIndex = LogWindow.LogBox.Items.Count - 1

        Form1.P1Correct.Visible = True
        Form1.P2Correct.Visible = False
        Form1.P3Correct.Visible = False

        P1Correct.Checked = True

        Form1.P1Score.Text = "$" & Form1.GlobalScoreP1
        P1_Score.Text = "$" & Form1.GlobalScoreP1

        If Form1.GlobalScoreP1 > -1 Then
            Form1.P1Score.ForeColor = Color.White
        End If
    End Sub

    Private Sub P1_DecScore_Click(sender As Object, e As EventArgs) Handles P1_DecScore.Click
        Form1.GlobalScoreP1 = Form1.GlobalScoreP1 - CurrentClueValue

        LogWindow.LogBox.Items.Add("[" + DateTime.Now + "] " + P1NameBox.Text + " responded incorrectly and lost $" + CurrentClueValue.ToString)
        LogWindow.LogBox.TopIndex = LogWindow.LogBox.Items.Count - 1

        Form1.P1Score.Text = "$" & Form1.GlobalScoreP1
        P1_Score.Text = "$" & Form1.GlobalScoreP1

        If Form1.GlobalScoreP1 < 0 Then
            Form1.P1Score.ForeColor = Color.Red
        End If
    End Sub

    Private Sub P2_AddScore_Click(sender As Object, e As EventArgs) Handles P2_AddScore.Click
        Form1.QuestionPic.Visible = False
        Form1.GlobalScoreP2 = Form1.GlobalScoreP2 + CurrentClueValue

        LogWindow.LogBox.Items.Add("[" + DateTime.Now + "] " + P2NameBox.Text + " responded correctly for $" + CurrentClueValue.ToString)
        LogWindow.LogBox.TopIndex = LogWindow.LogBox.Items.Count - 1

        Form1.P1Correct.Visible = False
        Form1.P2Correct.Visible = True
        Form1.P3Correct.Visible = False

        P2Correct.Checked = True

        Form1.P2Score.Text = "$" & Form1.GlobalScoreP2
        P2_Score.Text = "$" & Form1.GlobalScoreP2

        If Form1.GlobalScoreP2 > -1 Then
            Form1.P1Score.ForeColor = Color.White
        End If
    End Sub

    Private Sub P2_DecScore_Click(sender As Object, e As EventArgs) Handles P2_DecScore.Click
        Form1.GlobalScoreP2 = Form1.GlobalScoreP2 - CurrentClueValue

        LogWindow.LogBox.Items.Add("[" + DateTime.Now + "] " + P2NameBox.Text + " responded incorrectly and lost $" + CurrentClueValue.ToString)
        LogWindow.LogBox.TopIndex = LogWindow.LogBox.Items.Count - 1

        Form1.P2Score.Text = "$" & Form1.GlobalScoreP2
        P2_Score.Text = "$" & Form1.GlobalScoreP2

        If Form1.GlobalScoreP2 < 0 Then
            Form1.P2Score.ForeColor = Color.Red
        End If
    End Sub

    Private Sub P3_AddScore_Click(sender As Object, e As EventArgs) Handles P3_AddScore.Click
        Form1.QuestionPic.Visible = False
        Form1.GlobalScoreP3 = Form1.GlobalScoreP3 + CurrentClueValue

        LogWindow.LogBox.Items.Add("[" + DateTime.Now + "] " + P3NameBox.Text + " responded correctly for $" + CurrentClueValue.ToString)
        LogWindow.LogBox.TopIndex = LogWindow.LogBox.Items.Count - 1

        Form1.P1Correct.Visible = False
        Form1.P2Correct.Visible = False
        Form1.P3Correct.Visible = True

        P3Correct.Checked = True

        Form1.P3Score.Text = "$" & Form1.GlobalScoreP3
        P3_Score.Text = "$" & Form1.GlobalScoreP3

        If Form1.GlobalScoreP3 > -1 Then
            Form1.P3Score.ForeColor = Color.White
        End If
    End Sub

    Private Sub P3_DecScore_Click(sender As Object, e As EventArgs) Handles P3_DecScore.Click
        Form1.GlobalScoreP3 = Form1.GlobalScoreP3 - CurrentClueValue

        LogWindow.LogBox.Items.Add("[" + DateTime.Now + "] " + P3NameBox.Text + " responded incorrectly and lost $" + CurrentClueValue.ToString)
        LogWindow.LogBox.TopIndex = LogWindow.LogBox.Items.Count - 1

        Form1.P3Score.Text = "$" & Form1.GlobalScoreP3
        P3_Score.Text = "$" & Form1.GlobalScoreP3

        If Form1.GlobalScoreP3 < 0 Then
            Form1.P3Score.ForeColor = Color.Red
        End If
    End Sub

    Private Sub HideQuestion_Click(sender As Object, e As EventArgs) Handles HideQuestion.Click
        Dim Sound As New System.Media.SoundPlayer()
        Sound.SoundLocation = "data\sounds\timeout.wav"  'ex.: c:\mysound.wav  
        Sound.Load()
        Sound.Play()
        Form1.QuestionPic.Visible = False
    End Sub

    Private Sub DD1btn_Click(sender As Object, e As EventArgs) Handles DD1btn.Click
        Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\" + JeopardyMode + "\dailydouble1.png")
        Form1.QuestionPic.Visible = True
    End Sub

    Private Sub DD2btn_Click(sender As Object, e As EventArgs) Handles DD2btn.Click
        If DoubleJeopardyRB.Checked = True Then
            Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\dj\dailydouble2.png")
            Form1.QuestionPic.Enabled = True
        Else

        End If
    End Sub

    Private Sub ShowC_Click(sender As Object, e As EventArgs) Handles ShowC.Click
        Form1.QuestionPic.Visible = True
        Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\fj\finalcat.png")

        Dim Sound As New System.Media.SoundPlayer()
        Sound.SoundLocation = "data\sounds\ping.wav"  'ex.: c:\mysound.wav  
        Sound.Load()
        Sound.Play()
    End Sub

    Private Sub ShowQ_Click(sender As Object, e As EventArgs) Handles ShowQ.Click
        Form1.QuestionPic.Visible = True
        Dim QuestionReader As New System.IO.StreamReader("data\cards\fj\finalq.txt")
        QuestionLabel.Text = QuestionReader.ReadToEnd()
        QuestionReader.Close()
        Form1.QuestionPic.Image = New System.Drawing.Bitmap("data\cards\fj\finalq.png")

        Dim Sound As New System.Media.SoundPlayer()
        Sound.SoundLocation = "data\sounds\ping.wav"  'ex.: c:\mysound.wav  
        Sound.Load()
        Sound.Play()
    End Sub
    Private Sub FinalTimer_Tick(sender As Object, e As EventArgs) Handles FinalTimer.Tick
        If FinalTimeInt > 0 Then
            FinalTimeInt -= 1
            RoundCountdownLabel.Text = FinalTimeInt & " seconds"
        Else
            FinalTimer.Stop()
        End If

    End Sub

    Private Sub StartFinal_Click(sender As Object, e As EventArgs) Handles StartFinal.Click
        FinalTimer.Start()

        Dim Sound As New System.Media.SoundPlayer()
        Sound.SoundLocation = "data\sounds\untitled.wav"  'ex.: c:\mysound.wav  
        Sound.Load()
        Sound.Play()
    End Sub

    Private Sub P1ApplyName_Click(sender As Object, e As EventArgs) Handles P1ApplyName.Click
        Form1.Player1Name.Text = P1NameBox.Text
        '  P1NameBox.Enabled = False
    End Sub

    Private Sub P2ApplyName_Click(sender As Object, e As EventArgs) Handles P2ApplyName.Click
        Form1.Player2Name.Text = P2NameBox.Text
        '  P2NameBox.Enabled = False
    End Sub

    Private Sub P3ApplyName_Click(sender As Object, e As EventArgs) Handles P3ApplyName.Click
        Form1.Player3Name.Text = P3NameBox.Text
        '   P3NameBox.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim myRandom As Random = New Random()
        Dim rn As Integer = 0

ReRand:
        Randomize()
        Rnd()

        rn = myRandom.Next(7, 36)

        If FilledLabels < 609 Then
            If BoardFill.Contains(rn) Then
                GoTo ReRand
            Else
                If rn > 6 And rn < 13 Then
                    Dim _200Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _200Dollar.Text = "$200"
                ElseIf rn > 12 And rn < 19 Then
                    Dim _400Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _400Dollar.Text = "$400"
                ElseIf rn > 18 And rn < 25 Then
                    Dim _600Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _600Dollar.Text = "$600"
                ElseIf rn > 24 And rn < 31 Then
                    Dim _800Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _800Dollar.Text = "$800"
                ElseIf rn > 30 And rn < 37 Then
                    Dim _1000Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _1000Dollar.Text = "$1000"
                End If

                BoardFill.Add(rn)

                FilledLabels = FilledLabels + rn
            End If
        Else
            Form1.Label36.Text = "$1000"
            ' Cat1.Enabled = True
            ' Cat2.Enabled = True
            ' Cat3.Enabled = True
            ' Cat4.Enabled = True
            ' Cat5.Enabled = True
            ' Cat6.Enabled = True

            Timer1.Stop()
        End If
    End Sub

    Private Sub TimeUpdate_Tick(sender As Object, e As EventArgs) Handles TimeUpdate.Tick
        TimeLabel.Text = DateTime.Now.ToLongTimeString
    End Sub

    Private Sub RoundTimer_Tick(sender As Object, e As EventArgs) Handles RoundTimer.Tick
        Dim togo As TimeSpan = RoundEndtimer - Now
        If togo.Ticks < 0 Then
            RoundTimer.Enabled = False
            RoundTimeLabel.Text = "00:11:00"
            StartRoundButton.Enabled = True
            ' MessageBox.Show("Round over")

            Dim Sound As New System.Media.SoundPlayer()
            Sound.SoundLocation = "data\sounds\roundend.wav"  'ex.: c:\mysound.wav  
            Sound.Load()
            Sound.Play()
        Else
            RoundTimeLabel.Text = togo.ToString()
        End If
    End Sub

    Private Sub StartRoundButton_Click(sender As Object, e As EventArgs) Handles StartRoundButton.Click
        RoundEndtimer = Now + TimeSpan.Parse(RoundTimeLabel.Text)
        RoundTimer.Enabled = True
        StartRoundButton.Enabled = False
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        RoundTimer.Enabled = False
        RoundTimeLabel.Text = "00:11:00"
        StartRoundButton.Enabled = True
    End Sub

    Private Sub AudioCluePlay_Click(sender As Object, e As EventArgs) Handles AudioCluePlay.Click
        AudioClue.Play()
        AudioCluePlay.Enabled = False
    End Sub

    Private Sub DingyTest_Tick(sender As Object, e As EventArgs) Handles DingyTest.Tick
        Dim myRandom As Random = New Random()
        Dim rn As Integer = 0

        Dim dingyint As Integer = 0
ReRand:

        Randomize()
        Rnd()

        rn = myRandom.Next(7, 36)
        If FilledLabels < 609 Then
            If BoardFill.Contains(rn) Then
                GoTo ReRand
            Else
                ' select five random positions on the board per tick of the timer (85ms)

                If rn > 6 And rn < 13 Then
                    Dim _200Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _200Dollar.Text = "$200"
                ElseIf rn > 12 And rn < 19 Then
                    Dim _400Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _400Dollar.Text = "$400"
                ElseIf rn > 18 And rn < 25 Then
                    Dim _600Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _600Dollar.Text = "$600"
                ElseIf rn > 24 And rn < 31 Then
                    Dim _800Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _800Dollar.Text = "$800"
                ElseIf rn > 30 And rn < 37 Then
                    Dim _1000Dollar As Label = CType(Form1.Controls("Label" & rn), Label)
                    _1000Dollar.Text = "$1000"
                End If

                BoardFill.Add(rn)
                dingyint = dingyint + 1
                FilledLabels = FilledLabels + rn


            End If
        Else

        End If

        If FilledLabels < 609 Then
            If dingyint < 5 Then
                GoTo ReRand
            End If
        Else
            Form1.Label36.Text = "$1000"
            DingyTest.Stop()
        End If

    End Sub
End Class
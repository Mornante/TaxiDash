Public Class Form1
    'dim for speed to increase as the score increases'
    Dim speed As Integer
    'dim for road to move'
    Dim road(12) As PictureBox
    'dim for bridge to move'
    Dim xbridge(4) As PictureBox
    'dim for people to move
    Dim peeps(2) As PictureBox
    'dim for score to increase'
    Dim score As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'speed of the road'
        speed = 3
        'the road information'
        road(0) = PictureBox1
        road(1) = PictureBox2
        road(2) = PictureBox3
        road(3) = PictureBox4
        road(4) = PictureBox5
        road(5) = PictureBox6
        road(6) = PictureBox7
        road(7) = PictureBox8
        'the people informaion'
        peeps(0) = people1
        peeps(1) = people2
        peeps(2) = people3
        'the bridge information'
        xbridge(2) = bridge3
        xbridge(3) = bridge4
        xbridge(4) = bridge5

    End Sub

    Private Sub MoveRoad_Tick(sender As Object, e As EventArgs) Handles MoveRoad.Tick
        'the computer will deside white picture box to reset as it reaches the bottom'
        For x As Integer = 0 To 7
            'speed of the road '
            road(x).Top += 2
            'if road lines reach bottom the reset'
            If road(x).Top > Me.Height Then
                road(x).Top = -road(x).Height
            End If

        Next

        'this will update the speed board'
        SpeedBoard.Text = "Speed : " & speed
        'how to update the speed board'
        If score > 10 And score < 20 Then
            speed = 5
        End If
        If score > 20 And score < 30 Then
            speed = 6
        End If
        If score > 30 And score < 40 Then
            speed = 7
        End If
        If score > 40 And score < 50 Then
            speed = 8
        End If
        If score > 50 And score < 60 Then
            speed = 9
        End If
        If score > 60 And score < 70 Then
            speed = 10
        End If
        If score > 70 Then
            speed = 20
        End If

        'computer wil decide which people to reset as the reach the bottom'
        For z As Integer = 0 To 2
            'speed of the people walking'
            peeps(z).Top += 7
            'if people reach the bottom the reset at the top'
            If peeps(z).Top > Me.Height Then
                peeps(z).Top = -peeps(z).Height
            End If

        Next

        'computer wil decide which bridge part to reset as the reach the bottom'
        For y As Integer = 2 To 4
            xbridge(y).Top += 1.8
            If xbridge(y).Top > Me.Height Then
                xbridge(y).Top = -xbridge(y).Height
            End If

        Next

        'if you crash into a enemy game over procedure will start'
        If (player.Bounds.IntersectsWith(enemy1.Bounds)) Then
            gameover()
        End If
        If (player.Bounds.IntersectsWith(enemy2.Bounds)) Then
            gameover()
        End If
        If (player.Bounds.IntersectsWith(enemy3.Bounds)) Then
            gameover()
        End If

    End Sub
    Private Sub gameover()
        'game over label will appear if you crash'
        End_text.Visible = True
        'Restart button will appear if you crash'
        btnRestart.Visible = True
        'if you crash the road and enemies will stop'
        MoveRoad.Stop()
        EnemyDrive1.Stop()
        EnemyDrive2.Stop()
        EnemyDrive3.Stop()

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'the controls for turning left or right'
        If e.KeyCode = Keys.Right Then
            MoveRight.Start()
        End If
        If e.KeyCode = Keys.Left Then
            MoveLeft.Start()
        End If

    End Sub

    Private Sub MoveLeft_Tick(sender As Object, e As EventArgs) Handles MoveLeft.Tick
        'will keep you from going onto the left sidewalk'
        If (player.Location.X < 24) Then
            player.Left += 5
        End If
        player.Left -= 5
    End Sub

    Private Sub MoveRight_Tick(sender As Object, e As EventArgs) Handles MoveRight.Tick
        'will keep you from going onto the right sidewalk'
        If (player.Location.X > 260) Then
            player.Left -= 5
        End If
        player.Left += 5
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        'if you stop pressing the turning keys the will not work anymore'
        MoveRight.Stop()
        MoveLeft.Stop()
    End Sub

    Private Sub EnemyDrive1_Tick(sender As Object, e As EventArgs) Handles EnemyDrive1.Tick
        'speed calculation for enemy 1'
        enemy1.Top += speed + 2
        'if enemy 1 reaches bottom the reset at top'
        If enemy1.Top >= Me.Height Then
            'add score if reaches bottom'
            score += 1
            ScoreBoard.Text = "Score : " & score
            'spawn in different location each time'
            enemy1.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + enemy1.Height)
            enemy1.Left = CInt(Math.Ceiling(Rnd() * 85)) + 24
        End If

    End Sub
    Private Sub EnemyDrive2_Tick(sender As Object, e As EventArgs) Handles EnemyDrive2.Tick
        'speed calculation for enemy 2'
        enemy2.Top += speed + 1.4
        'if enemy 2 reaches bottom the reset at top'
        If enemy2.Top >= Me.Height Then
            'add score if reaches bottom'
            score += 1
            ScoreBoard.Text = "Score : " & score
            'spawn in different location each time'
            enemy2.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + enemy2.Height)
            enemy2.Left = CInt(Math.Ceiling(Rnd() * 160)) + 90
        End If
    End Sub

    Private Sub EnemyDrive3_Tick(sender As Object, e As EventArgs) Handles EnemyDrive3.Tick
        'speed calculation for enemy 3'
        enemy3.Top += speed * 2
        'if enemy 3 reaches bottom the reset at top'
        If enemy3.Top >= Me.Height Then
            'add score if reaches bottom'
            score += 1
            ScoreBoard.Text = "Score : " & score
            'spawn in different location each time'
            enemy3.Top = -(CInt(Math.Ceiling(Rnd() * 150)) + enemy3.Height)
            enemy3.Left = CInt(Math.Ceiling(Rnd() * 70)) + 170
        End If
    End Sub

    Private Sub btnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        'if click restart button then reset all stats'
        score = 0
        'reset all game settings'
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)

    End Sub
End Class

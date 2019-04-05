Public Class Bombito
    Dim bombcoord As Point = New Point(0, 0)
    Public bomblife As Integer = 15

    Public Sub New(Xbomb, ybomb)
        bombcoord.X = Xbomb
        bombcoord.Y = ybomb
        'gives the bomb its location

    End Sub

    Sub life()
        If bomblife > 0 Then
            bomblife = bomblife - 1
        End If
        'gives the bomb a decay

        If bomblife < 3 Then
            If bombcoord.Y < 100 And bombcoord.X > 400 And bombcoord.X < 600 And Form1.HasDoors(Form1.roomNumber - 1, 0) = 6 Then
                Form1.HasDoors(Form1.roomNumber - 1, 0) = 7
            End If
            If bombcoord.Y > 400 And bombcoord.X > 400 And bombcoord.X < 600 And Form1.HasDoors(Form1.roomNumber - 1, 1) = 6 Then
                Form1.HasDoors(Form1.roomNumber - 1, 1) = 7
            End If
            If bombcoord.X < 100 And bombcoord.Y > 200 And bombcoord.Y < 400 And Form1.HasDoors(Form1.roomNumber - 1, 2) = 6 Then
                Form1.HasDoors(Form1.roomNumber - 1, 2) = 7
            End If
            If bombcoord.X > 800 And bombcoord.Y > 200 And bombcoord.Y < 400 And Form1.HasDoors(Form1.roomNumber - 1, 3) = 6 Then
                Form1.HasDoors(Form1.roomNumber - 1, 3) = 7
            End If
            'bomb breaks down the door

            If bomblife = 2 Then
                If Form1.roomCoord.X > bombcoord.X - 100 And Form1.roomCoord.X < bombcoord.X + 100 Then
                    If Form1.roomCoord.Y > bombcoord.Y - 100 And Form1.roomCoord.Y < bombcoord.Y + 100 Then
                        Form1.health = Form1.health - 1
                        Form1.hint = "You're taking damage from the bomb, don't stand so close!"
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub drawBomb(g As Graphics)

        If bomblife <= 2 Then
            g.DrawImage(My.Resources.Fireball, bombcoord.X - 50, bombcoord.Y - 50, 100, 100)
            'draws the explosion of the bomb
        Else
            g.DrawImage(My.Resources.Bomb_Got, bombcoord.X - 15, bombcoord.Y - 15, 30, 30)
            'draws the bomb
        End If

    End Sub
End Class

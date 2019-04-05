Public Class Enemies
    Dim difference As Point = New Point(0, 0)
    Public enemyCoord As Point = New Point()
    Public enemysize As Point = New Point(75, 75)
    Dim hypotenuse As Decimal
    Dim gradient2five As Decimal
    Dim enemyspeed As Integer = 10
    Public touched As Boolean = False

    Public Sub New(Xenemy, yenemy)
        enemyCoord.X = Xenemy
        enemyCoord.Y = yenemy
    End Sub

    Sub maths()
        difference.X = (Form1.roomCoord.X - (enemyCoord.X + enemysize.X / 2))
        difference.Y = ((Form1.roomCoord.Y - Form1.playersize.Y / 2) - enemyCoord.Y)
        hypotenuse = Math.Sqrt(difference.X ^ 2 + difference.Y ^ 2)
        'gets the hypotenuse of the player and the enemy 

        If hypotenuse <> 0 Then
            gradient2five = enemyspeed / hypotenuse
            'makes the vector to be addeed to the enemy (always equal to 5)
        End If
    End Sub
    'does all the math function for the tracking ai

    Sub track()
        If Form1.paused = False Then

            If enemyCoord.X <> Form1.roomCoord.X Then
                enemyCoord.X = enemyCoord.X + difference.X * gradient2five
            End If
            If enemyCoord.Y <> Form1.roomCoord.Y Then
                enemyCoord.Y = enemyCoord.Y + difference.Y * gradient2five
            End If
            'adds a fixed calculated amount to both the x and the y of the enemy
        End If
    End Sub
    'tracks the user 

    Sub checkIfBeingTouched()

        If Form1.roomCoord.X + (Form1.playerhitbox.X / 2) > enemyCoord.X And Form1.roomCoord.X - (Form1.playerhitbox.X / 2) < enemyCoord.X + enemysize.X And Form1.roomCoord.Y < (enemyCoord.Y + enemysize.Y) And Form1.roomCoord.Y > enemyCoord.Y Then
            touched = True
        Else
            touched = False
        End If

    End Sub

    Public Sub drawEnemy(g As Graphics)
        g.DrawImage(My.Resources.Enemy, enemyCoord.X, enemyCoord.Y, enemysize.X, enemysize.Y)
    End Sub

End Class

Public Class Objects
    Public objectcoord As Point = New Point()
    Dim pressurePlateSize As Point = New Point(50, 50)
    Public firesize As Point = New Point(60, 60)
    Public pressed As Boolean


    Public Sub New(Xpressure, Ypressure, pressedcheck)
        objectcoord.X = Xpressure
        objectcoord.Y = Ypressure
        pressed = pressedcheck
    End Sub

    Sub pressurePlatePressCheck()
        If Form1.roomCoord.X + (Form1.playerhitbox.X / 2) > objectcoord.X And Form1.roomCoord.X - (Form1.playerhitbox.X / 2) < objectcoord.X + pressurePlateSize.X Then
            If Form1.roomCoord.Y + (Form1.playerhitbox.Y / 2) > objectcoord.Y And Form1.roomCoord.Y - (Form1.playerhitbox.Y / 2) < objectcoord.Y + pressurePlateSize.Y Then
                pressed = True
            End If
        End If
    End Sub

    Sub checkForWalkingOnFire()
        If Form1.roomCoord.X + (Form1.playerhitbox.X / 2) > objectcoord.X And Form1.roomCoord.X - (Form1.playerhitbox.X / 2) < objectcoord.X + firesize.X And Form1.roomCoord.Y + (Form1.playerhitbox.Y / 2) > objectcoord.Y And Form1.roomCoord.Y - (Form1.playerhitbox.Y / 2) < objectcoord.Y + firesize.Y Then
            pressed = True
        Else
            pressed = False
        End If
        'checks if the user is walking on a fire
    End Sub

    Public Sub drawPressure(g As Graphics)
        g.DrawImage(My.Resources.PressurePlate, objectcoord.X, objectcoord.Y, pressurePlateSize.X, pressurePlateSize.Y)
    End Sub

    Public Sub drawPressedPressure(g As Graphics)
        If pressed = True Then
            g.DrawImage(My.Resources.PressurePlateDown, objectcoord.X, objectcoord.Y, pressurePlateSize.X, pressurePlateSize.Y)
        End If
    End Sub
    Public Sub drawFires(g As Graphics)
        g.DrawImage(My.Resources.Fire_Symbol, objectcoord.X, objectcoord.Y, firesize.X, firesize.Y)
    End Sub
End Class

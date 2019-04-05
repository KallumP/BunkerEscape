Public Class Death_Screen
    Private Sub Death_Screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Form1.roomNumber = 7
        Form1.globalCoord = New Point(2, 2)
        Form1.playerVelocity = New Point(0, 0)
        Form1.roomCoord = New Point(510, 280)
        Form1.health = 6
        Form1.beingAttacked = False
        'resets the location of the user

        Form1.kDpressed = False
        Form1.kUpressed = False
        Form1.kLpressed = False
        Form1.kRpressed = False
        'stops the user from moving when the game starts up again

        Form1.badGuys.Clear()
        Form1.pressure.Clear()
        Form1.pressuredown.Clear()
        Form1.projectile.Clear()
        Form1.fires.Clear()
        'removes all the objects from the game

        My.Forms.Death_Screen.Close()
        My.Forms.Form1.Show()
    End Sub
End Class
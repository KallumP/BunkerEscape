Public Class Attacker

    Public attackcoord As Point = New Point(0, 0)
    Dim attackvelocity As Point = New Point(0, 0)
    Public attackSize As Point = New Point(30, 30)
    Public timeToDie As Integer = 10
    Dim accelaration As Decimal = 0.5

    Public Sub New(Xattack, Yattack, firstCoordX, firstCoordY)
        attackvelocity.X = Xattack
        attackvelocity.Y = Yattack
        attackcoord.X = firstCoordX
        attackcoord.Y = firstCoordY
    End Sub


    Public Sub moveAttack()
        If attackvelocity.X < 0 Then
            attackvelocity.X = attackvelocity.X + accelaration
        ElseIf attackvelocity.x > 0 Then
            attackvelocity.X = attackvelocity.X - accelaration
        End If

        attackcoord.X = attackcoord.X + attackvelocity.X
        attackcoord.Y = attackcoord.Y + attackvelocity.Y

        timeToDie = timeToDie - 1

    End Sub

    Public Sub drawAttack(g As Graphics)
        g.DrawImage(My.Resources.Fireball, attackcoord.X, attackcoord.Y, attackSize.X, attackSize.Y)
    End Sub


End Class

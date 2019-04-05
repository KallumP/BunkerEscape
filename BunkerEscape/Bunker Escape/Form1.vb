Public Class Form1
    Public health As Integer = 6
    Public globalCoord As Point = New Point(2, 2)
    Public playersize As Point = New Point(75, 150)
    Public playerhitbox As Point = New Point(60, 30)
    Public roomCoord As Point = New Point(510, 280)
    Public playerVelocity As Point = New Point(0, 0)
    Public roomNumber As Integer = 7
    Dim walkspeed As Integer = 20
    Dim runspeed As Integer = 30
    Dim speed As Integer = walkspeed

    Dim FPS As Integer = 60

    Public kDpressed As Boolean
    Public kUpressed As Boolean
    Public kLpressed As Boolean
    Public kRpressed As Boolean

    Public roomFinished() As Boolean = {
        False,  '1
        False,  '2
        False,  '3
        False,  '4
        False,  '5
        False,  '6
        False,  '7
        False,  '8
        False,  '9
        False,  '10
        False,  '11
        False,  '12
        False}  '13

    Public paused As Boolean = False

    Dim firedamage As Integer = 10
    Dim damageBuffer As Integer = 5
    Dim firedamagememe As Integer = firedamage
    Dim attackspeed As Integer = 30
    Public beingAttacked As Boolean = False
    Public walkingOnFire As Boolean = False

    Public bombDown As Boolean = False

    Public projectile As New List(Of Attacker)
    Public bombs As New List(Of Bombito)
    Public badGuys As New List(Of Enemies)
    Public pressure As New List(Of Objects)
    Public pressuredown As New List(Of Objects)
    Public fires As New List(Of Objects)

    Dim keysAmount As Integer = 0
    Dim puzzlePieceAmount As Integer = 1
    Dim attackinfo() = {3, False, 512, 275}
    Dim bombinfo() = {8, False, 510, 280}
    Dim tunicinfo() = {4, False, 510, 280}
    Dim keyinfo(,) =
                      {{2, False, 510, 280},
                      {10, False, 120, 270},
                      {12, False, 510, 280}}
    Dim Puzzleinfo(,) =
                       {{1, False, 510, 280},
                       {5, False, 510, 280},
                       {9, False, 510, 280}}
    '          roomnumber,   got,   x,   y

    Public hint As String = "This is where the hints are displayed"

    Public HasDoors(,) As Integer = {
        {0, 1, 0, 0},    'room 2, 0 | 1
        {0, 0, 0, 1},    'room 1, 1 | 2
        {4, 1, 1, 6},    'room 2, 1 | 3
        {0, 0, 1, 0},    'room 3, 1 | 4
        {0, 0, 0, 1},    'room 0, 2 | 5
        {0, 6, 3, 1},    'room 1, 2 | 6
        {1, 5, 1, 1},    'room 2, 2 | 7
        {0, 1, 1, 2},    'room 3, 2 | 8
        {0, 0, 1, 0},    'room 4, 2 | 9
        {1, 0, 0, 0},    'room 1, 3 |10
        {1, 0, 0, 0},    'room 2, 3 |11
        {1, 0, 0, 0}}    'room 3, 3 |12
    'up,down,left,right

    ' 1 = open door
    ' 2 = Locked with one key
    ' 3 = locked with two keys
    ' 4 = locked with three keys
    ' 5 = puzzle door
    ' 6 = cracked wall
    ' 7 = bombed down wall


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles timer_gameloop.Tick
        FPSFix()
        moveplayer()
        checkForItems()
        unlockDoors()
        takefiredamage()
        moveRooms()

        If roomNumber = 11 Then
            endgame()
        End If
        'lets the user enter the final room which ends the game

        listStuff()
        attackedTimer()
        'handles all the list loops

        If paused = False Then
            Pic_Items.Invalidate()
            pic_Main_Game.Invalidate()
            Pic_Minimap.Invalidate()
            Pic_Hearts.Invalidate()
        End If

        If health < 1 Then
            youDied()
        End If

        txt_CharY.Text = roomCoord.Y
        txt_CharX.Text = roomCoord.X
        txt_GlobeX.Text = globalCoord.X
        txt_GlobeY.Text = globalCoord.Y
        txt_GlobeZ.Text = roomNumber
        txt_FireDamage.Text = firedamagememe
        txt_speedX.Text = playerVelocity.X
        txt_speedY.Text = playerVelocity.Y
        txt_Hint.Text = hint
        txt_attack.Text = damageBuffer
        FPSCounter.Text = FPS
    End Sub
    'gameloop

    Sub attackedTimer()
        If beingAttacked = True Or walkingOnFire = True Then
            damageBuffer -= 1
        End If
        If beingAttacked = True Then
            hint = "You are taking damage from the enemies, try not to touch them"
        ElseIf walkingOnFire = True Then
            hint = "You are taking damage from the fire, not even your tunic will help you"
        End If
        If damageBuffer = 0 Then
            health = health - 1
            damageBuffer = 5
        End If
    End Sub
    'makes is to so that the player doesnt take damage too quickly, player only takes damage once every 5 ticks if they are to take damage

    Sub listStuff()
        For p = projectile.Count - 1 To 0 Step -1
            projectile(p).moveAttack()
            If projectile(p).timeToDie = 0 Then
                projectile.RemoveAt(p)
            End If
        Next
        'moves and kills projectiles

        For b = bombs.Count - 1 To 0 Step -1
            bombs(b).life()
            If bombs(b).bomblife = 0 Then
                bombs.RemoveAt(b)
                bombDown = False
            End If
        Next
        'decays, and kills the bomb

        For x = badGuys.Count - 1 To 0 Step -1
            badGuys(x).track()
            badGuys(x).maths()
        Next
        'does the maths for the enemy ai

        For i = badGuys.Count - 1 To 0 Step -1
            For o = projectile.Count - 1 To 0 Step -1
                If projectile(o).attackcoord.X + projectile(o).attackSize.X > badGuys(i).enemyCoord.X And projectile(o).attackcoord.X < badGuys(i).enemyCoord.X + badGuys(i).enemysize.X Then
                    If projectile(o).attackcoord.Y + projectile(o).attackSize.Y > badGuys(i).enemyCoord.Y And projectile(o).attackcoord.Y < badGuys(i).enemyCoord.Y + badGuys(i).enemysize.Y Then
                        badGuys.RemoveAt(i)
                        projectile.RemoveAt(o)
                    End If
                End If
            Next
        Next
        'checks if the user has hit any enemy with any of his bullets

        beingAttacked = False
        For i = badGuys.Count - 1 To 0 Step -1
            badGuys(i).checkIfBeingTouched()
            If badGuys(i).touched = True Then
                beingAttacked = True
            End If
        Next
        'the enemies deal damage if it touches the user

        walkingOnFire = False
        For i As Integer = fires.Count - 1 To 0 Step -1
            fires(i).checkForWalkingOnFire()
            If fires(i).pressed = True Then
                walkingOnFire = True
            End If
        Next
        'checks to see if the user is walking over fire

        For x = pressure.Count - 1 To 0 Step -1
            pressure(x).pressurePlatePressCheck()
            If pressure(x).pressed = True Then
                pressure.RemoveAt(x)
            End If
        Next
        'gets rid of the pressure plates once they have been stepped on

        For x = pressuredown.Count - 1 To 0 Step -1
            pressuredown(x).pressurePlatePressCheck()
        Next
        'changes the pressureplate value to pressed (only for drawing the pressed pressure plate)

        If badGuys.Count = 0 And pressure.Count = 0 Then
            roomFinished(roomNumber - 1) = True
        End If
        'changes the room's state to finished once everything is done

    End Sub
    'deals with all the list code

    Sub checkForItems()
        If roomNumber = attackinfo(0) And roomFinished(roomNumber - 1) = True Then
            If roomCoord.X > attackinfo(2) And roomCoord.X < attackinfo(2) + 50 And roomCoord.Y > attackinfo(3) And roomCoord.Y < attackinfo(3) + 50 And attackinfo(1) = False Then
                attackinfo(1) = True
            End If
        ElseIf roomNumber = bombinfo(0) And roomFinished(roomNumber - 1) = True Then
            If roomCoord.X > bombinfo(2) And roomCoord.X < bombinfo(2) + 50 And roomCoord.Y > bombinfo(3) And roomCoord.Y < bombinfo(3) + 50 And bombinfo(1) = False Then
                bombinfo(1) = True
            End If
        ElseIf roomNumber = tunicinfo(0) And roomFinished(roomNumber - 1) = True Then
            If roomCoord.X > tunicinfo(2) And roomCoord.X < tunicinfo(2) + 50 And roomCoord.Y > tunicinfo(3) And roomCoord.Y < tunicinfo(3) + 50 And tunicinfo(1) = False Then
                tunicinfo(1) = True
            End If
        ElseIf roomNumber = keyinfo(0, 0) And roomFinished(roomNumber - 1) = True Then
            If roomCoord.X > keyinfo(0, 2) And roomCoord.X < keyinfo(0, 2) + 50 And roomCoord.Y > keyinfo(0, 3) And roomCoord.Y < keyinfo(0, 3) + 50 And keyinfo(0, 1) = False Then
                keyinfo(0, 1) = True
                keysAmount = keysAmount + 1
            End If
        ElseIf roomNumber = keyinfo(1, 0) And roomFinished(roomNumber - 1) = True Then
            If roomCoord.X > keyinfo(1, 2) And roomCoord.X < keyinfo(1, 2) + 50 And roomCoord.Y > keyinfo(1, 3) And roomCoord.Y < keyinfo(1, 3) + 50 And keyinfo(1, 1) = False Then
                keyinfo(1, 1) = True
                keysAmount = keysAmount + 1
            End If
        ElseIf roomNumber = keyinfo(2, 0) And roomFinished(roomNumber - 1) = True Then
            If roomCoord.X > keyinfo(2, 2) And roomCoord.X < keyinfo(2, 2) + 50 And roomCoord.Y > keyinfo(2, 3) And roomCoord.Y < keyinfo(2, 3) + 50 And keyinfo(2, 1) = False Then
                keyinfo(2, 1) = True
                keysAmount = keysAmount + 1
            End If
        ElseIf roomNumber = Puzzleinfo(0, 0) And roomFinished(roomNumber - 1) = True Then
            If roomCoord.X > Puzzleinfo(0, 2) And roomCoord.X < Puzzleinfo(0, 2) + 50 And roomCoord.Y > Puzzleinfo(0, 3) And roomCoord.Y < Puzzleinfo(0, 3) + 50 And Puzzleinfo(0, 1) = False Then
                Puzzleinfo(0, 1) = True
                puzzlePieceAmount += 1
            End If
        ElseIf roomNumber = Puzzleinfo(1, 0) And roomFinished(roomNumber - 1) = True Then
            If roomCoord.X > Puzzleinfo(1, 2) And roomCoord.X < Puzzleinfo(1, 2) + 50 And roomCoord.Y > Puzzleinfo(1, 3) And roomCoord.Y < Puzzleinfo(1, 3) + 50 And Puzzleinfo(1, 1) = False Then
                Puzzleinfo(1, 1) = True
                puzzlePieceAmount += 1
            End If
        ElseIf roomNumber = Puzzleinfo(2, 0) And roomFinished(roomNumber - 1) = True Then
            If roomCoord.X > Puzzleinfo(2, 2) And roomCoord.X < Puzzleinfo(2, 2) + 50 And roomCoord.Y > Puzzleinfo(2, 3) And roomCoord.Y < Puzzleinfo(2, 3) + 50 And Puzzleinfo(2, 1) = False Then
                Puzzleinfo(2, 1) = True
                puzzlePieceAmount += 1
            End If
        End If
        'takes the user's coordinates and checks if the item is in the same room, and then if the user is in the item, it makes the item "got"
    End Sub
    'checks for if the user walks over an item

    Sub unlockDoors()
        If keysAmount = 1 Then
            HasDoors(7, 3) = 1
        End If
        If keysAmount = 2 Then
            HasDoors(5, 2) = 1
        End If
        If keysAmount = 3 Then
            HasDoors(2, 0) = 1
        End If
        'unlcoks doors when picking up keys
        If puzzlePieceAmount = 4 Then
            HasDoors(6, 1) = 1
        End If
        'unlocks doors when the user has enough puzzle pieces
    End Sub
    'unlocks the doors

    Sub takefiredamage()
        If paused = False Then
            If firedamagememe > 0 And globalCoord.X < 2 And globalCoord.Y > 1 And tunicinfo(1) = False Then
                firedamagememe = firedamagememe - 1
                hint = "You're taking fire damage, try and find clothing that will protect you from this blazing heat"
                'checks if the user is in the fire rooms without a tunic, and takes away a firedamage point every tick
            ElseIf firedamagememe = 0 And globalCoord.X < 2 And globalCoord.Y > 1 And tunicinfo(1) = False And health > 0 Then
                health = health - 1
                firedamagememe = 10
                'when the firedamage points hit 0 it checks if the user is still in the fire rooms, and doesnt have a tunic, and then takes away a heart
            Else
                firedamagememe = 10
                'sets the firedamage back to 30 if the user is not in a fire room
            End If
        End If
    End Sub
    'takes damage from the user when in the fire room without a tunic

    Private Sub Settings_UI_Click(sender As Object, e As EventArgs) Handles Pic_Settings.Click
        hint = ""
        PauseGame()
        'causes the pause routine to run if the player clicks the settings icon
    End Sub
    'paused the game when clicking the settings icon

    Public Sub PauseGame()
        paused = Not paused
        If paused = True Then
            hint = "Paused, click the settings button to unpause"
        End If
    End Sub
    'pauses the game

    Sub moveRooms()
        Dim doorsUp() As Decimal = {pic_Main_Game.Width / 2 - 50, pic_Main_Game.Width / 2 + 50, 105}
        Dim doorsDown() As Decimal = {pic_Main_Game.Width / 2 - 50, pic_Main_Game.Width / 2 + 50, 465}
        Dim doorsLeft() As Integer = {pic_Main_Game.Height / 2 - 50, pic_Main_Game.Height / 2 + 50, 120}
        Dim doorsRight() As Integer = {pic_Main_Game.Height / 2 - 50, pic_Main_Game.Height / 2 + 50, 905}

        If HasDoors(roomNumber - 1, 0) = 1 Or HasDoors(roomNumber - 1, 0) = 7 Then
            If roomCoord.Y < doorsUp(2) - 10 And roomCoord.X > doorsUp(0) And roomCoord.X < doorsUp(1) Then
                globalCoord.Y = globalCoord.Y - 1
                'changes the global coordinates
                roomCoord.Y = doorsDown(2) - 10
                roomCoord.X = pic_Main_Game.Width / 2
                'sets the players coordinates to the bottom, after leaving through the top
                fixRoomNumber()
                checkforPuzzles()
                'draws out enemies and puzzles if the room isnt cleared
            End If
            'checks if the user has gone through the top door
        ElseIf HasDoors(roomNumber - 1, 0) = 6 Then
            If roomCoord.Y < doorsUp(2) - 10 And roomCoord.X > doorsUp(0) And roomCoord.X < doorsUp(1) Then
                hint = "There seems to be a crack here, maybe I can destroy this part of the wall"
            End If
        ElseIf HasDoors(roomNumber - 1, 0) = 2 Or HasDoors(roomNumber - 1, 0) = 3 Or HasDoors(roomNumber - 1, 0) = 4 Then
            If roomCoord.Y < doorsUp(2) - 10 And roomCoord.X > doorsUp(0) And roomCoord.X < doorsUp(1) Then
                hint = "I need more keys to open this"
            End If
        End If
        'Deals with entering the up doors

        If HasDoors(roomNumber - 1, 1) = 1 Or HasDoors(roomNumber - 1, 1) = 7 Then
            If roomCoord.Y > doorsDown(2) + 10 And roomCoord.X > doorsDown(0) And roomCoord.X < doorsDown(1) Then
                globalCoord.Y = globalCoord.Y + 1
                'changes the global coordinates
                roomCoord.Y = doorsUp(2) + 10
                roomCoord.X = pic_Main_Game.Width / 2
                'sets the players coordinates to the top, after leaving through the bottom
                fixRoomNumber()
                checkforPuzzles()
                'draws out enemies and puzzles if the room isnt cleared
            End If
            'checks if the user has gone through the bottom door
        ElseIf HasDoors(roomNumber - 1, 1) = 6 Then
            If roomCoord.Y > doorsDown(2) + 10 And roomCoord.X > doorsDown(0) And roomCoord.X < doorsDown(1) Then
                hint = "There seems to be a crack here, maybe I can destroy this part of the wall"
            End If
        ElseIf HasDoors(roomNumber - 1, 1) = 2 Or HasDoors(roomNumber - 1, 1) = 3 Or HasDoors(roomNumber - 1, 1) = 4 Then
            If roomCoord.Y > doorsDown(2) + 10 And roomCoord.X > doorsDown(0) And roomCoord.X < doorsDown(1) Then
                hint = "I need more keys to open this"
            End If
        End If

        If HasDoors(roomNumber - 1, 2) = 1 Or HasDoors(roomNumber - 1, 2) = 7 Then
            If roomCoord.X < doorsLeft(2) - 10 And roomCoord.Y > doorsLeft(0) And roomCoord.Y < doorsLeft(1) Then
                globalCoord.X = globalCoord.X - 1
                'changes the global coordinates
                roomCoord.X = doorsRight(2) - 10
                roomCoord.Y = pic_Main_Game.Height / 2
                'sets the players coordinates to the right, after leaving through the left
                fixRoomNumber()
                checkforPuzzles()
                'draws out enemies and puzzles if the room isnt cleared
            End If
            'checks if the user has gone through the left door
        ElseIf HasDoors(roomNumber - 1, 2) = 6 Then
            If roomCoord.X < doorsLeft(2) - 10 And roomCoord.Y > doorsLeft(0) And roomCoord.Y < doorsLeft(1) Then
                hint = "There seems to be a crack here, maybe I can destroy this part of the wall"
            End If
        ElseIf HasDoors(roomNumber - 1, 2) = 2 Or HasDoors(roomNumber - 1, 2) = 3 Or HasDoors(roomNumber - 1, 2) = 4 Then
            If roomCoord.X < doorsLeft(2) - 10 And roomCoord.Y > doorsLeft(0) And roomCoord.Y < doorsLeft(1) Then
                hint = "I need more keys to open this"
            End If
        End If

        If HasDoors(roomNumber - 1, 3) = 1 Or HasDoors(roomNumber - 1, 3) = 7 Then
            If roomCoord.X > doorsRight(2) + 10 And roomCoord.Y > doorsRight(0) And roomCoord.Y < doorsRight(1) Then
                globalCoord.X = globalCoord.X + 1
                'changes the global coordinates
                roomCoord.X = doorsLeft(2) + 10
                roomCoord.Y = pic_Main_Game.Height / 2
                'sets the players coordinates to the left, after leaving through the right
                fixRoomNumber()
                checkforPuzzles()
                'draws out enemies and puzzles if the room isnt cleared
            End If
            'checks if the user has gone through the right door
        ElseIf HasDoors(roomNumber - 1, 3) = 6 Then
            If roomCoord.X > doorsRight(2) + 10 And roomCoord.Y > doorsRight(0) And roomCoord.Y < doorsRight(1) Then
                hint = "There seems to be a crack here, maybe I can destroy this part of the wall"
            End If
        ElseIf HasDoors(roomNumber - 1, 3) = 2 Or HasDoors(roomNumber - 1, 3) = 3 Or HasDoors(roomNumber - 1, 3S) = 4 Then
            If roomCoord.X > doorsRight(2) + 10 And roomCoord.Y > doorsRight(0) And roomCoord.Y < doorsRight(1) Then
                hint = "I need more keys to open this"
            End If
        End If
    End Sub
    'checks the available rooms the user can walk into from the room they are in

    Sub fixRoomNumber()
        If globalCoord.X = 2 And globalCoord.Y = 0 Then
            roomNumber = 1
        ElseIf globalCoord.X = 1 And globalCoord.Y = 1 Then
            roomNumber = 2
        ElseIf globalCoord.X = 2 And globalCoord.Y = 1 Then
            roomNumber = 3
        ElseIf globalCoord.X = 3 And globalCoord.Y = 1 Then
            roomNumber = 4
        ElseIf globalCoord.X = 0 And globalCoord.Y = 2 Then
            roomNumber = 5
        ElseIf globalCoord.X = 1 And globalCoord.Y = 2 Then
            roomNumber = 6
        ElseIf globalCoord.X = 2 And globalCoord.Y = 2 Then
            roomNumber = 7
        ElseIf globalCoord.X = 3 And globalCoord.Y = 2 Then
            roomNumber = 8
        ElseIf globalCoord.X = 4 And globalCoord.Y = 2 Then
            roomNumber = 9
        ElseIf globalCoord.X = 1 And globalCoord.Y = 3 Then
            roomNumber = 10
        ElseIf globalCoord.X = 2 And globalCoord.Y = 3 Then
            roomNumber = 11
        ElseIf globalCoord.X = 3 And globalCoord.Y = 3 Then
            roomNumber = 12
        End If
        'assigns the number for the code to access the array about doors
    End Sub
    'deals with creating the room number for the player (global coordinate alternitive)

    Sub checkforPuzzles()
        badGuys.Clear()
        pressure.Clear()
        pressuredown.Clear()
        projectile.Clear()
        fires.Clear()
        bombs.Clear()

        FileOpen(1, Application.StartupPath & "\bin\debug\Level Properties\" & roomNumber & " - Pressure.txt", OpenMode.Input)
        Dim tempcoord As Point = New Point()
        Dim destroyed As Boolean
        Dim memeboi As Integer

        While Not EOF(1)
            Input(1, memeboi)
            Input(1, tempcoord.X)
            Input(1, tempcoord.Y)
            Input(1, destroyed)
            If roomFinished(roomNumber - 1) = False Then
                If memeboi = 0 Then
                    pressure.Add(New Objects(tempcoord.X, tempcoord.Y, destroyed))
                    pressuredown.Add(New Objects(tempcoord.X, tempcoord.Y, destroyed))
                ElseIf memeboi = 2 Then
                    badGuys.Add(New Enemies(tempcoord.X, tempcoord.Y))
                ElseIf memeboi = 1 Then
                    fires.Add(New Objects(tempcoord.X, tempcoord.Y, destroyed))
                End If
                'these are only added to the lists if the room is not completeted
            Else
                If memeboi = 1 Then
                    fires.Add(New Objects(tempcoord.X, tempcoord.Y, destroyed))
                End If
                'makes it so that the fire is displayed even after the room is completed
            End If
        End While
        FileClose(1)
    End Sub
    'uses the file

    Private Sub Movement(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If paused = False Then
            If e.KeyCode = Keys.A And kLpressed = False Then
                playerVelocity.X = playerVelocity.X - speed
                kLpressed = True
            ElseIf e.KeyCode = Keys.D And kRpressed = False Then
                playerVelocity.X = playerVelocity.X + speed
                kRpressed = True
            End If
            If e.KeyCode = Keys.W And kUpressed = False Then
                playerVelocity.Y = playerVelocity.Y - speed
                kUpressed = True
            ElseIf e.KeyCode = Keys.S And kDpressed = False Then
                playerVelocity.Y = playerVelocity.Y + speed
                kDpressed = True
            End If
            'movement
        End If
    End Sub
    Private Sub UnMovement(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If paused = False Then
            If e.KeyCode = Keys.A Then
                playerVelocity.X = playerVelocity.X + speed
                kLpressed = False
            ElseIf e.KeyCode = Keys.D Then
                playerVelocity.X = playerVelocity.X - speed
                kRpressed = False
            End If
            If e.KeyCode = Keys.W Then
                playerVelocity.Y = playerVelocity.Y + speed
                kUpressed = False
            ElseIf e.KeyCode = Keys.S Then
                playerVelocity.Y = playerVelocity.Y - speed
                kDpressed = False
            End If
            'takes a keypress and moves the character
        End If
    End Sub
    Sub moveplayer()
        roomCoord.X = roomCoord.X + playerVelocity.X
        roomCoord.Y = roomCoord.Y + playerVelocity.Y
        'adds on the speed value every tick of the timer
        If roomCoord.X - playerhitbox.X / 2 < 50 Then
            roomCoord.X = 50 + playerhitbox.X / 2
        End If
        If roomCoord.X + playerhitbox.X / 2 > 950 Then
            roomCoord.X = 950 - playerhitbox.X / 2
        End If
        If roomCoord.Y - playerhitbox.Y / 2 < 70 Then
            roomCoord.Y = 70 + playerhitbox.Y / 2
        End If
        If roomCoord.Y + playerhitbox.X / 2 > 510 Then
            roomCoord.Y = 510 - playerhitbox.Y / 2
        End If
        'stops the user from not going throught the walls

    End Sub
    'gets the movment of the player using the arrow keys

    Private Sub Attack_check(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If paused = False Then
            If attackinfo(1) = True Then
                If e.KeyCode = Keys.Left Then
                    projectile.Add(New Attacker(-attackspeed + playerVelocity.X, playerVelocity.Y, roomCoord.X, roomCoord.Y - 50))
                End If
                'allows the user to attack in the left direction
                If e.KeyCode = Keys.Right Then
                    projectile.Add(New Attacker(attackspeed + playerVelocity.X, playerVelocity.Y, roomCoord.X, roomCoord.Y - 50))
                End If
                'allows the user to attack in the right direction
                If e.KeyCode = Keys.Up Then
                    projectile.Add(New Attacker(playerVelocity.X, -attackspeed + playerVelocity.Y, roomCoord.X, roomCoord.Y - 50))
                End If
                'allows the user to attack in the up direction
                If e.KeyCode = Keys.Down Then
                    projectile.Add(New Attacker(playerVelocity.X, attackspeed + playerVelocity.Y, roomCoord.X, roomCoord.Y - 50))
                End If
                'allows the user to attack in the down direction
            End If
            'takes a keypress and lets the user throw a projectile
        End If
    End Sub
    'allows the user to attack

    Private Sub Bomb_check(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If paused = False Then
            If e.KeyCode = Keys.ShiftKey And bombDown = False And bombinfo(1) = True Then
                bombs.Add(New Bombito(roomCoord.X, roomCoord.Y))
                bombDown = True
                'adds a new bomb into the bombs list
            End If
        End If
    End Sub
    'allows the user to put down one bomb  at a time

    Sub endgame()
        Me.Hide()
        My.Forms.Win_Screen.Show()
    End Sub
    Sub youDied()
        Me.Hide()
        My.Forms.Death_Screen.Show()
    End Sub
    'end screens and death screens

    Private Sub Settings_UI_Draw(sender As Object, e As PaintEventArgs) Handles Pic_Settings.Paint
        If paused = False Then
            e.Graphics.DrawImage(My.Resources.Settings_Icon, New Rectangle(0, 0, 100, 100))
            'Draws out the settings icon
        End If
    End Sub
    'draws the settings icon

    Private Sub Pic_Minimap_Paint(sender As Object, e As PaintEventArgs) Handles Pic_Minimap.Paint
        If paused = False Then
            e.Graphics.DrawImage(My.Resources.Minimap_Background, New Rectangle(0, 0, 125, 100))
            'draws the background of the minimap
            e.Graphics.DrawRectangle(Pens.Red, globalCoord.X * 25, globalCoord.Y * 25, 25, 25)
            'draws a red square around the room that you are in using the global variable
        End If
    End Sub
    'draws the minimap

    Private Sub Heart_UI_Draw(sender As Object, e As PaintEventArgs) Handles Pic_Hearts.Paint
        If paused = False Then
            For i As Integer = 1 To health
                If i < 4 Then
                    e.Graphics.DrawImage(My.Resources.Heart_Full, New Rectangle((i - 1) * 50, 0, 50, 50))
                Else
                    e.Graphics.DrawImage(My.Resources.Heart_Full, New Rectangle((i - 4) * 50, 50, 50, 50))
                End If
            Next
            'draws out the full hearts, when it gets to 3 hearts, it starts a new line

            For i As Integer = (health + 1) To 6
                If i < 4 Then
                    e.Graphics.DrawImage(My.Resources.Heart_Empty, New Rectangle((i - 1) * 50, 0, 50, 50))
                Else
                    e.Graphics.DrawImage(My.Resources.Heart_Empty, New Rectangle((i - 4) * 50, 50, 50, 50))
                End If
            Next
        End If
        'draws out the empty hearts, when it gets to 3 hearts, it starts a new line
    End Sub
    'draws the hearts out onto the UI

    Private Sub Item_UI_Draw(sender As Object, e As PaintEventArgs) Handles Pic_Items.Paint
        If paused = False Then
            If attackinfo(1) = True Then
                e.Graphics.DrawImage(My.Resources.Attack_Got, New Rectangle(0, 0, 100, 100))
            Else
                e.Graphics.DrawImage(My.Resources.Attack_NotGot, New Rectangle(0, 0, 100, 100))
            End If
            If bombinfo(1) = True Then
                e.Graphics.DrawImage(My.Resources.Bomb_Got, New Rectangle(100, 0, 100, 100))
            Else
                e.Graphics.DrawImage(My.Resources.Bomb_NotGot, New Rectangle(100, 0, 100, 100))
            End If
            If tunicinfo(1) = True Then
                e.Graphics.DrawImage(My.Resources.Tunic_Got, New Rectangle(200, 0, 100, 100))
            Else
                e.Graphics.DrawImage(My.Resources.Tunic_NotGot, New Rectangle(200, 0, 100, 100))
            End If

            If Puzzleinfo(0, 1) = True Then
                e.Graphics.DrawImage(My.Resources.Puzzle_1, New Rectangle(400, 0, 50, 60))
            End If
            If Puzzleinfo(1, 1) = True Then
                e.Graphics.DrawImage(My.Resources.Puzzle_2, New Rectangle(400, 50, 60, 50))
            End If
            If Puzzleinfo(2, 1) = True Then
                e.Graphics.DrawImage(My.Resources.Puzzle_3, New Rectangle(450, 40, 50, 60))
            End If
            'draws out the pickable puzzle pieces
            e.Graphics.DrawImage(My.Resources.Puzzle_4, New Rectangle(440, 0, 60, 50))
            'draws the pregot puzzle

            If keysAmount = 0 Then
                e.Graphics.DrawImage(My.Resources.Keys_NotGot, New Rectangle(300, 0, 100, 100))
            End If
            If keysAmount = 1 Then
                e.Graphics.DrawImage(My.Resources.Keys_Got, New Rectangle(300, 0, 100, 100))
                e.Graphics.DrawImage(My.Resources._1, New Rectangle(375, 70, 20, 20))
            ElseIf keysAmount = 2 Then
                e.Graphics.DrawImage(My.Resources.Keys_Got, New Rectangle(300, 0, 100, 100))
                e.Graphics.DrawImage(My.Resources._2, New Rectangle(375, 70, 20, 20))
            ElseIf keysAmount = 3 Then
                e.Graphics.DrawImage(My.Resources.Keys_Got, New Rectangle(300, 0, 100, 100))
                e.Graphics.DrawImage(My.Resources._3, New Rectangle(375, 70, 20, 20))
            End If
            'tells the user how many keys they have with a small number near the key icon
        End If
    End Sub
    'Checks if each item has been picked up, and displays each item icon in the UI accordingly

    Private Sub Draw_Game(sender As Object, e As PaintEventArgs) Handles pic_Main_Game.Paint
        Dim scaledownscreen As Decimal = 1920 / pic_Main_Game.Width
        Dim doorU As Point = New Point(pic_Main_Game.Width / 2 - (210 / scaledownscreen) / 2, 0)
        Dim doorD As Point = New Point(pic_Main_Game.Width / 2 - (210 / scaledownscreen) / 2, pic_Main_Game.Height - 130 / scaledownscreen)
        Dim doorL As Point = New Point(0, pic_Main_Game.Height / 2 - ((210 / scaledownscreen) / 2))
        Dim doorR As Point = New Point(pic_Main_Game.Width - 130 / scaledownscreen, pic_Main_Game.Height / 2 - ((210 / scaledownscreen) / 2))

        If roomNumber = 7 Then
            e.Graphics.DrawImage(My.Resources.Opening_Room, New Rectangle(0, 0, 1920 / scaledownscreen, 1080 / scaledownscreen))
        ElseIf globalCoord.Y < 2 Then
            e.Graphics.DrawImage(My.Resources.Water_Room, New Rectangle(0, 0, 1920 / scaledownscreen, 1080 / scaledownscreen))
        ElseIf globalCoord.X < 2 And globalCoord.Y > 1 Then
            e.Graphics.DrawImage(My.Resources.Fire_Room, New Rectangle(0, 0, 1920 / scaledownscreen, 1080 / scaledownscreen))
        ElseIf globalCoord.X > 2 And globalCoord.Y > 1 Then
            e.Graphics.DrawImage(My.Resources.Ice_Room, New Rectangle(0, 0, 1920 / scaledownscreen, 1080 / scaledownscreen))
        End If
        'draws out the room background depending on where on the map the user is

        If roomNumber = attackinfo(0) And attackinfo(1) = False And roomFinished(roomNumber - 1) = True Then
            e.Graphics.DrawImage(My.Resources.Attack_Got, New Rectangle(attackinfo(2), attackinfo(3), 50, 50))
        ElseIf roomNumber = bombinfo(0) And bombinfo(1) = False And roomFinished(roomNumber - 1) = True Then
            e.Graphics.DrawImage(My.Resources.Bomb_Got, New Rectangle(bombinfo(2), bombinfo(3), 50, 50))
        ElseIf roomNumber = tunicinfo(0) And tunicinfo(1) = False And roomFinished(roomNumber - 1) = True Then
            e.Graphics.DrawImage(My.Resources.Tunic_Got, New Rectangle(tunicinfo(2), tunicinfo(3), 50, 50))
        ElseIf roomNumber = keyinfo(0, 0) And keyinfo(0, 1) = False And roomFinished(roomNumber - 1) = True Then
            e.Graphics.DrawImage(My.Resources.Keys_Got, New Rectangle(keyinfo(0, 2), keyinfo(0, 3), 50, 50))
        ElseIf roomNumber = keyinfo(1, 0) And keyinfo(1, 1) = False And roomFinished(roomNumber - 1) = True Then
            e.Graphics.DrawImage(My.Resources.Keys_Got, New Rectangle(keyinfo(1, 2), keyinfo(1, 3), 50, 50))
        ElseIf roomNumber = keyinfo(2, 0) And keyinfo(2, 1) = False And roomFinished(roomNumber - 1) = True Then
            e.Graphics.DrawImage(My.Resources.Keys_Got, New Rectangle(keyinfo(2, 2), keyinfo(2, 3), 50, 50))
        ElseIf roomNumber = Puzzleinfo(0, 0) And Puzzleinfo(0, 1) = False And roomFinished(roomNumber - 1) = True Then
            e.Graphics.DrawImage(My.Resources.Puzzle_1, New Rectangle(Puzzleinfo(0, 2), Puzzleinfo(0, 3), 50, 50))
        ElseIf roomNumber = Puzzleinfo(1, 0) And Puzzleinfo(1, 1) = False And roomFinished(roomNumber - 1) = True Then
            e.Graphics.DrawImage(My.Resources.Puzzle_2, New Rectangle(Puzzleinfo(1, 2), Puzzleinfo(1, 3), 50, 50))
        ElseIf roomNumber = Puzzleinfo(2, 0) And Puzzleinfo(2, 1) = False And roomFinished(roomNumber - 1) = True Then
            e.Graphics.DrawImage(My.Resources.Puzzle_3, New Rectangle(Puzzleinfo(2, 2), Puzzleinfo(2, 3), 50, 50))
        End If
        'checks if the user is in the same room as the item, and then draws the item at its coordinates

        If HasDoors(roomNumber - 1, 0) = 1 Then
            e.Graphics.DrawImage(My.Resources.Door_Up, New Rectangle(doorU.X, doorU.Y, 210 / scaledownscreen, 130 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 0) = 4 Then
            e.Graphics.DrawImage(My.Resources.Up_3_Lock, New Rectangle(doorU.X, doorU.Y, 210 / scaledownscreen, 130 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 0) = 6 Then
            e.Graphics.DrawImage(My.Resources.Cracked_wall, New Rectangle(doorU.X, doorU.Y, 210 / scaledownscreen, 130 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 0) = 7 Then
            e.Graphics.DrawImage(My.Resources.Up_Bombed_Down, New Rectangle(doorU.X, doorU.Y, 210 / scaledownscreen, 130 / scaledownscreen))
        End If

        If HasDoors(roomNumber - 1, 1) = 1 Then
            e.Graphics.DrawImage(My.Resources.Door_Down, New Rectangle(doorD.X, doorD.Y, 210 / scaledownscreen, 130 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 1) = 5 Then
            e.Graphics.DrawImage(My.Resources.Puzzle_Door, New Rectangle(doorD.X, doorD.Y, 210 / scaledownscreen, 130 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 1) = 6 Then
            e.Graphics.DrawImage(My.Resources.Cracked_wall, New Rectangle(doorD.X, doorD.Y, 210 / scaledownscreen, 130 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 1) = 7 Then
            e.Graphics.DrawImage(My.Resources.Down_Bombed_Down, New Rectangle(doorD.X, doorD.Y, 210 / scaledownscreen, 130 / scaledownscreen))
        End If

        If HasDoors(roomNumber - 1, 2) = 1 Then
            e.Graphics.DrawImage(My.Resources.Door_Left, New Rectangle(doorL.X, doorL.Y, 130 / scaledownscreen, 210 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 2) = 3 Then
            e.Graphics.DrawImage(My.Resources.Left_1_Lock, New Rectangle(doorL.X, doorL.Y, 130 / scaledownscreen, 210 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 2) = 6 Then
            e.Graphics.DrawImage(My.Resources.Cracked_wall, New Rectangle(doorL.X, doorL.Y, 130 / scaledownscreen, 210 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 2) = 7 Then
            e.Graphics.DrawImage(My.Resources.Left_Bombed_Down, New Rectangle(doorL.X, doorL.Y, 130 / scaledownscreen, 210 / scaledownscreen))
        End If

        If HasDoors(roomNumber - 1, 3) = 1 Then
            e.Graphics.DrawImage(My.Resources.Door_Right, New Rectangle(doorR.X, doorR.Y, 130 / scaledownscreen, 210 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 3) = 2 Then
            e.Graphics.DrawImage(My.Resources.Right_2_Lock, New Rectangle(doorR.X, doorR.Y, 130 / scaledownscreen, 210 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 3) = 6 Then
            e.Graphics.DrawImage(My.Resources.Cracked_wall, New Rectangle(doorR.X, doorR.Y, 130 / scaledownscreen, 210 / scaledownscreen))
        ElseIf HasDoors(roomNumber - 1, 3) = 7 Then
            e.Graphics.DrawImage(My.Resources.Right_Bombed_Down, New Rectangle(doorR.X, doorR.Y, 130 / scaledownscreen, 210 / scaledownscreen))
        End If
        'draws out the layout of the room

        For Each x In badGuys
            x.drawEnemy(e.Graphics)
        Next

        For Each p In pressure
            p.drawPressure(e.Graphics)
        Next

        For Each p In pressuredown
            p.drawPressedPressure(e.Graphics)
        Next

        For Each f In fires
            f.drawFires(e.Graphics)
        Next
        'draws out list items

        If tunicinfo(1) = True Then
            e.Graphics.DrawImage(My.Resources.Character_Tunic, New Rectangle(roomCoord.X - playersize.X / 2, roomCoord.Y - playersize.Y, playersize.X, playersize.Y))
        ElseIf health > 3 Then
            e.Graphics.DrawImage(My.Resources.Character, New Rectangle(roomCoord.X - playersize.X / 2, roomCoord.Y - playersize.Y, playersize.X, playersize.Y))
        Else
            e.Graphics.DrawImage(My.Resources.Character_Damaged, New Rectangle(roomCoord.X - playersize.X / 2, roomCoord.Y - playersize.Y, playersize.X, playersize.Y))
        End If
        'draws out the player

        For Each p In projectile
            p.drawAttack(e.Graphics)
        Next
        For Each b In bombs
            b.drawBomb(e.Graphics)
        Next
        'draws out the bombs and the attacks

    End Sub
    'draws the game screen that one plays on

    Sub FPSFix()
        If FPS = 60 Then
            FPS = 58
        ElseIf FPS = 59 Then
            FPS = 57
        ElseIf FPS = 58 Then
            FPS = 59
        ElseIf FPS = 57 Then
            FPS = 60
        End If
    End Sub
    'fixes the fps of the game

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class

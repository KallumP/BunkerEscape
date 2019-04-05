<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Pic_Settings = New System.Windows.Forms.PictureBox()
        Me.Pic_Items = New System.Windows.Forms.PictureBox()
        Me.Pic_Hearts = New System.Windows.Forms.PictureBox()
        Me.Pic_Minimap = New System.Windows.Forms.PictureBox()
        Me.timer_gameloop = New System.Windows.Forms.Timer(Me.components)
        Me.txt_MouseX = New System.Windows.Forms.Label()
        Me.txt_MouseY = New System.Windows.Forms.Label()
        Me.txt_CharX = New System.Windows.Forms.Label()
        Me.txt_CharY = New System.Windows.Forms.Label()
        Me.txt_GlobeY = New System.Windows.Forms.Label()
        Me.txt_GlobeX = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_GlobeZ = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FPSCounter = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Resolution = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_FireDamage = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_attack = New System.Windows.Forms.Label()
        Me.pic_Main_Game = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_speedY = New System.Windows.Forms.Label()
        Me.txt_speedX = New System.Windows.Forms.Label()
        Me.txt_Hint = New System.Windows.Forms.Label()
        CType(Me.Pic_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Hearts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Minimap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic_Main_Game, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pic_Settings
        '
        Me.Pic_Settings.Location = New System.Drawing.Point(741, 12)
        Me.Pic_Settings.Name = "Pic_Settings"
        Me.Pic_Settings.Size = New System.Drawing.Size(100, 100)
        Me.Pic_Settings.TabIndex = 2
        Me.Pic_Settings.TabStop = False
        '
        'Pic_Items
        '
        Me.Pic_Items.Location = New System.Drawing.Point(235, 12)
        Me.Pic_Items.Name = "Pic_Items"
        Me.Pic_Items.Size = New System.Drawing.Size(500, 100)
        Me.Pic_Items.TabIndex = 1
        Me.Pic_Items.TabStop = False
        '
        'Pic_Hearts
        '
        Me.Pic_Hearts.Location = New System.Drawing.Point(79, 12)
        Me.Pic_Hearts.Name = "Pic_Hearts"
        Me.Pic_Hearts.Size = New System.Drawing.Size(150, 100)
        Me.Pic_Hearts.TabIndex = 0
        Me.Pic_Hearts.TabStop = False
        '
        'Pic_Minimap
        '
        Me.Pic_Minimap.Location = New System.Drawing.Point(848, 12)
        Me.Pic_Minimap.Name = "Pic_Minimap"
        Me.Pic_Minimap.Size = New System.Drawing.Size(125, 100)
        Me.Pic_Minimap.TabIndex = 29
        Me.Pic_Minimap.TabStop = False
        '
        'timer_gameloop
        '
        Me.timer_gameloop.Enabled = True
        Me.timer_gameloop.Interval = 1
        '
        'txt_MouseX
        '
        Me.txt_MouseX.AutoSize = True
        Me.txt_MouseX.Location = New System.Drawing.Point(185, 152)
        Me.txt_MouseX.Name = "txt_MouseX"
        Me.txt_MouseX.Size = New System.Drawing.Size(14, 13)
        Me.txt_MouseX.TabIndex = 34
        Me.txt_MouseX.Text = "X"
        '
        'txt_MouseY
        '
        Me.txt_MouseY.AutoSize = True
        Me.txt_MouseY.Location = New System.Drawing.Point(230, 152)
        Me.txt_MouseY.Name = "txt_MouseY"
        Me.txt_MouseY.Size = New System.Drawing.Size(14, 13)
        Me.txt_MouseY.TabIndex = 35
        Me.txt_MouseY.Text = "Y"
        '
        'txt_CharX
        '
        Me.txt_CharX.AutoSize = True
        Me.txt_CharX.Location = New System.Drawing.Point(185, 166)
        Me.txt_CharX.Name = "txt_CharX"
        Me.txt_CharX.Size = New System.Drawing.Size(14, 13)
        Me.txt_CharX.TabIndex = 36
        Me.txt_CharX.Text = "X"
        '
        'txt_CharY
        '
        Me.txt_CharY.AutoSize = True
        Me.txt_CharY.Location = New System.Drawing.Point(230, 166)
        Me.txt_CharY.Name = "txt_CharY"
        Me.txt_CharY.Size = New System.Drawing.Size(14, 13)
        Me.txt_CharY.TabIndex = 37
        Me.txt_CharY.Text = "Y"
        '
        'txt_GlobeY
        '
        Me.txt_GlobeY.AutoSize = True
        Me.txt_GlobeY.Location = New System.Drawing.Point(230, 180)
        Me.txt_GlobeY.Name = "txt_GlobeY"
        Me.txt_GlobeY.Size = New System.Drawing.Size(14, 13)
        Me.txt_GlobeY.TabIndex = 39
        Me.txt_GlobeY.Text = "Y"
        '
        'txt_GlobeX
        '
        Me.txt_GlobeX.AutoSize = True
        Me.txt_GlobeX.Location = New System.Drawing.Point(185, 180)
        Me.txt_GlobeX.Name = "txt_GlobeX"
        Me.txt_GlobeX.Size = New System.Drawing.Size(14, 13)
        Me.txt_GlobeX.TabIndex = 38
        Me.txt_GlobeX.Text = "X"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(118, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "mouse x, y"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(118, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "char x, y"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(118, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "global x, y, z"
        '
        'txt_GlobeZ
        '
        Me.txt_GlobeZ.AutoSize = True
        Me.txt_GlobeZ.Location = New System.Drawing.Point(275, 180)
        Me.txt_GlobeZ.Name = "txt_GlobeZ"
        Me.txt_GlobeZ.Size = New System.Drawing.Size(14, 13)
        Me.txt_GlobeZ.TabIndex = 46
        Me.txt_GlobeZ.Text = "Z"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(781, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "FPS"
        '
        'FPSCounter
        '
        Me.FPSCounter.AutoSize = True
        Me.FPSCounter.Location = New System.Drawing.Point(815, 152)
        Me.FPSCounter.Name = "FPSCounter"
        Me.FPSCounter.Size = New System.Drawing.Size(25, 13)
        Me.FPSCounter.TabIndex = 48
        Me.FPSCounter.Text = "120"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(751, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Resolution"
        '
        'Resolution
        '
        Me.Resolution.AutoSize = True
        Me.Resolution.Location = New System.Drawing.Point(815, 166)
        Me.Resolution.Name = "Resolution"
        Me.Resolution.Size = New System.Drawing.Size(67, 13)
        Me.Resolution.TabIndex = 50
        Me.Resolution.Text = "3840 × 2160"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(315, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "firedamagething"
        '
        'txt_FireDamage
        '
        Me.txt_FireDamage.AutoSize = True
        Me.txt_FireDamage.Location = New System.Drawing.Point(410, 152)
        Me.txt_FireDamage.Name = "txt_FireDamage"
        Me.txt_FireDamage.Size = New System.Drawing.Size(39, 13)
        Me.txt_FireDamage.TabIndex = 51
        Me.txt_FireDamage.Text = "Label1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(315, 166)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "attackbuffer"
        '
        'txt_attack
        '
        Me.txt_attack.AutoSize = True
        Me.txt_attack.Location = New System.Drawing.Point(410, 166)
        Me.txt_attack.Name = "txt_attack"
        Me.txt_attack.Size = New System.Drawing.Size(35, 13)
        Me.txt_attack.TabIndex = 53
        Me.txt_attack.Text = "labvle"
        '
        'pic_Main_Game
        '
        Me.pic_Main_Game.Cursor = System.Windows.Forms.Cursors.Cross
        Me.pic_Main_Game.Location = New System.Drawing.Point(12, 143)
        Me.pic_Main_Game.Name = "pic_Main_Game"
        Me.pic_Main_Game.Size = New System.Drawing.Size(1024, 576)
        Me.pic_Main_Game.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic_Main_Game.TabIndex = 26
        Me.pic_Main_Game.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(590, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 13)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "speed x, y"
        '
        'txt_speedY
        '
        Me.txt_speedY.AutoSize = True
        Me.txt_speedY.Location = New System.Drawing.Point(696, 151)
        Me.txt_speedY.Name = "txt_speedY"
        Me.txt_speedY.Size = New System.Drawing.Size(14, 13)
        Me.txt_speedY.TabIndex = 56
        Me.txt_speedY.Text = "Y"
        '
        'txt_speedX
        '
        Me.txt_speedX.AutoSize = True
        Me.txt_speedX.Location = New System.Drawing.Point(651, 151)
        Me.txt_speedX.Name = "txt_speedX"
        Me.txt_speedX.Size = New System.Drawing.Size(14, 13)
        Me.txt_speedX.TabIndex = 55
        Me.txt_speedX.Text = "X"
        '
        'txt_Hint
        '
        Me.txt_Hint.AutoSize = True
        Me.txt_Hint.Location = New System.Drawing.Point(12, 127)
        Me.txt_Hint.Name = "txt_Hint"
        Me.txt_Hint.Size = New System.Drawing.Size(39, 13)
        Me.txt_Hint.TabIndex = 58
        Me.txt_Hint.Text = "Label9"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 721)
        Me.Controls.Add(Me.txt_Hint)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_speedY)
        Me.Controls.Add(Me.txt_speedX)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_attack)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_FireDamage)
        Me.Controls.Add(Me.Resolution)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FPSCounter)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_GlobeZ)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_GlobeY)
        Me.Controls.Add(Me.txt_GlobeX)
        Me.Controls.Add(Me.txt_CharY)
        Me.Controls.Add(Me.txt_CharX)
        Me.Controls.Add(Me.txt_MouseY)
        Me.Controls.Add(Me.txt_MouseX)
        Me.Controls.Add(Me.Pic_Minimap)
        Me.Controls.Add(Me.pic_Main_Game)
        Me.Controls.Add(Me.Pic_Settings)
        Me.Controls.Add(Me.Pic_Items)
        Me.Controls.Add(Me.Pic_Hearts)
        Me.DoubleBuffered = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Pic_Settings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Items, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Hearts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Minimap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic_Main_Game, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pic_Hearts As PictureBox
    Friend WithEvents Pic_Items As PictureBox
    Friend WithEvents Pic_Settings As PictureBox
    Friend WithEvents Pic_Minimap As PictureBox
    Friend WithEvents timer_gameloop As Timer
    Friend WithEvents txt_MouseX As Label
    Friend WithEvents txt_MouseY As Label
    Friend WithEvents txt_CharX As Label
    Friend WithEvents txt_CharY As Label
    Friend WithEvents txt_GlobeY As Label
    Friend WithEvents txt_GlobeX As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_GlobeZ As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents FPSCounter As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Resolution As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_FireDamage As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_attack As Label
    Friend WithEvents pic_Main_Game As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_speedY As Label
    Friend WithEvents txt_speedX As Label
    Friend WithEvents txt_Hint As Label
End Class

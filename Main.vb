Imports System.Data.SQLite

Public Class Main
    Inherits System.Windows.Forms.Form

    ' Define session variables
    Private Minutes As Integer
    Private Seconds As Integer
    Private Hours As Integer
    Private Project As String
    Private Rate As Double

    ' Define the SQLite connection
    Private conn As SQLiteConnection

    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSetRate As System.Windows.Forms.Button
    Friend WithEvents btnSetProject As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents labelTotalCash As System.Windows.Forms.Label
    Friend WithEvents labelCurrentCash As System.Windows.Forms.Label
    Friend WithEvents labelTotalTime As System.Windows.Forms.Label
    Friend WithEvents labelCurrentTime As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ctxNotify As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuStart As System.Windows.Forms.MenuItem
    Friend WithEvents mnuChangeProject As System.Windows.Forms.MenuItem
    Friend WithEvents mnuStop As System.Windows.Forms.MenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ctxNotify = New System.Windows.Forms.ContextMenu()
        Me.mnuStart = New System.Windows.Forms.MenuItem()
        Me.mnuChangeProject = New System.Windows.Forms.MenuItem()
        Me.mnuStop = New System.Windows.Forms.MenuItem()
        Me.mnuClose = New System.Windows.Forms.MenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSetRate = New System.Windows.Forms.Button()
        Me.btnSetProject = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.labelTotalCash = New System.Windows.Forms.Label()
        Me.labelCurrentCash = New System.Windows.Forms.Label()
        Me.labelCurrentTime = New System.Windows.Forms.Label()
        Me.labelTotalTime = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenu = Me.ctxNotify
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Timer Stopped"
        Me.NotifyIcon1.Visible = True
        '
        'ctxNotify
        '
        Me.ctxNotify.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuStart, Me.mnuChangeProject, Me.mnuStop, Me.mnuClose})
        '
        'mnuStart
        '
        Me.mnuStart.Enabled = False
        Me.mnuStart.Index = 0
        Me.mnuStart.Text = "&Start Timer"
        '
        'mnuChangeProject
        '
        Me.mnuChangeProject.Index = 1
        Me.mnuChangeProject.Text = "&Change Project"
        '
        'mnuStop
        '
        Me.mnuStop.Enabled = False
        Me.mnuStop.Index = 2
        Me.mnuStop.Text = "&Stop Timer"
        '
        'mnuClose
        '
        Me.mnuClose.Index = 3
        Me.mnuClose.Text = "Close"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSetRate)
        Me.GroupBox1.Controls.Add(Me.btnSetProject)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 97)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Current Rate:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(118, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(118, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Current Project:"
        '
        'btnSetRate
        '
        Me.btnSetRate.Location = New System.Drawing.Point(280, 52)
        Me.btnSetRate.Name = "btnSetRate"
        Me.btnSetRate.Size = New System.Drawing.Size(54, 25)
        Me.btnSetRate.TabIndex = 0
        Me.btnSetRate.Text = "Set"
        Me.btnSetRate.UseVisualStyleBackColor = True
        '
        'btnSetProject
        '
        Me.btnSetProject.Location = New System.Drawing.Point(280, 22)
        Me.btnSetProject.Name = "btnSetProject"
        Me.btnSetProject.Size = New System.Drawing.Size(54, 25)
        Me.btnSetProject.TabIndex = 0
        Me.btnSetProject.Text = "Set"
        Me.btnSetProject.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Enabled = False
        Me.btnStart.Location = New System.Drawing.Point(15, 157)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(95, 25)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start Timer"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(126, 157)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(95, 25)
        Me.btnStop.TabIndex = 0
        Me.btnStop.Text = "Stop Timer"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.labelTotalCash)
        Me.GroupBox2.Controls.Add(Me.labelCurrentCash)
        Me.GroupBox2.Controls.Add(Me.labelCurrentTime)
        Me.GroupBox2.Controls.Add(Me.labelTotalTime)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.btnClear)
        Me.GroupBox2.Controls.Add(Me.btnStop)
        Me.GroupBox2.Controls.Add(Me.btnStart)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 196)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 198)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stats"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Total Cash:"
        '
        'labelTotalCash
        '
        Me.labelTotalCash.AutoSize = True
        Me.labelTotalCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTotalCash.Location = New System.Drawing.Point(118, 121)
        Me.labelTotalCash.Name = "labelTotalCash"
        Me.labelTotalCash.Size = New System.Drawing.Size(0, 13)
        Me.labelTotalCash.TabIndex = 1
        '
        'labelCurrentCash
        '
        Me.labelCurrentCash.AutoSize = True
        Me.labelCurrentCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCurrentCash.Location = New System.Drawing.Point(118, 90)
        Me.labelCurrentCash.Name = "labelCurrentCash"
        Me.labelCurrentCash.Size = New System.Drawing.Size(0, 13)
        Me.labelCurrentCash.TabIndex = 1
        '
        'labelCurrentTime
        '
        Me.labelCurrentTime.AutoSize = True
        Me.labelCurrentTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCurrentTime.Location = New System.Drawing.Point(118, 27)
        Me.labelCurrentTime.Name = "labelCurrentTime"
        Me.labelCurrentTime.Size = New System.Drawing.Size(0, 13)
        Me.labelCurrentTime.TabIndex = 1
        '
        'labelTotalTime
        '
        Me.labelTotalTime.AutoSize = True
        Me.labelTotalTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTotalTime.Location = New System.Drawing.Point(118, 57)
        Me.labelTotalTime.Name = "labelTotalTime"
        Me.labelTotalTime.Size = New System.Drawing.Size(0, 13)
        Me.labelTotalTime.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Current Cash:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Total Time:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Current Time:"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(238, 157)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(95, 25)
        Me.btnClear.TabIndex = 0
        Me.btnClear.Text = "Clear History"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Monotype Corsiva", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(91, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(172, 28)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Work Timer v1.0"
        '
        'Main
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(379, 408)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Work Timer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' This function will check if a table exists in the DB
    Private Function tableExists(theDatabase As SQLiteConnection, tableName As String) As Boolean
        Dim cmd As SQLiteCommand = New SQLiteCommand(theDatabase)
        cmd.CommandText = "SELECT name FROM sqlite_master WHERE name='" + tableName + "'"
        Dim rdr As SQLiteDataReader = cmd.ExecuteReader()
        If rdr.HasRows Then
            Return True
        Else
            Return False
        End If
    End Function

    ' This routine will handle the minimize to tray part
    Private Sub Main_Minimize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    ' This routine is the entry point of the program
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Get the current path 
        'Dim file_path As String = Application.StartupPath
        'file_path = file_path.Substring(0, file_path.LastIndexOf("\") + 1)

        ' Set the notification icon and text to the default state
        'Me.NotifyIcon1.Icon = New Icon(file_path & "main.ico")
        Me.NotifyIcon1.Text = "Timer Stopped"

        ' Set the default project and rate
        Me.Project = ""
        Me.Rate = 0.0

        ' Initialize the sql connection
        conn = New SQLiteConnection()
        conn.ConnectionString = "Data Source=Work Timer.db3;Version=3;" 'Password=WUfruQu|9;
        conn.Open()

        ' Check if the table exists within the DB
        If Not tableExists(conn, "work") Then
            ' If not, lets create it 
            Dim sql As SQLiteCommand = New SQLiteCommand("CREATE TABLE [work] ([work_id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT, [project] text  NOT NULL, [date] TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, [time] INTEGER NOT NULL, [rate] NUMERIC DEFAULT '0' NOT NULL, [active] BOOLEAN DEFAULT '1' NOT NULL);", conn)
            sql.ExecuteReader()
        End If
    End Sub

    ' This routine is the exit point of the program
    Private Sub Main_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        ' If we have a timer running we'll need to stop it to avoid losing the count
        If Timer1.Enabled Then
            StopTimer()
        End If
    End Sub

    ' This routine is called every time we change the current project
    Private Sub mnuChangeProject_Click(sender As System.Object, ByVal e As System.EventArgs) Handles btnSetProject.Click, mnuChangeProject.Click
        ' We will ask for a new project name
        Dim tmp As String = InputBox("Enter project name: ", "")

        ' If one was entered (assumed non empty)
        If tmp <> "" Then
            ' We set the new project 
            Me.Project = tmp
            ' And update the label
            Label8.Text = Me.Project

            ' We'll also stop the timer if it is running
            If Timer1.Enabled Then
                StopTimer()
            Else
                ' If it's not, we'll still need to load the totals
                loadTotals()
                ' And enable the start 
                btnStart.Enabled = True
            End If

            ' And reset the current values
            labelCurrentTime.Text = "00:00:00"
            labelCurrentCash.Text = "0 $"
        End If
    End Sub

    ' This routine will handle the change of rate
    Private Sub btnSetRate_Click(sender As System.Object, e As System.EventArgs) Handles btnSetRate.Click
        Dim tmp As Double

        ' We'll ask for a new rate 
        Try
            tmp = CType(InputBox("Enter project rate: ", ""), Double)
        Catch ex As Exception
            tmp = 0
        End Try

        ' We'll set the new rate
        Me.Rate = tmp

        ' And update the corresponding label
        Label9.Text = CType(Me.Rate, String) & " $ per hour"
    End Sub

    ' This routine is called every time we need to load the totals from DB
    Private Sub loadTotals()
        ' Execute the query that fetches these totals
        Dim sql As SQLiteCommand = New SQLiteCommand("SELECT SUM(`time`) AS `TotalTime`, (ROUND(100 * SUM((`time` * `rate`)/3600))/100) AS `TotalCash` FROM `work` WHERE `project` = '" & Me.Project & "'", conn)
        sql.Parameters.AddWithValue("project", Me.Project)
        Dim myReader As SQLiteDataReader = sql.ExecuteReader()
        myReader.Read()

        Try
            ' Get the total time, if it's null then we will write the default value
            If myReader.IsDBNull(0) Then
                labelTotalTime.Text = "00:00:00"
            Else
                ' Otherwise we calculate the total time in hh:mm:ss format
                Dim totalTime As Integer = myReader.GetInt16(0)

                Dim H As Integer, M As Integer, S As Integer

                H = CInt(Math.Floor(totalTime / 3600))
                S = totalTime Mod 3600
                M = CInt(Math.Floor(S / 60))
                S = S Mod 60

                Dim txt As String = ""

                If H < 10 Then
                    txt = "0"
                End If
                txt &= H & ":"
                If M < 10 Then
                    txt &= "0"
                End If
                txt &= M & ":"
                If S < 10 Then
                    txt &= "0"
                End If
                txt &= S

                ' Write the total time
                labelTotalTime.Text = txt
            End If

            ' And similarly for the total cash
            If myReader.IsDBNull(1) Then
                labelTotalCash.Text = "0 $"
            Else
                labelTotalCash.Text = CStr(myReader.GetDouble(1)) & " $"
            End If
        Catch Ex As Exception
            ' In case we get an exception, we'll put the default empty values
            labelTotalTime.Text = "00:00:00"
            labelTotalCash.Text = "0 $"
        End Try
    End Sub

    ' This routine will start the timer and minimize to tray 
    Private Sub StartTimer() Handles btnStart.Click, mnuStart.Click
        ' Start timer
        Timer1.Start()

        ' Toggle menu item states
        mnuStart.Enabled = False
        mnuStop.Enabled = True

        ' Toggle button states
        btnStart.Enabled = False
        btnStop.Enabled = True

        ' Minimize to tray
        Me.Hide()
    End Sub

    ' This routine will stop the timer and show the form with results
    Private Sub StopTimer() Handles btnStop.Click, mnuStop.Click
        ' Stop timer
        Timer1.Stop()

        ' Update notification tooltip
        Me.NotifyIcon1.Text = "Timer Stopped"

        ' Toggle menu item states
        mnuStart.Enabled = True
        mnuStop.Enabled = False

        ' Toggle button states
        btnStart.Enabled = True
        btnStop.Enabled = False

        ' Save the total time and rate for this session in DB
        Dim sql As SQLiteCommand = New SQLiteCommand("INSERT INTO [work] ([project],[time],[rate]) VALUES('" & Me.Project & "','" & (Hours * 3600 + Minutes * 60 + Seconds) & "','" & Me.Rate & "')", conn)
        sql.ExecuteReader()

        ' Reload new totals
        loadTotals()

        ' Reset  counts
        Hours = 0
        Minutes = 0
        Seconds = 0

        ' Show the form back in normal mode (not minimized)
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        SetForegroundWindow(Me.Handle)
    End Sub

    ' Declaration for BringToFront alternative
    Private Declare Function SetForegroundWindow Lib "user32.dll" (ByVal hWnd As IntPtr) As Boolean

    ' This routine will show the form once the notification icon is double clicked
    Private Sub NotifyIconClick(sender As System.Object, e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        SetForegroundWindow(Me.Handle)
    End Sub

    ' This routine will allow the user to close the program from the tray
    Private Sub mnuClose_Click(sender As System.Object, e As System.EventArgs) Handles mnuClose.Click
        Me.Close()
    End Sub

    ' This routine is the counter that will increment the time spent and update the current cash accordingly
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ' Increment seconds
        Seconds += 1

        ' Ripple effect for minutes and hours
        If Seconds = 60 Then
            Seconds = 0
            Minutes += 1

            If Minutes = 60 Then
                Minutes = 0
                Hours += 1
            End If
        End If

        ' Update the notification tooltip text
        If Hours > 0 Then
            Me.NotifyIcon1.Text = "Worked " & Hours & " hours and " & Minutes & " minutes."
        ElseIf Minutes > 0 Then
            Me.NotifyIcon1.Text = "Worked " & Minutes & " minutes"
        Else
            Me.NotifyIcon1.Text = "Worked " & Seconds & " seconds"
        End If

        ' Construct the current time in hh:mm:ss format
        Dim txt As String = ""
        If Hours < 10 Then
            txt = "0"
        End If
        txt &= Hours & ":"
        If Minutes < 10 Then
            txt &= "0"
        End If
        txt &= Minutes & ":"
        If Seconds < 10 Then
            txt &= "0"
        End If
        txt &= Seconds

        ' Update the current time
        labelCurrentTime.Text = txt

        ' Update the current rate
        labelTotalCash.Text = Math.Round(((Hours * Rate) + (Minutes / 60) * Rate)) & " $"
    End Sub

    ' This sub is in charge of resetting the total time and cash for this project
    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        ' We will mark all times as inactive in the DB so that no data is destroyed
        Dim sql As SQLiteCommand = New SQLiteCommand("UPDATE [work] SET active = 0 WHERE `project` = '" & Me.Project & "'", conn)
        sql.Parameters.AddWithValue("project", Me.Project)
        sql.ExecuteReader()

        ' And we'll need to reset the labels back to default
        labelTotalTime.Text = "00:00:00"
        labelTotalCash.Text = "0 $"
        labelCurrentTime.Text = "00:00:00"
        labelCurrentCash.Text = "0 $"

        ' We'll show a message just so the user would know that this succeeded
        MsgBox("The data for this project was archived.")
    End Sub
End Class

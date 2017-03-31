Imports System.Data.OleDb

Public Class LanSchoolClassListsHelper

    Private boolFolderOpened As Boolean = False

    Private strFolderName As String = My.Application.Info.DirectoryPath ' Set the default folder to the current directory
    Private strDBConnection As String

    ' Create the Data Tables for storing the teacher lists
    Private tableTeacherLoginName As New DataTable()
    Private tableTeacherMachineName As New DataTable()
    Private tableTeacherADName As New DataTable()

    ' Create the Data Tables for storing class lists
    Private tableClassesByTeacher As New DataTable()
    Private tableStudentsByClass As New DataTable()
    Private tableClassesByType As New DataTable()

    Private Sub LoadCSVData()
        textboxFolderPath.Text = strFolderName ' Populate location text box with the most recent location

        If (strFolderName <> "") Then ' Only continue if the folder exists
            buttonLoad.Enabled = True

            ' Enable or disable the radio buttons depending on what CSV files exist

            If (My.Computer.FileSystem.FileExists(strFolderName + "\ClassesByTeacherLoginName.csv") And My.Computer.FileSystem.FileExists(strFolderName + "\StudentsForClassByLoginName.csv")) Then
                radioLoginName.Enabled = True
            Else
                radioLoginName.Enabled = False
                comboLoginName.Enabled = False
                buttonAddNewLoginName.Enabled = False
            End If

            If (My.Computer.FileSystem.FileExists(strFolderName + "\ClassesByTeacherMachineName.csv") And My.Computer.FileSystem.FileExists(strFolderName + "\StudentsForClassByMachineName.csv")) Then
                radioMachineName.Enabled = True
            Else
                radioMachineName.Enabled = False
                comboMachineName.Enabled = False
                buttonAddNewMachineName.Enabled = False
            End If

            If (My.Computer.FileSystem.FileExists(strFolderName + "\ClassesByTeacherADName.csv") And My.Computer.FileSystem.FileExists(strFolderName + "\StudentsForClassByADName.csv")) Then
                radioADName.Enabled = True
            Else
                radioADName.Enabled = False
                comboADName.Enabled = False
                buttonAddNewADName.Enabled = False
            End If
        End If

        If (radioLoginName.Enabled Or radioMachineName.Enabled Or radioADName.Enabled) Then ' Only change the DB Connection if any of the CSV Files exist
            buttonLoad.Text = "Reload"
            strDBConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFolderName & "\;Extended Properties=""text;HDR=Yes;FMT=Delimited"";"
        Else
            buttonLoad.Text = "Load"
        End If

        If (radioLoginName.Enabled) Then
            tableTeacherLoginName.Clear()

            ' Fill the Login Name teacher list
            Using adapt As New OleDbDataAdapter("SELECT DISTINCT TeacherLoginName FROM [ClassesByTeacherLoginName.csv]", strDBConnection)
                adapt.Fill(tableTeacherLoginName)
            End Using

            comboLoginName.DataSource = New BindingSource(tableTeacherLoginName, Nothing)
            comboLoginName.DisplayMember = "TeacherLoginName"
        End If

        If (radioMachineName.Enabled) Then
            tableTeacherMachineName.Clear()

            ' Fill the Machine Name teacher list
            Using adapt As New OleDbDataAdapter("SELECT DISTINCT TeacherMachineName FROM [ClassesByTeacherMachineName.csv]", strDBConnection)
                adapt.Fill(tableTeacherMachineName)
            End Using

            comboMachineName.DataSource = New BindingSource(tableTeacherMachineName, Nothing)
            comboMachineName.DisplayMember = "TeacherMachineName"
        End If

        If (radioADName.Enabled) Then
            tableTeacherADName.Clear()

            ' Fill the AD Name teacher list
            Using adapt As New OleDbDataAdapter("SELECT DISTINCT TeacherADFullName FROM [ClassesByTeacherADName.csv]", strDBConnection)
                adapt.Fill(tableTeacherADName)
            End Using

            comboADName.DataSource = New BindingSource(tableTeacherADName, Nothing)
            comboADName.DisplayMember = "TeacherADFullName"
        End If

    End Sub

    Private Sub EvaluateClassList()

        Dim strQuery As String ' Set Query string based on what radio button is selected
        If radioLoginName.Checked Then
            strQuery = "SELECT [UniqueClassIdentifier], [Personalized Class Name], [Personalized Class Name]&' ('&[UniqueClassIdentifier]&')' as ClassDisplayName FROM [ClassesByTeacherLoginName.csv] WHERE TeacherLoginName='" & comboLoginName.Text & "' ORDER BY [Personalized Class Name]"
        ElseIf radioMachineName.Checked Then
            strQuery = "SELECT [UniqueClassIdentifier], [Personalized Class Name], [Personalized Class Name]&' ('&[UniqueClassIdentifier]&')' as ClassDisplayName FROM [ClassesByTeacherMachineName.csv] WHERE TeacherMachineName='" & comboMachineName.Text & "' ORDER BY [Personalized Class Name]"
        ElseIf radioADName.Checked Then
            strQuery = "SELECT [UniqueClassIdentifier], [Personalized Class Name], [Personalized Class Name]&' ('&[UniqueClassIdentifier]&')' as ClassDisplayName FROM [ClassesByTeacherADName.csv] WHERE TeacherADFullName='" & comboADName.Text & "' ORDER BY [Personalized Class Name]"
        Else
            Exit Sub ' Can not evaluate class list if no radio button selected
        End If

        tableClassesByTeacher.Clear() ' Clear classes if they are already loaded

        ' Load classes from CSV using OleDbAdapter
        Using adapt As New OleDbDataAdapter(strQuery, strDBConnection)
            adapt.Fill(tableClassesByTeacher)
        End Using

        ' Set class listbox to show correct fields and return correct value
        listboxClassName.DataSource = tableClassesByTeacher
        listboxClassName.DisplayMember = "ClassDisplayName"
        listboxClassName.ValueMember = "UniqueClassIdentifier"

        ' Show number of classes
        labelClassCount.Text = "Number of Classes: " & tableClassesByTeacher.Rows.Count.ToString
        labelClassCount.Visible = True

        ' Enable button to add new class
        buttonAddNewClass.Enabled = True

        EvaluateStudentList() ' Load students for selected class
    End Sub

    Private Sub EvaluateStudentList()
        ' Only load student list if there are classes and a class is selected

        Dim boolClassSelected As Boolean = False ' Setting a variable to avoid system exception while allowing a single else statement
        If (tableClassesByTeacher.Rows.Count > 0 And listboxClassName.SelectedIndex >= 0) Then
            If Not (listboxClassName.SelectedValue.ToString = "" Or listboxClassName.SelectedValue.ToString = "System.Data.DataRowView") Then
                boolClassSelected = True
            End If
        End If

        If boolClassSelected Then
            ' Enable student list elements
            listboxStudents.Enabled = True
            buttonAddNewStudent.Enabled = True

            Dim strQuery As String

            If radioLoginName.Checked Then ' Set Query string based on what radio button is selected
                strQuery = "SELECT DISTINCT [StudentLoginName] as StudentName FROM [StudentsForClassByLoginName.csv] WHERE UniqueClassIdentifier='" & listboxClassName.SelectedValue.ToString & "' ORDER BY StudentLoginName"
            ElseIf radioMachineName.Checked Then
                strQuery = "SELECT DISTINCT [StudentMachineName] as StudentName FROM [StudentsForClassByMachineName.csv] WHERE UniqueClassIdentifier='" & listboxClassName.SelectedValue.ToString & "' ORDER BY StudentMachineName"
            ElseIf radioADName.Checked Then
                strQuery = "SELECT DISTINCT [StudentADFullName] as StudentName FROM [StudentsForClassByADName.csv] WHERE UniqueClassIdentifier='" & listboxClassName.SelectedValue.ToString & "' ORDER BY StudentADFullName"
            Else
                Exit Sub ' Can not evaluate class list if no radio button is selected
            End If

            tableStudentsByClass.Clear() ' Clear out any existing students

            ' Load students from CSV using OleDbAdapter
            Using adapt As New OleDbDataAdapter(strQuery, strDBConnection)
                adapt.Fill(tableStudentsByClass)
            End Using

            ' Set listbox to show correct fields and return correct value
            listboxStudents.DataSource = tableStudentsByClass
            listboxStudents.ValueMember = listboxStudents.DisplayMember
            listboxStudents.DisplayMember = "StudentName"

            ' Set number of students and show it
            labelStudentCount.Text = "Number of Students: " & tableStudentsByClass.Rows.Count.ToString
            labelStudentCount.Visible = True
        Else
            tableStudentsByClass.Clear() ' Clear student list
            labelStudentCount.Visible = False ' Hide student count, because there are none

            ' Disable objects, because no class is selected
            buttonAddNewStudent.Enabled = False
            listboxStudents.Enabled = False
        End If

    End Sub

    Private Sub FormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximizeBox = False
        LoadCSVData() ' Load the information for the CSV files
    End Sub

    Private Sub tsitemExit_Click(sender As Object, e As EventArgs) Handles tsitemExit.Click
        End ' Exit the program
    End Sub

    Private Sub tsitemAbout_Click(sender As Object, e As EventArgs) Handles tsitemAbout.Click
        ' Simply show the About Box when the user clicks about.
        AboutBox1.Visible = True
        AboutBox1.Activate()
    End Sub

    Private Sub OpenBrowseForFolder(sender As Object, e As EventArgs) Handles BrowseButton.Click, OpenToolStripMenuItem.Click
        ' Open the folder browser dialog when Menu Item open or browse button clicked
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If (result = DialogResult.OK) Then ' Only continue to load if they click OK
            strFolderName = FolderBrowserDialog1.SelectedPath
            LoadCSVData() ' Load the information for the CSV files
        End If

    End Sub

    Private Sub buttonLoad_Click(sender As Object, e As EventArgs) Handles buttonLoad.Click
        strFolderName = textboxFolderPath.Text ' Set folder name to textbox content

        LoadCSVData() ' Load the information for the CSV files
    End Sub

    Private Sub radio_CheckedChanged(sender As Object, e As EventArgs) Handles radioLoginName.CheckedChanged, radioMachineName.CheckedChanged, radioADName.CheckedChanged
        ' Only change settings when the sender is checked
        If sender.Checked = True Then
            ' Uncheck the radios that are not the sender
            Select Case sender.Name
                Case "radioLoginName"
                    radioMachineName.Checked = False
                    radioADName.Checked = False
                Case "radioMachineName"
                    radioLoginName.Checked = False
                    radioADName.Checked = False
                Case "radioADName"
                    radioLoginName.Checked = False
                    radioMachineName.Checked = False
                Case Else
                    Exit Sub
            End Select

            ' Enable or disable the other elements by the appropriate radio button
            comboLoginName.Enabled = radioLoginName.Checked
            buttonAddNewLoginName.Enabled = radioLoginName.Checked
            comboMachineName.Enabled = radioMachineName.Checked
            buttonAddNewMachineName.Enabled = radioMachineName.Checked
            comboADName.Enabled = radioADName.Checked
            buttonAddNewADName.Enabled = radioADName.Checked

            listboxClassName.Enabled = True ' Enable the class list box

            EvaluateClassList() ' Load the class list

        End If

    End Sub

    Private Sub textboxFolderPath_TextChanged(sender As Object, e As EventArgs) Handles textboxFolderPath.TextChanged
        If (textboxFolderPath.Text <> "") Then
            buttonLoad.Enabled = True ' Enable the load button
            If (textboxFolderPath.Text = strFolderName) Then ' If the textbox is the same as the loaded path set text of load button to reload
                buttonLoad.Text = "Reload"
            Else
                buttonLoad.Text = "Load"
            End If
        End If
    End Sub

    Private Sub comboTeacherName_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboLoginName.SelectedValueChanged, comboMachineName.SelectedValueChanged, comboADName.SelectedValueChanged
        If (radioLoginName.Checked = True Or radioMachineName.Checked = True Or radioADName.Checked = True) Then
            EvaluateClassList() ' Evaluate the class list as long as a radio button is checked
        End If
    End Sub

    Private Sub listboxClassName_SelectedValueChanged(sender As Object, e As EventArgs) Handles listboxClassName.SelectedValueChanged
        EvaluateStudentList() ' Evaluate the student list
    End Sub

    Private Sub listboxStudents_MouseDown(sender As Object, e As EventArgs) Handles listboxStudents.MouseDown
        Dim eMouse = DirectCast(e, MouseEventArgs) ' Cast to mouse events
        listboxStudents.SelectedIndex = listboxStudents.IndexFromPoint(eMouse.X, eMouse.Y) ' Select the item at the mouse coordinates, will select none if there is no class there
        If eMouse.Button = MouseButtons.Right Then
            rcmenuStudentListBox.Show(MousePosition) ' Show the right click menu if a right click was performed
        End If
    End Sub

    Private Sub listboxClassName_MouseDown(sender As Object, e As EventArgs) Handles listboxClassName.MouseDown
        Dim eMouse = DirectCast(e, MouseEventArgs) ' Cast to mouse events
        listboxClassName.SelectedIndex = listboxClassName.IndexFromPoint(eMouse.X, eMouse.Y) ' Select the item at the mouse coordinates, will select none if there is no class there
        If eMouse.Button = MouseButtons.Right Then
            rcmenuClassListBox.Show(MousePosition) ' Show the right click menu if a right click was performed
        End If
    End Sub

    Private Sub rcmenuStudentListBox_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles rcmenuStudentListBox.Opening
        ' If no student is selected, don't show the delete option
        rcitemDeleteStudent.Enabled = (listboxStudents.SelectedIndex >= 0)
    End Sub

    Private Sub rcmenuClassListBox_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles rcmenuClassListBox.Opening
        ' If no class is selected don't show add teacher or delete class
        rcitemDeleteClass.Enabled = (listboxClassName.SelectedIndex >= 0)
        rcitemAddTeacher.Enabled = (listboxClassName.SelectedIndex >= 0)
    End Sub

    Private Sub DeleteStudentFromClass(sender As Object, e As EventArgs) Handles rcitemDeleteStudent.Click

        ' Prompt for confirmation on deletion
        If MessageBox.Show("Are you sure you want to delete this student from this class?", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub ' Don't continue if the user clicks no
        End If

        Dim strFileName As String
        Dim strLineMatch As String = listboxClassName.SelectedValue.ToString & "," & listboxStudents.SelectedValue.ToString

        ' Set the file name by currently selected radio button
        If radioLoginName.Checked Then
            strFileName = strFolderName & "\StudentsForClassByLoginName.csv"
        ElseIf radioMachineName.Checked Then
            strFileName = strFolderName & "\StudentsForClassByMachineName.csv"
        ElseIf radioADName.Checked Then
            strFileName = strFolderName & "\StudentsForClassByADName.csv"
        Else
            Exit Sub
        End If

        ' Read the file to a local string
        Dim sb As New System.Text.StringBuilder
        For Each line As String In IO.File.ReadLines(strFileName)
            If Not (line.StartsWith(strLineMatch)) Then ' Skip the line that matches the string we want to skip
                sb.AppendLine(line)
            End If
        Next

        Dim strAmmendedFile As String = sb.ToString ' Write string builder to a regular string

        ' Write the string and overwrite the file
        Dim objFileWriter As New System.IO.StreamWriter(strFileName)
        objFileWriter.Write(strAmmendedFile)
        objFileWriter.Close()

        EvaluateStudentList() ' Reevaluate the class list to remove the student from the display

    End Sub

    Private Sub AddStudentToClass(sender As Object, e As EventArgs) Handles rcitemAddStudent.Click, buttonAddNewStudent.Click
        Dim strFileName As String
        Dim strPrompt As String

        If radioLoginName.Checked Then
            strFileName = strFolderName & "\StudentsForClassByLoginName.csv"
            strPrompt = "Enter the student Login Name you wish to add:"
        ElseIf radioMachineName.Checked Then
            strFileName = strFolderName & "\StudentsForClassByMachineName.csv"
            strPrompt = "Enter the student Machine Name you wish to add:"
        ElseIf radioADName.Checked Then
            strFileName = strFolderName & "\StudentsForClassByADName.csv"
            strPrompt = "Enter the student AD Name you wish to add:"
        Else
            Exit Sub
        End If

        Dim strStudentName As String = InputBox(strPrompt, "Student Info")

        If strStudentName = "" Then
            Exit Sub
        End If

        Dim strNewLine As String = listboxClassName.SelectedValue.ToString & "," & strStudentName

        Dim objFileWriter As New System.IO.StreamWriter(strFileName, True)
        objFileWriter.WriteLine(strNewLine)
        objFileWriter.Close()

        EvaluateStudentList()

    End Sub

    Private Sub DeleteClassFromTeacher(sender As Object, e As EventArgs) Handles rcitemDeleteClass.Click

        If MessageBox.Show("Are you sure you want to delete this class from this teacher?", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        Dim strFileName As String
        Dim strLineMatch As String


        If radioLoginName.Checked Then
            strFileName = strFolderName & "\ClassesByTeacherLoginName.csv"
            strLineMatch = comboLoginName.Text & "," & listboxClassName.SelectedValue.ToString
        ElseIf radioMachineName.Checked Then
            strFileName = strFolderName & "\ClassesByTeacherMachineName.csv"
            strLineMatch = comboMachineName.Text & "," & listboxClassName.SelectedValue.ToString
        ElseIf radioADName.Checked Then
            strFileName = strFolderName & "\ClassesByTeacherADName.csv"
            strLineMatch = comboADName.Text & "," & listboxClassName.SelectedValue.ToString
        Else
            Exit Sub
        End If

        Dim sb As New System.Text.StringBuilder
        For Each line As String In IO.File.ReadLines(strFileName)
            If Not (line.StartsWith(strLineMatch)) Then
                sb.AppendLine(line)
            End If
        Next

        Dim strAmmendedFile As String = sb.ToString

        Dim objFileWriter As New System.IO.StreamWriter(strFileName)
        objFileWriter.Write(strAmmendedFile)
        objFileWriter.Close()

        EvaluateClassList()

        If tableClassesByTeacher.Rows.Count < 1 Then
            LoadCSVData()
        End If

    End Sub

    Private Sub AddClassToTeacher(sender As Object, e As EventArgs) Handles buttonAddNewClass.Click, rcitemAddClass.Click

        AddNewUserOrClassForm.textboxTeacherName.Clear()
        AddNewUserOrClassForm.comboUniqueClassID.Text = ""
        AddNewUserOrClassForm.textboxPersonalizedName.Clear()

        Dim strTeacherName As String
        Dim strFileName As String
        Dim strQuery As String

        If radioLoginName.Checked Then
            strTeacherName = "Teacher Login Name"
            strFileName = strFolderName & "\ClassesByTeacherLoginName.csv"
            AddNewUserOrClassForm.textboxTeacherName.Text = comboLoginName.Text
            strQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherLoginName.csv] WHERE NOT TeacherLoginName='" & comboLoginName.Text & "' ORDER BY UniqueClassIdentifier"
        ElseIf radioMachineName.Checked Then
            strTeacherName = "Teacher Machine Name"
            strFileName = strFolderName & "\ClassesByTeacherMachineName.csv"
            AddNewUserOrClassForm.textboxTeacherName.Text = comboMachineName.Text
            strQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherMachineName.csv] WHERE NOT TeacherMachineName='" & comboMachineName.Text & "' ORDER BY UniqueClassIdentifier"
        ElseIf radioADName.Checked Then
            strTeacherName = "Teacher AD Name"
            strFileName = strFolderName & "\ClassesByTeacherADName.csv"
            AddNewUserOrClassForm.textboxTeacherName.Text = comboADName.Text
            strQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherADName.csv] WHERE NOT TeacherADFullName='" & comboADName.Text & "' ORDER BY UniqueClassIdentifier"
        Else
            Exit Sub
        End If

        tableClassesByType.Clear()

        Using adapt As New OleDbDataAdapter(strQuery, strDBConnection)
            adapt.Fill(tableClassesByType)
        End Using

        AddNewUserOrClassForm.comboUniqueClassID.DataSource = tableClassesByType
        AddNewUserOrClassForm.comboUniqueClassID.DisplayMember = "UniqueClassIdentifier"
        AddNewUserOrClassForm.comboUniqueClassID.ValueMember = "UniqueClassIdentifier"

        AddNewUserOrClassForm.textboxTeacherName.Enabled = False
        AddNewUserOrClassForm.comboUniqueClassID.Enabled = True
        AddNewUserOrClassForm.textboxPersonalizedName.Enabled = True
        AddNewUserOrClassForm.labelTeacherNamePrompt.Text = strTeacherName

        Dim resultAddNew As New DialogResult
        Dim resultRetry As New DialogResult

        resultAddNew = AddNewUserOrClassForm.ShowDialog()

        If resultAddNew = DialogResult.Cancel Then
            Exit Sub
        End If

        While AddNewUserOrClassForm.comboUniqueClassID.Text = "" Or AddNewUserOrClassForm.textboxPersonalizedName.Text = ""
            resultRetry = MsgBox("You must specify both a Unique Class Id and a Personalized Name.", MessageBoxButtons.RetryCancel)
            If resultRetry = DialogResult.Cancel Then
                Exit Sub
            ElseIf resultRetry = DialogResult.Retry Then
                resultAddNew = AddNewUserOrClassForm.ShowDialog()
                If resultAddNew = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        End While

        Dim newLine As String = AddNewUserOrClassForm.textboxTeacherName.Text & "," & AddNewUserOrClassForm.comboUniqueClassID.Text & "," & AddNewUserOrClassForm.textboxPersonalizedName.Text

        Dim objFileWriter As New System.IO.StreamWriter(strFileName, True)
        objFileWriter.WriteLine(newLine)
        objFileWriter.Close()

        EvaluateClassList()
    End Sub

    Private Sub AddTeacherToClass(sender As Object, e As EventArgs) Handles rcitemAddTeacher.Click
        AddNewUserOrClassForm.textboxTeacherName.Clear()
        AddNewUserOrClassForm.comboUniqueClassID.Text = ""
        AddNewUserOrClassForm.textboxPersonalizedName.Clear()

        Dim strTeacherName As String
        Dim strFileName As String

        If radioLoginName.Checked Then
            strTeacherName = "Teacher Login Name"
            strFileName = strFolderName & "\ClassesByTeacherLoginName.csv"
        ElseIf radioMachineName.Checked Then
            strTeacherName = "Teacher Machine Name"
            strFileName = strFolderName & "\ClassesByTeacherMachineName.csv"
        ElseIf radioADName.Checked Then
            strTeacherName = "Teacher AD Name"
            strFileName = strFolderName & "\ClassesByTeacherADName.csv"
        Else
            Exit Sub
        End If

        AddNewUserOrClassForm.comboUniqueClassID.Text = listboxClassName.SelectedValue.ToString
        AddNewUserOrClassForm.textboxTeacherName.Enabled = True
        AddNewUserOrClassForm.comboUniqueClassID.Enabled = False
        AddNewUserOrClassForm.textboxPersonalizedName.Enabled = True
        AddNewUserOrClassForm.labelTeacherNamePrompt.Text = strTeacherName

        Dim resultAddNew As New DialogResult
        Dim resultRetry As New DialogResult

        resultAddNew = AddNewUserOrClassForm.ShowDialog()

        If resultAddNew = DialogResult.Cancel Then
            Exit Sub
        End If

        While AddNewUserOrClassForm.textboxTeacherName.Text = "" Or AddNewUserOrClassForm.textboxPersonalizedName.Text = ""
            resultRetry = MsgBox("You must specify both a " & strTeacherName & " and a Personalized Name.", MessageBoxButtons.RetryCancel)
            If resultRetry = DialogResult.Cancel Then
                Exit Sub
            ElseIf resultRetry = DialogResult.Retry Then
                resultAddNew = AddNewUserOrClassForm.ShowDialog()
                If resultAddNew = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        End While

        Dim newLine As String = AddNewUserOrClassForm.textboxTeacherName.Text & "," & AddNewUserOrClassForm.comboUniqueClassID.Text & "," & AddNewUserOrClassForm.textboxPersonalizedName.Text

        Dim objFileWriter As New System.IO.StreamWriter(strFileName, True)
        objFileWriter.WriteLine(newLine)
        objFileWriter.Close()

        LoadCSVData()

        If radioLoginName.Checked Then
            comboLoginName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        ElseIf radioMachineName.Checked Then
            comboMachineName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        ElseIf radioADName.Checked Then
            comboADName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        End If

    End Sub

    Private Sub AddNewTeacher(sender As Object, e As EventArgs) Handles buttonAddNewLoginName.Click, buttonAddNewMachineName.Click, buttonAddNewADName.Click

        AddNewUserOrClassForm.textboxTeacherName.Clear()
        AddNewUserOrClassForm.comboUniqueClassID.Text = ""
        AddNewUserOrClassForm.textboxPersonalizedName.Clear()

        Dim strTeacherName As String
        Dim strFileName As String
        Dim strQuery As String

        If radioLoginName.Checked Then
            strTeacherName = "Teacher Login Name"
            strFileName = strFolderName & "\ClassesByTeacherLoginName.csv"
            strQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherLoginName.csv] ORDER BY UniqueClassIdentifier"
        ElseIf radioMachineName.Checked Then
            strTeacherName = "Teacher Machine Name"
            strFileName = strFolderName & "\ClassesByTeacherMachineName.csv"
            strQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherMachineName.csv] ORDER BY UniqueClassIdentifier"
        ElseIf radioADName.Checked Then
            strTeacherName = "Teacher AD Name"
            strFileName = strFolderName & "\ClassesByTeacherADName.csv"
            strQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherADName.csv] ORDER BY UniqueClassIdentifier"
        Else
            Exit Sub
        End If

        AddNewUserOrClassForm.textboxTeacherName.Enabled = True
        AddNewUserOrClassForm.comboUniqueClassID.Enabled = True
        AddNewUserOrClassForm.textboxPersonalizedName.Enabled = True
        tableClassesByType.Clear()

        Using adapt As New OleDbDataAdapter(strQuery, strDBConnection)
            adapt.Fill(tableClassesByType)
        End Using

        AddNewUserOrClassForm.comboUniqueClassID.DataSource = tableClassesByType
        AddNewUserOrClassForm.comboUniqueClassID.DisplayMember = "UniqueClassIdentifier"
        AddNewUserOrClassForm.comboUniqueClassID.ValueMember = "UniqueClassIdentifier"

        AddNewUserOrClassForm.labelTeacherNamePrompt.Text = strTeacherName

        Dim resultAddNew As New DialogResult
        Dim resultRetry As New DialogResult

        resultAddNew = AddNewUserOrClassForm.ShowDialog()

        If resultAddNew = DialogResult.Cancel Then
            Exit Sub
        End If

        While AddNewUserOrClassForm.textboxTeacherName.Text = "" Or AddNewUserOrClassForm.comboUniqueClassID.Text = "" Or AddNewUserOrClassForm.textboxPersonalizedName.Text = ""
            resultRetry = MsgBox("You must specify a Teacher Name, a Unique Class Id, and a Personalized Class Name.", MessageBoxButtons.RetryCancel)
            If resultRetry = DialogResult.Cancel Then
                Exit Sub
            ElseIf resultRetry = DialogResult.Retry Then
                resultAddNew = AddNewUserOrClassForm.ShowDialog()
                If resultAddNew = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        End While

        Dim newLine As String = AddNewUserOrClassForm.textboxTeacherName.Text & "," & AddNewUserOrClassForm.comboUniqueClassID.Text & "," & AddNewUserOrClassForm.textboxPersonalizedName.Text

        Dim objFileWriter As New System.IO.StreamWriter(strFileName, True)
        objFileWriter.WriteLine(newLine)
        objFileWriter.Close()

        LoadCSVData()

        If radioLoginName.Checked Then
            comboLoginName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        ElseIf radioMachineName.Checked Then
            comboMachineName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        ElseIf radioADName.Checked Then
            comboADName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        End If

    End Sub

    Private Sub rcitemRefreshStudents_Click(sender As Object, e As EventArgs) Handles rcitemRefreshStudents.Click
        EvaluateStudentList()
    End Sub

    Private Sub rcitemRefreshClasses_Click(sender As Object, e As EventArgs) Handles rcitemRefreshClasses.Click
        EvaluateClassList()
    End Sub
End Class

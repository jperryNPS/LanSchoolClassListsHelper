Imports System.Data.OleDb
Imports System.IO
Imports System.IO.Compression
Imports Microsoft.Win32

Public Class LanSchoolClassListsHelper

    Private boolFolderOpened As Boolean = False
    Private boolChangeLog As Boolean = True

    Private strFolderName As String = My.Application.Info.DirectoryPath ' Set the default folder to the current directory
    Private strDBConnection As String
    Private strClassesByTeacherCSV As String
    Private strStudentsForClassCSV As String
    Private strNamePrompt As String
    Private strTeacherNameField As String
    Private strStudentNameField As String
    Private strSelectedTeacher As String
    Private strChangeLogCSV As String

    ' Create the Data Tables for storing the teacher lists
    Private tableTeacherLoginName As New DataTable()
    Private tableTeacherMachineName As New DataTable()
    Private tableTeacherADName As New DataTable()

    ' Create the Data Tables for storing class lists
    Private tableClassesByTeacher As New DataTable()
    Private tableStudentsByClass As New DataTable()
    Private tableClassesByType As New DataTable()
    Private tableClassesWithStudentsByType As New DataTable()
    Private tableClassesWithoutTeachersByType As New DataTable()

    Private Function CheckAndFixRegistrySettings() As Boolean
        Dim regSettings As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Jet\4.0\Engines\Text")
        If (regSettings.GetValue("ImportMixedTypes") = "Text") And (regSettings.GetValue("MaxScanRows") = 0) Then
            Return True
        Else
            If MsgBox("The jet settings in the registry must be changed to allow this program to work properly." + vbCrLf + vbCrLf + "You will need administrative rights, you may be prompted twice." + vbCrLf + "Would you like to make these changes now?" + vbCrLf + vbCrLf + "Choosing no will quit the program.", MsgBoxStyle.YesNo, "Jet Database Settings") = MsgBoxResult.Yes Then
                RegAddAsAdmin("HKLM\Software\Microsoft\Jet\4.0\Engines\Text", "ImportMixedTypes", "Text")
                RegAddAsAdmin("HKLM\Software\Microsoft\Jet\4.0\Engines\Text", "MaxScanRows", "0")
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub RegAddAsAdmin(ByVal strRegistryKey As String, ByVal strRegistryValueName As String, ByVal strRegistryValueData As String)
        Dim prcRegAdd As New Process()
        prcRegAdd.StartInfo.UseShellExecute = True
        prcRegAdd.StartInfo.Verb = "runas"
        prcRegAdd.StartInfo.FileName = "reg"
        prcRegAdd.StartInfo.Arguments = "add " + strRegistryKey + " /v " + strRegistryValueName + " /d " + strRegistryValueData + " /f"
        prcRegAdd.Start()
    End Sub

    Private Sub LoadCSVData(Optional ByVal resetRadio As Boolean = False)
        textboxFolderPath.Text = strFolderName ' Populate location text box with the most recent location

        If resetRadio Then
            ' Uncheck all the radio buttons, in case the files do not exist in the new location
            radioLoginName.Checked = False
            radioMachineName.Checked = False
            radioADName.Checked = False

            comboLoginName.Text = ""
            comboMachineName.Text = ""
            comboADName.Text = ""
        End If

        If (strFolderName <> "") Then ' Only continue if the folder exists
            buttonLoad.Enabled = True

            ' Set path of Change Log File
            strChangeLogCSV = strFolderName + "\ChangeLog.csv"

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

        ' Set the option to add the CSV files to the opposite of the radio options
        tsitemAddLoginNameCSVFiles.Enabled = Not radioLoginName.Enabled
        tsitemAddMachineNameCSVFiles.Enabled = Not radioMachineName.Enabled
        tsitemAddADNameCSVFiles.Enabled = Not radioADName.Enabled

        If (radioLoginName.Enabled Or radioMachineName.Enabled Or radioADName.Enabled) Then ' Only change the DB Connection if any of the CSV Files exist
            buttonLoad.Text = "Reload"
            strDBConnection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFolderName & "\;Extended Properties=""text;HDR=Yes;FMT=Delimited;IMEX=1;MAXSCANROWS=900"";"
        Else
            buttonLoad.Text = "Load"
        End If

        If (radioLoginName.Enabled) Then
            ' Fill the Login Name teacher list
            FillTableUsingQuery("SELECT DISTINCT TeacherLoginName FROM [ClassesByTeacherLoginName.csv]", tableTeacherLoginName)



            comboLoginName.DataSource = New BindingSource(tableTeacherLoginName, Nothing)
            comboLoginName.DisplayMember = "TeacherLoginName"
        End If

        If (radioMachineName.Enabled) Then
            ' Fill the Machine Name teacher list
            FillTableUsingQuery("SELECT DISTINCT TeacherMachineName FROM [ClassesByTeacherMachineName.csv]", tableTeacherMachineName)

            comboMachineName.DataSource = New BindingSource(tableTeacherMachineName, Nothing)
            comboMachineName.DisplayMember = "TeacherMachineName"
        End If

        If (radioADName.Enabled) Then
            ' Fill the AD Name teacher list
            FillTableUsingQuery("SELECT DISTINCT TeacherADFullName FROM [ClassesByTeacherADName.csv]", tableTeacherADName)

            comboADName.DataSource = New BindingSource(tableTeacherADName, Nothing)
            comboADName.DisplayMember = "TeacherADFullName"
        End If

        If resetRadio Then
            ' Check the first available radio button
            If radioLoginName.Enabled Then
                radioLoginName.Checked = True
            ElseIf radioMachineName.Enabled Then
                radioMachineName.Checked = True
            ElseIf radioADName.Enabled Then
                radioADName.Checked = True
            End If
        End If
    End Sub

    Private Sub EvaluateClassList()

        Dim strQuery As String = ""

        If tsitemShowAllClassesByType.Checked Then
            strQuery &= "SELECT DISTINCT [UniqueClassIdentifier], [UniqueClassIdentifier] as [Personalized Class Name], [UniqueClassIdentifier] as ClassDisplayName FROM [" & strStudentsForClassCSV & "] WHERE [UniqueClassIdentifier] NOT IN (SELECT DISTINCT [UniqueClassIdentifier] FROM [" & strClassesByTeacherCSV & "])"
        End If
        If Not tsitemShowClassesWithNoTeacher.Checked Then
            If tsitemShowAllClassesByType.Checked Then strQuery &= " UNION "
            strQuery &= "SELECT DISTINCT [UniqueClassIdentifier], [Personalized Class Name], [Personalized Class Name]&' ('&[UniqueClassIdentifier]&')' as ClassDisplayName FROM [" & strClassesByTeacherCSV & "]"
            If Not tsitemShowAllClassesByType.Checked Then
                strQuery &= " WHERE " & strTeacherNameField & "='" & strSelectedTeacher & "'"
                If tsitemHideEmptyClasses.Checked Or tsitemShowOnlyEmptyClasses.Checked Then
                    strQuery &= " AND "
                End If
            ElseIf tsitemHideEmptyClasses.Checked Or tsitemShowOnlyEmptyClasses.Checked Then
                strQuery &= " WHERE "
            End If


            If tsitemHideEmptyClasses.Checked Or tsitemShowOnlyEmptyClasses.Checked Then
                strQuery &= "[UniqueClassIdentifier]"

                If tsitemShowOnlyEmptyClasses.Checked Then
                    strQuery &= " NOT"
                End If

                strQuery &= " IN (SELECT DISTINCT [UniqueClassIdentifier] FROM [" & strStudentsForClassCSV & "])"
            End If

            strQuery &= " ORDER BY [Personalized Class Name]"
        End If

        ' Load classes from CSV using OleDbAdapter
        FillTableUsingQuery(strQuery, tableClassesByTeacher)

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

            Dim strQuery As String = "Select DISTINCT [" & strStudentNameField & "] As StudentName FROM [" & strStudentsForClassCSV & "]"

            If IsNumeric(listboxClassName.SelectedValue.ToString) Then
                strQuery &= " WHERE UniqueClassIdentifier=" & listboxClassName.SelectedValue.ToString
            Else
                strQuery &= " WHERE UniqueClassIdentifier='" & listboxClassName.SelectedValue.ToString & "'"
            End If

            strQuery &= " ORDER BY " & strStudentNameField

            ' Load students from CSV using OleDbAdapter
            FillTableUsingQuery(strQuery, tableStudentsByClass)

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

    Private Sub AddToChangeLog(ByVal strAction As String, ByVal strFile As String, ByVal strLine As String)
        If (Not My.Computer.FileSystem.FileExists(strChangeLogCSV)) Then
            AddNewLineToFile(strChangeLogCSV, """Time"",""User"",""File"",""Action"",""Line""")
        End If
        AddNewLineToFile(strChangeLogCSV, String.Format("""{0}"",""{1}"",""{2}"",""{3}"",""{4}""", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Environment.UserName, strFile, strAction, strLine))
    End Sub

    Private Sub FormLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not CheckAndFixRegistrySettings() Then
            End
        End If

        LoadCSVData(True) ' Load the information for the CSV files
    End Sub

    Private Sub tsitemExit_Click(sender As Object, e As EventArgs) Handles tsitemExit.Click
        End ' Exit the program
    End Sub

    Private Sub tsitemAbout_Click(sender As Object, e As EventArgs) Handles tsitemAbout.Click
        ' Simply show the About Box when the user clicks about.
        AboutBox.ShowDialog()
    End Sub

    Private Sub OpenBrowseForFolder(sender As Object, e As EventArgs) Handles BrowseButton.Click, tsitemChangeDirectory.Click
        ' Open the folder browser dialog when Menu Item open or browse button clicked
        Dim result As DialogResult = FolderBrowserDialog.ShowDialog()

        If (result = DialogResult.OK) Then ' Only continue to load if they click OK
            strFolderName = FolderBrowserDialog.SelectedPath
            LoadCSVData(True) ' Load the information for the CSV files
        End If

    End Sub

    Private Sub buttonLoad_Click(sender As Object, e As EventArgs) Handles buttonLoad.Click
        strFolderName = textboxFolderPath.Text ' Set folder name to textbox content
        LoadCSVData(True) ' Load the information for the CSV files
    End Sub

    Private Sub textboxFolderPath_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles textboxFolderPath.KeyDown
        If e.KeyCode = Keys.Enter Then
            strFolderName = textboxFolderPath.Text ' Set folder name to textbox content
            LoadCSVData(True) ' Load the information for the CSV files
        End If
    End Sub

    Private Sub radio_CheckedChanged(sender As Object, e As EventArgs) Handles radioLoginName.CheckedChanged, radioMachineName.CheckedChanged, radioADName.CheckedChanged
        ' Only change settings when the sender is checked
        If sender.Checked Then
            ' Uncheck the radios that are not the sender
            Select Case sender.Name
                Case "radioLoginName"
                    radioMachineName.Checked = False
                    radioADName.Checked = False
                    strClassesByTeacherCSV = "ClassesByTeacherLoginName.csv"
                    strStudentsForClassCSV = "StudentsForClassByLoginName.csv"
                    strNamePrompt = "Login Name"
                    strTeacherNameField = "TeacherLoginName"
                    strStudentNameField = "StudentLoginName"
                    strSelectedTeacher = comboLoginName.Text
                Case "radioMachineName"
                    radioLoginName.Checked = False
                    radioADName.Checked = False
                    strClassesByTeacherCSV = "ClassesByTeacherMachineName.csv"
                    strStudentsForClassCSV = "StudentsForClassByMachineName.csv"
                    strNamePrompt = "Machine Name"
                    strTeacherNameField = "TeacherMachineName"
                    strStudentNameField = "StudentMachineName"
                    strSelectedTeacher = comboMachineName.Text
                Case "radioADName"
                    radioLoginName.Checked = False
                    radioMachineName.Checked = False
                    strClassesByTeacherCSV = "ClassesByTeacherADName.csv"
                    strStudentsForClassCSV = "StudentsForClassByADName.csv"
                    strNamePrompt = "AD Name"
                    strTeacherNameField = "TeacherADFullName"
                    strStudentNameField = "StudentADFullName"
                    strSelectedTeacher = comboADName.Text
                Case Else
                    Exit Sub
            End Select

            ' Enable or disable the other elements by the appropriate radio button
            If tsitemShowAllClassesByType.Checked Then
                comboLoginName.Enabled = False
                comboMachineName.Enabled = False
                comboADName.Enabled = False
            Else
                comboLoginName.Enabled = radioLoginName.Checked
                comboMachineName.Enabled = radioMachineName.Checked
                comboADName.Enabled = radioADName.Checked
            End If

            buttonAddNewLoginName.Enabled = radioLoginName.Checked
            buttonAddNewMachineName.Enabled = radioMachineName.Checked
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
            ' Set selected teacher based on selected radio button
            Select Case sender.Name
                Case "comboLoginName"
                    strSelectedTeacher = comboLoginName.Text
                Case "comboMachineName"
                    strSelectedTeacher = comboMachineName.Text
                Case "comboADName"
                    strSelectedTeacher = comboADName.Text
                Case Else
                    Exit Sub
            End Select

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
        ' If no class is selected or if show all classes is enabled delete class
        rcitemDeleteClass.Enabled = (listboxClassName.SelectedIndex >= 0) And Not tsitemShowAllClassesByType.Checked
        ' If no class is selected don't show add teacher
        rcitemAddTeacher.Enabled = (listboxClassName.SelectedIndex >= 0)
    End Sub

    Private Sub rcitemDeleteStudent_Click(sender As Object, e As EventArgs) Handles rcitemDeleteStudent.Click
        DeleteStudentFromClass()
    End Sub
    Private Sub DeleteStudentFromClass()

        ' Prompt for confirmation on deletion
        If MessageBox.Show("Are you sure you want to delete this student from this class?", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub ' Don't continue if the user clicks no
        End If

        Dim strFileName As String = strFolderName & "\" & strStudentsForClassCSV
        Dim strLineMatch As String = listboxClassName.SelectedValue.ToString & "," & listboxStudents.SelectedValue.ToString

        DeleteLineFromFile(strFileName, strLineMatch, True)

        EvaluateStudentList() ' Reevaluate the class list to remove the student from the display

    End Sub

    Private Sub AddStudentToClass(sender As Object, e As EventArgs) Handles rcitemAddStudent.Click, buttonAddNewStudent.Click

        Dim strFileName As String = strFolderName & "\" & strStudentsForClassCSV
        Dim strPrompt As String = "Enter the student " & strNamePrompt & " you wish to add:"

        Dim strStudentName As String = InputBox(strPrompt, "Student Info") ' Prompt for student name

        If strStudentName = "" Then
            Exit Sub ' Stop if no name added
        End If

        ' Set new line text
        Dim strNewLine As String = listboxClassName.SelectedValue.ToString & "," & strStudentName

        If (boolChangeLog) Then AddToChangeLog("ADD", strStudentsForClassCSV, strNewLine)

        ' Add new line to file
        AddNewLineToFile(strFileName, strNewLine)

        ' Reload the student list
        EvaluateStudentList()

    End Sub

    Private Sub rcitemDeleteClass_Click(sender As Object, e As EventArgs) Handles rcitemDeleteClass.Click
        DeleteClassFromTeacher()
    End Sub
    Private Sub DeleteClassFromTeacher()

        ' Confirm deletion
        If MessageBox.Show("Are you sure you want to delete this class from this teacher?", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub ' Stop if the answer is no
        End If

        Dim strFileName As String = strFolderName & "\" & strClassesByTeacherCSV
        Dim strLineMatch As String = strSelectedTeacher & "," & listboxClassName.SelectedValue.ToString

        ' Delete the matching line from the file
        DeleteLineFromFile(strFileName, strLineMatch)

        EvaluateClassList() ' Reevaluate list of classes

        If tableClassesByTeacher.Rows.Count < 1 Then
            LoadCSVData() ' Reload teacher list if this teacher has no more classes
        End If

    End Sub

    Private Sub AddClassToTeacher(sender As Object, e As EventArgs) Handles buttonAddNewClass.Click, rcitemAddClass.Click

        ' Show add class dialog with teacher name locked if menu item is unchecked, but unlocked if it is checked
        If Not ShowAddClassDialog(tsitemShowAllClassesByType.Checked, True) Then
            Exit Sub
        End If

        ' Add the new class to the file
        Dim strFileName As String = strFolderName & "\" & strClassesByTeacherCSV
        Dim strNewLine As String = AddNewUserOrClassForm.textboxTeacherName.Text & "," & AddNewUserOrClassForm.comboUniqueClassID.Text & "," & AddNewUserOrClassForm.textboxPersonalizedName.Text

        If (boolChangeLog) Then AddToChangeLog("ADD", strClassesByTeacherCSV, strNewLine)

        AddNewLineToFile(strFileName, strNewLine)

        EvaluateClassList() ' Update the list of classes, no need to update list of teachers, as it was locked
    End Sub

    Private Sub AddTeacherToClass(sender As Object, e As EventArgs) Handles rcitemAddTeacher.Click

        ' Show add class dialog with class unique id locked
        If Not ShowAddClassDialog(True, False) Then
            Exit Sub
        End If

        ' Add the new class to the file
        Dim strFileName As String = strFolderName & "\" & strClassesByTeacherCSV
        Dim strNewLine As String = AddNewUserOrClassForm.textboxTeacherName.Text & "," & AddNewUserOrClassForm.comboUniqueClassID.Text & "," & AddNewUserOrClassForm.textboxPersonalizedName.Text

        If (boolChangeLog) Then AddToChangeLog("ADD", strClassesByTeacherCSV, strNewLine)

        AddNewLineToFile(strFileName, strNewLine)

        LoadCSVData() ' Reload the list of teachers

        ' Select the teacher you just added
        If radioLoginName.Checked Then
            comboLoginName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        ElseIf radioMachineName.Checked Then
            comboMachineName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        ElseIf radioADName.Checked Then
            comboADName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        End If

    End Sub

    Private Sub AddNewTeacher(sender As Object, e As EventArgs) Handles buttonAddNewLoginName.Click, buttonAddNewMachineName.Click, buttonAddNewADName.Click

        ' Show completely unlocked add class dialog
        If Not ShowAddClassDialog(True, True) Then
            Exit Sub
        End If

        ' Add the new class to the file
        Dim strFileName As String = strFolderName & "\" & strClassesByTeacherCSV
        Dim strNewLine As String = AddNewUserOrClassForm.textboxTeacherName.Text & "," & AddNewUserOrClassForm.comboUniqueClassID.Text & "," & AddNewUserOrClassForm.textboxPersonalizedName.Text

        If (boolChangeLog) Then AddToChangeLog("ADD", strClassesByTeacherCSV, strNewLine)

        AddNewLineToFile(strFileName, strNewLine)

        LoadCSVData() ' Reload the list of teachers

        ' Select the teacher you just added
        If radioLoginName.Checked Then
            comboLoginName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        ElseIf radioMachineName.Checked Then
            comboMachineName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        ElseIf radioADName.Checked Then
            comboADName.Text = AddNewUserOrClassForm.textboxTeacherName.Text
        End If

    End Sub

    Private Sub rcitemRefreshStudents_Click(sender As Object, e As EventArgs) Handles rcitemRefreshStudents.Click
        EvaluateStudentList() ' Refresh list of students
    End Sub

    Private Sub rcitemRefreshClasses_Click(sender As Object, e As EventArgs) Handles rcitemRefreshClasses.Click
        EvaluateClassList() ' Refresh list of classes
    End Sub

    Private Sub AddNewLineToFile(ByVal filename As String, ByVal newline As String)
        Dim objFileWriter As New System.IO.StreamWriter(filename, True) ' Open file writer in append mode
        objFileWriter.WriteLine(newline) ' Write string to file
        objFileWriter.Close() ' Close the file
    End Sub

    Private Sub DeleteLineFromFile(ByVal filename As String, ByVal linematch As String, Optional ByVal exactmatch As Boolean = False)
        Dim sb As New System.Text.StringBuilder
        For Each line As String In IO.File.ReadLines(filename) ' Recurse through the file line by line
            If (exactmatch And Not line.Equals(linematch)) Or (Not exactmatch And Not line.StartsWith(linematch)) Then
                sb.AppendLine(line) ' Add line to string builder if it's not the line we wish to skip/delete
            ElseIf (boolChangeLog) Then
                AddToChangeLog("DELETE", filename.Substring(filename.LastIndexOf("\") + 1), line)
            End If
        Next

        Dim objFileWriter As New System.IO.StreamWriter(filename) ' Open file writer in overwrite mode
        objFileWriter.Write(sb.ToString) ' Write string to file
        objFileWriter.Close() ' Close the file
    End Sub

    Private Sub FillTableUsingQuery(ByVal query As String, ByRef table As DataTable)
        ' Clear the table before filling with new data
        table = New DataTable()

        Using adapt As New OleDbDataAdapter(query, strDBConnection)
            Do
                Try
                    adapt.Fill(table)
                    Exit Do
                Catch ex As OleDbException
                    Dim retry = MessageBox.Show(ex.Message, "Retry?", MessageBoxButtons.AbortRetryIgnore)
                    If (retry = DialogResult.Ignore) Then
                        Exit Do
                    ElseIf (retry = DialogResult.Abort) Then
                        End
                    End If
                End Try
            Loop
        End Using
    End Sub

    Private Function ShowAddClassDialog(ByVal boolTeacherNameEnabled As Boolean, ByVal boolUniqueClassIDEnabled As Boolean) As Boolean

        ' Clear any old values from form boxes
        AddNewUserOrClassForm.textboxTeacherName.Clear()
        AddNewUserOrClassForm.comboUniqueClassID.Text = ""
        AddNewUserOrClassForm.textboxPersonalizedName.Clear()

        ' Set prompt for Teacher Name
        AddNewUserOrClassForm.labelTeacherNamePrompt.Text = "Teacher " & strNamePrompt

        ' Always enable teacher name input if no teacher is selected
        If strSelectedTeacher = "" Then
            boolTeacherNameEnabled = True
        End If

        ' Always enable unique class id selection if no class is selected
        If listboxClassName.SelectedItems.Count <= 0 Then
            boolUniqueClassIDEnabled = True
        End If

        If Not boolTeacherNameEnabled Then
            AddNewUserOrClassForm.textboxTeacherName.Text = strSelectedTeacher
        End If

        If boolUniqueClassIDEnabled Then
            Dim strQuery As String = "SELECT DISTINCT [UniqueClassIdentifier] FROM [" & strClassesByTeacherCSV & "] ORDER BY UniqueClassIdentifier"

            ' Load list of classes from CSV files
            FillTableUsingQuery(strQuery, tableClassesByType)

            ' Set data source, display, and value members for combo box
            AddNewUserOrClassForm.comboUniqueClassID.DataSource = tableClassesByType
            AddNewUserOrClassForm.comboUniqueClassID.DisplayMember = "UniqueClassIdentifier"
            AddNewUserOrClassForm.comboUniqueClassID.ValueMember = "UniqueClassIdentifier"
        Else
            AddNewUserOrClassForm.comboUniqueClassID.Text = listboxClassName.SelectedValue.ToString
        End If

        ' Set which fields can be modified
        AddNewUserOrClassForm.textboxTeacherName.Enabled = boolTeacherNameEnabled
        AddNewUserOrClassForm.comboUniqueClassID.Enabled = boolUniqueClassIDEnabled
        AddNewUserOrClassForm.textboxPersonalizedName.Enabled = True

        Dim resultAddNew As New DialogResult
        Dim resultRetry As New DialogResult

        Do ' Locks in loop until cancel is pressed or all fields are filled
            resultAddNew = AddNewUserOrClassForm.ShowDialog()

            If resultAddNew = DialogResult.Cancel Then
                Return False
                Exit Function
            ElseIf AddNewUserOrClassForm.textboxTeacherName.Text = "" Or AddNewUserOrClassForm.comboUniqueClassID.Text = "" Or AddNewUserOrClassForm.textboxPersonalizedName.Text = "" Then
                resultRetry = MsgBox("You must specify a Teacher " & strNamePrompt & ", a Unique Class Id, and a Personalized Class Name.", MessageBoxButtons.RetryCancel)
                If resultRetry = DialogResult.Cancel Then
                    Return False
                    Exit Function
                ElseIf resultRetry = DialogResult.Retry Then
                    Continue Do
                End If
            Else
                Return True
                Exit Function
            End If

        Loop


    End Function

    Private Sub tsitemHideEmptyClasses_Click(sender As Object, e As EventArgs) Handles tsitemHideEmptyClasses.Click
        tsitemHideEmptyClasses.Checked = Not tsitemHideEmptyClasses.Checked ' Change whether item is checked

        If tsitemHideEmptyClasses.Checked Then ' Warn about repurcussions and confirm
            If MsgBox("Enabling this option will hide all empty classes, even newly created ones.", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
                tsitemHideEmptyClasses.Checked = False
                Exit Sub
            Else
                tsitemShowOnlyEmptyClasses.Checked = False ' you can't have both of these items checked
            End If
        End If

        EvaluateClassList()

    End Sub

    Private Sub ShowOnlyEmptyClassesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsitemShowOnlyEmptyClasses.Click
        tsitemShowOnlyEmptyClasses.Checked = Not tsitemShowOnlyEmptyClasses.Checked

        ' Warn about repurcussions and confirm
        If tsitemShowOnlyEmptyClasses.Checked Then
            If MsgBox("Enabling this option will show only classes with no students.", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
                tsitemShowOnlyEmptyClasses.Checked = False
                Exit Sub
            Else
                tsitemHideEmptyClasses.Checked = False ' you can't have both of these items checked
            End If
        End If

        EvaluateClassList()

    End Sub

    Private Sub tsitemShowAllClassesByType_Click(sender As Object, e As EventArgs) Handles tsitemShowAllClassesByType.Click
        tsitemShowAllClassesByType.Checked = Not tsitemShowAllClassesByType.Checked
        tsitemShowClassesWithNoTeacher.Enabled = tsitemShowAllClassesByType.Checked

        If tsitemShowAllClassesByType.Checked Then
            ' Show all classes, regardless of teacher name

            ' Disable combo boxes
            comboLoginName.Enabled = False
            comboMachineName.Enabled = False
            comboADName.Enabled = False

        Else
            tsitemShowClassesWithNoTeacher.Checked = False

            ' Show only classes based on selected teacher name in combo box

            ' Enable combo boxes
            comboLoginName.Enabled = radioLoginName.Checked
            comboMachineName.Enabled = radioMachineName.Checked
            comboADName.Enabled = radioADName.Checked

        End If

        EvaluateClassList()
    End Sub

    Private Sub tsitemAddLoginNameCSVFiles_Click(sender As Object, e As EventArgs) Handles tsitemAddLoginNameCSVFiles.Click
        AddNewLineToFile(strFolderName + "\ClassesByTeacherLoginName.csv", "TeacherLoginName,UniqueClassIdentifier,Personalized Class Name")
        AddNewLineToFile(strFolderName + "\StudentsForClassByLoginName.csv", "UniqueClassIdentifier,StudentLoginName")
        LoadCSVData()
    End Sub

    Private Sub tsitemAddMachineNameCSVFiles_Click(sender As Object, e As EventArgs) Handles tsitemAddMachineNameCSVFiles.Click
        AddNewLineToFile(strFolderName + "\ClassesByTeacherMachineName.csv", "TeacherMachineName,UniqueClassIdentifier,Personalized Class Name")
        AddNewLineToFile(strFolderName + "\StudentsForClassByMachineName.csv", "UniqueClassIdentifier,StudentMachineName")
        LoadCSVData()
    End Sub

    Private Sub tsitemAddADNameCSVFiles_Click(sender As Object, e As EventArgs) Handles tsitemAddADNameCSVFiles.Click
        AddNewLineToFile(strFolderName + "\ClassesByTeacherADName.csv", "TeacherADFullName,UniqueClassIdentifier,Personalized Class Name")
        AddNewLineToFile(strFolderName + "\StudentsForClassByADName.csv", "UniqueClassIdentifier,StudentADFullName")
        LoadCSVData()
    End Sub

    Private Sub tsitemSaveABackup_Click(sender As Object, e As EventArgs) Handles tsitemSaveABackup.Click
        SaveFileDialog.Title = "Please select a New File"
        SaveFileDialog.InitialDirectory = strFolderName
        SaveFileDialog.Filter = "Zip Files (*.zip)|*.zip"
        SaveFileDialog.FilterIndex = 1
        SaveFileDialog.FileName = "LSClassListBackup_" + DateTime.Now.ToString("s").Replace(":", "") + ".zip"

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim strFileName As String = SaveFileDialog.FileName

            If (File.Exists(strFileName)) Then
                ' The archive already exists and needs to be deleted
                If MessageBox.Show("Are you sure you want to overwrite this backup?" & vbCrLf & "This action cannot be undone.", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    File.Delete(strFileName)
                Else
                    MessageBox.Show("Backup cancelled because the file already exists.", "Backup Cancelled", MessageBoxButtons.OK)
                    Exit Sub
                End If
            End If

            Dim archive As ZipArchive = ZipFile.Open(strFileName, ZipArchiveMode.Create)

            Using archive
                For Each strCSVFileName In {"ClassesByTeacherLoginName.csv", "StudentsForClassByLoginName.csv", "ClassesByTeacherMachineName.csv", "StudentsForClassByMachineName.csv", "ClassesByTeacherADName.csv", "StudentsForClassByADName.csv", "ChangeLog.csv"}
                    If (File.Exists(strFolderName + "\" + strCSVFileName)) Then
                        archive.CreateEntryFromFile(strFolderName + "\" + strCSVFileName, strCSVFileName)
                    End If
                Next

                MessageBox.Show("Backup completed.", "Backup Completed", MessageBoxButtons.OK)
            End Using
        End If
    End Sub

    Private Sub tsitemRestoreABackup_Click(sender As Object, e As EventArgs) Handles tsitemRestoreABackup.Click
        OpenFileDialog.Title = "Please select a File"
        OpenFileDialog.InitialDirectory = strFolderName
        OpenFileDialog.CheckFileExists = True
        OpenFileDialog.Filter = "Zip Files (*.zip)|*.zip"
        OpenFileDialog.FilterIndex = 1
        OpenFileDialog.FileName = String.Empty

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Dim strFileName As String = OpenFileDialog.FileName
            Dim boolLoginNameClassesByTeacherCSV As Boolean = False
            Dim boolLoginNameStudentsForClassCSV As Boolean = False
            Dim boolMachineNameClassesByTeacherCSV As Boolean = False
            Dim boolMachineNameStudentsForClassCSV As Boolean = False
            Dim boolADNameClassesByTeacherCSV As Boolean = False
            Dim boolADNameStudentsForClassCSV As Boolean = False
            Dim boolChangeLogCSV As Boolean = False

            Dim archive As ZipArchive = ZipFile.OpenRead(strFileName)

            Using archive
                For Each entry As ZipArchiveEntry In archive.Entries
                    Select Case entry.Name.ToString()
                        Case "ClassesByTeacherLoginName.csv"
                            boolLoginNameClassesByTeacherCSV = True
                        Case "StudentsForClassByLoginName.csv"
                            boolLoginNameStudentsForClassCSV = True
                        Case "ClassesByTeacherMachineName.csv"
                            boolMachineNameClassesByTeacherCSV = True
                        Case "StudentsForClassByMachineName.csv"
                            boolMachineNameStudentsForClassCSV = True
                        Case "ClassesByTeacherADName.csv"
                            boolADNameClassesByTeacherCSV = True
                        Case "StudentsForClassByADName.csv"
                            boolADNameStudentsForClassCSV = True
                        Case "ChangeLog.csv"
                            boolChangeLogCSV = True
                    End Select
                Next

                If (boolLoginNameClassesByTeacherCSV And boolLoginNameStudentsForClassCSV) Then
                    ' The file exists in the archive
                    If MessageBox.Show("Are you sure you want to restore Classes by Login Name from this backup?" & vbCrLf & "All changes since the backup will be lost.", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        ' Only run the restore if the end user clicks yes
                        archive.GetEntry("ClassesByTeacherLoginName.csv").ExtractToFile(strFolderName + "\ClassesByTeacherLoginName.csv", True)
                        archive.GetEntry("StudentsForClassByLoginName.csv").ExtractToFile(strFolderName + "\StudentsForClassByLoginName.csv", True)
                    End If
                End If

                If (boolMachineNameClassesByTeacherCSV And boolMachineNameStudentsForClassCSV) Then
                    If MessageBox.Show("Are you sure you want to restore Classes by Machine Name from this backup?" & vbCrLf & "All changes since the backup will be lost.", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        ' Only run the restore if the end user clicks yes
                        archive.GetEntry("ClassesByTeacherMachineName.csv").ExtractToFile(strFolderName + "\ClassesByTeacherMachineName.csv", True)
                        archive.GetEntry("StudentsForClassByMachineName.csv").ExtractToFile(strFolderName + "\StudentsForClassByMachineName.csv", True)
                    End If
                End If

                If (boolADNameClassesByTeacherCSV And boolADNameStudentsForClassCSV) Then
                    If MessageBox.Show("Are you sure you want to restore Classes by AD Name from this backup?" & vbCrLf & "All changes since the backup will be lost.", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        ' Only run the restore if the end user clicks yes
                        archive.GetEntry("ClassesByTeacherADName.csv").ExtractToFile(strFolderName + "\ClassesByTeacherADName.csv", True)
                        archive.GetEntry("StudentsForClassByADName.csv").ExtractToFile(strFolderName + "\StudentsForClassByADName.csv", True)
                    End If
                End If

                If (boolChangeLogCSV) Then
                    If MessageBox.Show("Are you sure you want to restore the ChangeLog from this backup?" & vbCrLf & "All changes since the backup will be lost.", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        ' Only run the restore if the end user clicks yes
                        archive.GetEntry("ChangeLog.csv").ExtractToFile(strFolderName + "\ChangeLog.csv", True)
                    End If
                End If
            End Using

            LoadCSVData()
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        SettingsDialog.CheckBoxEnableLogging.Checked = boolChangeLog
        If SettingsDialog.ShowDialog() = DialogResult.OK Then
            boolChangeLog = SettingsDialog.CheckBoxEnableLogging.Checked
        End If
    End Sub

    Private Sub ListboxStudents_KeyUp(sender As Object, e As KeyEventArgs) Handles listboxStudents.KeyUp
        If e.KeyValue = Keys.Delete Then
            DeleteStudentFromClass()
        End If
    End Sub

    Private Sub ListboxClassName_KeyUp(sender As Object, e As KeyEventArgs) Handles listboxClassName.KeyUp
        If e.KeyValue = Keys.Delete Then
            DeleteClassFromTeacher()
        End If
    End Sub

    Private Sub tsitemShowClassesWithNoTeacher_Click(sender As Object, e As EventArgs) Handles tsitemShowClassesWithNoTeacher.Click
        tsitemShowClassesWithNoTeacher.Checked = Not tsitemShowClassesWithNoTeacher.Checked

        EvaluateClassList()

    End Sub
End Class

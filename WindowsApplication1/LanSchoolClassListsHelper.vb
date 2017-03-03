Imports System.Data.OleDb

Public Class LanSchoolClassListsHelper

    Private folderOpened As Boolean = False
    Private folderName As String = My.Application.Info.DirectoryPath
    Private sConn As String
    Private uniqueID As String

    Private LoginNameTeacherList As New DataTable()
    Private MachineNameTeacherList As New DataTable()
    Private ADNameTeacherList As New DataTable()

    Private TeacherClassList As New DataTable()
    Private ClassStudentList As New DataTable()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximizeBox = False
        FolderPathTextBox.Text = folderName
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenBrowseForFolder()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Visible = True
        AboutBox1.Activate()
    End Sub

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        OpenBrowseForFolder()
    End Sub

    Private Sub OpenBrowseForFolder()
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If (result = DialogResult.OK) Then
            folderName = FolderBrowserDialog1.SelectedPath
        End If

        FolderPathTextBox.Text = folderName

        LoadCSVData()
    End Sub

    Private Sub LoadCSVData()
        If (folderName <> "") Then
            LoadButton.Enabled = True
            If (My.Computer.FileSystem.FileExists(folderName + "\ClassesByTeacherLoginName.csv") And My.Computer.FileSystem.FileExists(folderName + "\StudentsForClassByLoginName.csv")) Then
                LoginNameRadioButton.Enabled = True
            Else
                LoginNameRadioButton.Enabled = False
                LoginNameComboBox.Enabled = False
                LoginNameAddNewButton.Enabled = False
            End If
            If (My.Computer.FileSystem.FileExists(folderName + "\ClassesByTeacherMachineName.csv") And My.Computer.FileSystem.FileExists(folderName + "\StudentsForClassByMachineName.csv")) Then
                MachineNameRadioButton.Enabled = True
            Else
                MachineNameRadioButton.Enabled = False
                MachineNameComboBox.Enabled = False
                MachineNameAddNewButton.Enabled = False
            End If
            If (My.Computer.FileSystem.FileExists(folderName + "\ClassesByTeacherADName.csv") And My.Computer.FileSystem.FileExists(folderName + "\StudentsForClassByADName.csv")) Then
                ADNameRadioButton.Enabled = True
            Else
                ADNameRadioButton.Enabled = False
                ADNameComboBox.Enabled = False
                ADNameAddNewButton.Enabled = False
            End If
        End If

        If (LoginNameRadioButton.Enabled Or MachineNameRadioButton.Enabled Or ADNameRadioButton.Enabled) Then
            LoadButton.Text = "Reload"
            sConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & folderName & "\;Extended Properties=""text;HDR=Yes;FMT=Delimited"";"
        Else
            LoadButton.Text = "Load"
        End If

        If (LoginNameRadioButton.Enabled) Then
            LoginNameTeacherList.Clear()

            Using adapt As New OleDbDataAdapter("SELECT DISTINCT TeacherLoginName FROM [ClassesByTeacherLoginName.csv]", sConn)
                adapt.Fill(LoginNameTeacherList)
            End Using

            LoginNameComboBox.DataSource = New BindingSource(LoginNameTeacherList, Nothing)
            LoginNameComboBox.DisplayMember = "TeacherLoginName"
        End If

        If (MachineNameRadioButton.Enabled) Then
            MachineNameTeacherList.Clear()

            Using adapt As New OleDbDataAdapter("SELECT DISTINCT TeacherMachineName FROM [ClassesByTeacherMachineName.csv]", sConn)
                adapt.Fill(MachineNameTeacherList)
            End Using

            MachineNameComboBox.DataSource = New BindingSource(MachineNameTeacherList, Nothing)
            MachineNameComboBox.DisplayMember = "TeacherMachineName"
        End If

        If (ADNameRadioButton.Enabled) Then
            ADNameTeacherList.Clear()

            Using adapt As New OleDbDataAdapter("SELECT DISTINCT TeacherADFullName FROM [ClassesByTeacherADName.csv]", sConn)
                adapt.Fill(ADNameTeacherList)
            End Using

            ADNameComboBox.DataSource = New BindingSource(ADNameTeacherList, Nothing)
            ADNameComboBox.DisplayMember = "TeacherADFullName"
        End If

    End Sub

    Private Sub LoadButton_Click(sender As Object, e As EventArgs) Handles LoadButton.Click
        folderName = FolderPathTextBox.Text

        LoadCSVData()
    End Sub

    Private Sub LoginNameRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles LoginNameRadioButton.CheckedChanged
        If (LoginNameRadioButton.Checked = True) Then
            MachineNameRadioButton.Checked = False
            ADNameRadioButton.Checked = False

            LoginNameComboBox.Enabled = True
            LoginNameAddNewButton.Enabled = True
            ClassNameListBox.Enabled = True

            EvaluateClassList()

        Else
            LoginNameComboBox.Enabled = False
            LoginNameAddNewButton.Enabled = False
        End If
    End Sub

    Private Sub MachineNameRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MachineNameRadioButton.CheckedChanged
        If (MachineNameRadioButton.Checked = True) Then
            LoginNameRadioButton.Checked = False
            ADNameRadioButton.Checked = False

            MachineNameComboBox.Enabled = True
            MachineNameAddNewButton.Enabled = True
            ClassNameListBox.Enabled = True

            EvaluateClassList()
        Else
            MachineNameComboBox.Enabled = False
            MachineNameAddNewButton.Enabled = False
        End If
    End Sub

    Private Sub ADNameRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles ADNameRadioButton.CheckedChanged
        If (ADNameRadioButton.Checked = True) Then
            LoginNameRadioButton.Checked = False
            MachineNameRadioButton.Checked = False

            ADNameComboBox.Enabled = True
            ADNameAddNewButton.Enabled = True
            ClassNameListBox.Enabled = True

            EvaluateClassList()
        Else
            ADNameComboBox.Enabled = False
            ADNameAddNewButton.Enabled = False
        End If
    End Sub

    Private Sub FolderPathTextBox_TextChanged(sender As Object, e As EventArgs) Handles FolderPathTextBox.TextChanged
        If (FolderPathTextBox.Text <> "") Then
            LoadButton.Enabled = True
            If (FolderPathTextBox.Text = folderName) Then
                LoadButton.Text = "Reload"
            Else
                LoadButton.Text = "Load"
            End If
        End If
    End Sub

    Private Sub EvaluateClassList()
        Dim sQuery As String
        If LoginNameRadioButton.Checked Then
            sQuery = "SELECT [UniqueClassIdentifier], [Personalized Class Name], [Personalized Class Name]&' ('&[UniqueClassIdentifier]&')' as ClassDisplayName FROM [ClassesByTeacherLoginName.csv] WHERE TeacherLoginName='" & LoginNameComboBox.Text & "' ORDER BY TeacherLoginName"
        ElseIf MachineNameRadioButton.Checked Then
            sQuery = "SELECT [UniqueClassIdentifier], [Personalized Class Name], [Personalized Class Name]&' ('&[UniqueClassIdentifier]&')' as ClassDisplayName FROM [ClassesByTeacherMachineName.csv] WHERE TeacherMachineName='" & MachineNameComboBox.Text & "' ORDER BY TeacherMachineName"
        ElseIf ADNameRadioButton.Checked Then
            sQuery = "SELECT [UniqueClassIdentifier], [Personalized Class Name], [Personalized Class Name]&' ('&[UniqueClassIdentifier]&')' as ClassDisplayName FROM [ClassesByTeacherADName.csv] WHERE TeacherADFullName='" & ADNameComboBox.Text & "' ORDER BY TeacherADFullName"
        Else
            Exit Sub
        End If

        TeacherClassList.Clear()

        Using adapt As New OleDbDataAdapter(sQuery, sConn)
            adapt.Fill(TeacherClassList)
        End Using

        ClassNameListBox.DataSource = TeacherClassList
        ClassNameListBox.DisplayMember = "ClassDisplayName"
        ClassNameListBox.ValueMember = "UniqueClassIdentifier"

        ClassCountLabel.Text = "Number of Classes: " & TeacherClassList.Rows.Count.ToString
        ClassCountLabel.Visible = True
        AddNewClassButton.Enabled = True

        EvaluateStudentList()
    End Sub

    Private Sub EvaluateStudentList()
        If (TeacherClassList.Rows.Count > 0 And ClassNameListBox.SelectedIndex >= 0) Then
            If Not (ClassNameListBox.SelectedValue.ToString = "" Or ClassNameListBox.SelectedValue.ToString = "System.Data.DataRowView") Then

                StudentListBox.Enabled = True
                AddNewStudentButton.Enabled = True

                Dim sQuery As String

                If LoginNameRadioButton.Checked Then
                    sQuery = "SELECT DISTINCT [StudentLoginName] FROM [StudentsForClassByLoginName.csv] WHERE UniqueClassIdentifier='" & ClassNameListBox.SelectedValue.ToString & "' ORDER BY StudentLoginName"
                    StudentListBox.DisplayMember = "StudentLoginName"
                ElseIf MachineNameRadioButton.Checked Then
                    sQuery = "SELECT DISTINCT [StudentMachineName] FROM [StudentsForClassByMachineName.csv] WHERE UniqueClassIdentifier='" & ClassNameListBox.SelectedValue.ToString & "' ORDER BY StudentMachineName"
                    StudentListBox.DisplayMember = "StudentMachineName"
                ElseIf ADNameRadioButton.Checked Then
                    sQuery = "SELECT DISTINCT [StudentADFullName] FROM [StudentsForClassByADName.csv] WHERE UniqueClassIdentifier='" & ClassNameListBox.SelectedValue.ToString & "' ORDER BY StudentADFullName"
                    StudentListBox.DisplayMember = "StudentADFullName"
                Else
                    Exit Sub
                End If

                ClassStudentList.Clear()

                Using adapt As New OleDbDataAdapter(sQuery, sConn)
                    adapt.Fill(ClassStudentList)
                End Using

                StudentListBox.DataSource = ClassStudentList
                StudentListBox.ValueMember = StudentListBox.DisplayMember

                StudentCountLabel.Text = "Number of Students: " & ClassStudentList.Rows.Count.ToString
                StudentCountLabel.Visible = True
            End If
        End If

    End Sub

    Private Sub LoginNameComboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles LoginNameComboBox.SelectedValueChanged
        If LoginNameRadioButton.Checked = True Then
            EvaluateClassList()
        End If
    End Sub

    Private Sub MachineNameComboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles MachineNameComboBox.SelectedValueChanged
        If MachineNameRadioButton.Checked = True Then
            EvaluateClassList()
        End If
    End Sub

    Private Sub ADNameComboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles ADNameComboBox.SelectedValueChanged
        If ADNameRadioButton.Checked = True Then
            EvaluateClassList()
        End If
    End Sub

    Private Sub ClassNameListBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles ClassNameListBox.SelectedValueChanged
        EvaluateStudentList()
    End Sub

    Private Sub AddNewStudentButton_Click(sender As Object, e As EventArgs) Handles AddNewStudentButton.Click
        AddStudentToClass()
    End Sub

    Private Sub StudentListBox_MouseDown(sender As Object, e As EventArgs) Handles StudentListBox.MouseDown
        Dim mousee = DirectCast(e, MouseEventArgs)
        If mousee.Button = MouseButtons.Right Then
            StudentListBox.SelectedIndex = StudentListBox.IndexFromPoint(mousee.X, mousee.Y)
            StudentListBoxRCMenuStrip.Show(MousePosition)
        End If
    End Sub

    Private Sub ClassNameListBox_MouseDown(sender As Object, e As EventArgs) Handles ClassNameListBox.MouseDown
        Dim mousee = DirectCast(e, MouseEventArgs)
        If mousee.Button = MouseButtons.Right Then
            ClassNameListBox.SelectedIndex = ClassNameListBox.IndexFromPoint(mousee.X, mousee.Y)
            ClassListBoxRCMenuStrip.Show(MousePosition)
        End If
    End Sub

    Private Sub StudentListBoxRCMenuStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles StudentListBoxRCMenuStrip.Opening
        If StudentListBox.SelectedIndex >= 0 Then
            DeleteStuListBoxRCMenuStrip.Enabled = True
        End If
    End Sub

    Private Sub StudentListBoxRCMenuStrip_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles StudentListBoxRCMenuStrip.Closing
        DeleteStuListBoxRCMenuStrip.Enabled = False
    End Sub

    Private Sub ClassListBoxRCMenuStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ClassListBoxRCMenuStrip.Opening
        If ClassNameListBox.SelectedIndex >= 0 Then
            ClassListBoxRCMenuDelete.Enabled = True
        End If
    End Sub

    Private Sub ClassListBoxRCMenuStrip_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ClassListBoxRCMenuStrip.Closing
        ClassListBoxRCMenuDelete.Enabled = False
    End Sub

    Private Sub DeleteStudentFromClass()

        If MessageBox.Show("Are you sure you want to delete this student from this class?", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        Dim filename As String
        Dim lineMatch As String = ClassNameListBox.SelectedValue.ToString & "," & StudentListBox.SelectedValue.ToString


        If LoginNameRadioButton.Checked Then
            filename = folderName & "\StudentsForClassByLoginName.csv"
        ElseIf MachineNameRadioButton.Checked Then
            filename = folderName & "\StudentsForClassByMachineName.csv"
        ElseIf ADNameRadioButton.Checked Then
            filename = folderName & "\StudentsForClassByADName.csv"
        Else
            Exit Sub
        End If

        Dim sb As New System.Text.StringBuilder
        For Each line As String In IO.File.ReadLines(filename)
            If Not (line.StartsWith(lineMatch)) Then
                sb.AppendLine(line)
            End If
        Next

        Dim AmmendedFile As String = sb.ToString

        Dim objWriter As New System.IO.StreamWriter(filename)
        objWriter.Write(AmmendedFile)
        objWriter.Close()

        EvaluateStudentList()

    End Sub

    Private Sub AddStudentToClass()
        Dim filename As String
        Dim prompt As String

        If LoginNameRadioButton.Checked Then
            filename = folderName & "\StudentsForClassByLoginName.csv"
            prompt = "Enter the student Login Name you wish to add:"
        ElseIf MachineNameRadioButton.Checked Then
            filename = folderName & "\StudentsForClassByMachineName.csv"
            prompt = "Enter the student Machine Name you wish to add:"
        ElseIf ADNameRadioButton.Checked Then
            filename = folderName & "\StudentsForClassByADName.csv"
            prompt = "Enter the student AD Name you wish to add:"
        Else
            Exit Sub
        End If

        Dim username = InputBox(prompt, "Student Info")

        If username = "" Then
            Exit Sub
        End If

        Dim newLine As String = ClassNameListBox.SelectedValue.ToString & "," & username

        Dim objWriter As New System.IO.StreamWriter(filename, True)
        objWriter.WriteLine(newLine)
        objWriter.Close()

        EvaluateStudentList()

    End Sub

    Private Sub DeleteStuListBoxRCMenuStrip_Click(sender As Object, e As EventArgs) Handles DeleteStuListBoxRCMenuStrip.Click
        DeleteStudentFromClass()
    End Sub

    Private Sub AddStuListBoxRCMenuStrip_Click(sender As Object, e As EventArgs) Handles AddStuListBoxRCMenuStrip.Click
        AddStudentToClass()
    End Sub

    Private Sub AddNewClassButton_Click(sender As Object, e As EventArgs) Handles AddNewClassButton.Click
        AddClassToTeacher()
    End Sub

    Private Sub DeleteClassFromTeacher()

        If MessageBox.Show("Are you sure you want to delete this class from this teacher?", "Are you sure?", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        Dim filename As String
        Dim lineMatch As String


        If LoginNameRadioButton.Checked Then
            filename = folderName & "\ClassesByTeacherLoginName.csv"
            lineMatch = LoginNameComboBox.Text & "," & ClassNameListBox.SelectedValue.ToString
        ElseIf MachineNameRadioButton.Checked Then
            filename = folderName & "\ClassesByTeacherMachineName.csv"
            lineMatch = MachineNameComboBox.Text & "," & ClassNameListBox.SelectedValue.ToString
        ElseIf ADNameRadioButton.Checked Then
            filename = folderName & "\ClassesByTeacherADName.csv"
            lineMatch = ADNameComboBox.Text & "," & ClassNameListBox.SelectedValue.ToString
        Else
            Exit Sub
        End If

        Dim sb As New System.Text.StringBuilder
        For Each line As String In IO.File.ReadLines(filename)
            If Not (line.StartsWith(lineMatch)) Then
                sb.AppendLine(line)
            End If
        Next

        Dim AmmendedFile As String = sb.ToString

        Dim objWriter As New System.IO.StreamWriter(filename)
        objWriter.Write(AmmendedFile)
        objWriter.Close()

        EvaluateClassList()

        If TeacherClassList.Rows.Count < 1 Then
            LoadCSVData()
        End If

    End Sub

    Private Sub AddClassToTeacher()

        AddNewUserOrClassForm.TeacherNameTextBox.Clear()
        AddNewUserOrClassForm.UniqueIDComboBox.Text = ""
        AddNewUserOrClassForm.PersonalizedNameTextBox.Clear()

        Dim strTeacherName As String
        Dim filename As String
        Dim sQuery As String

        If LoginNameRadioButton.Checked Then
            strTeacherName = "Teacher Login Name"
            filename = folderName & "\ClassesByTeacherLoginName.csv"
            AddNewUserOrClassForm.TeacherNameTextBox.Text = LoginNameComboBox.Text
            sQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherLoginName.csv] WHERE NOT TeacherLoginName='" & LoginNameComboBox.Text & "' ORDER BY UniqueClassIdentifier"
        ElseIf MachineNameRadioButton.Checked Then
            strTeacherName = "Teacher Machine Name"
            filename = folderName & "\ClassesByTeacherMachineName.csv"
            AddNewUserOrClassForm.TeacherNameTextBox.Text = MachineNameComboBox.Text
            sQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherMachineName.csv] WHERE NOT TeacherMachineName='" & MachineNameComboBox.Text & "' ORDER BY UniqueClassIdentifier"
        ElseIf ADNameRadioButton.Checked Then
            strTeacherName = "Teacher AD Name"
            filename = folderName & "\ClassesByTeacherADName.csv"
            AddNewUserOrClassForm.TeacherNameTextBox.Text = ADNameComboBox.Text
            sQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherADName.csv] WHERE NOT TeacherADFullName='" & ADNameComboBox.Text & "' ORDER BY UniqueClassIdentifier"
        Else
            Exit Sub
        End If

        AddNewUserOrClassForm.ClassList.Clear()

        Using adapt As New OleDbDataAdapter(sQuery, sConn)
            adapt.Fill(AddNewUserOrClassForm.ClassList)
        End Using

        AddNewUserOrClassForm.UniqueIDComboBox.DataSource = AddNewUserOrClassForm.ClassList
        AddNewUserOrClassForm.UniqueIDComboBox.DisplayMember = "UniqueClassIdentifier"
        AddNewUserOrClassForm.UniqueIDComboBox.ValueMember = "UniqueClassIdentifier"

        AddNewUserOrClassForm.TeacherNameTextBox.Enabled = False
        AddNewUserOrClassForm.TeacherNameLabel.Text = strTeacherName

        Dim addNewResult As New DialogResult
        Dim retryDialog As New DialogResult

        addNewResult = AddNewUserOrClassForm.ShowDialog()

        If addNewResult = DialogResult.Cancel Then
            Exit Sub
        End If

        While AddNewUserOrClassForm.UniqueIDComboBox.Text = "" Or AddNewUserOrClassForm.PersonalizedNameTextBox.Text = ""
            retryDialog = MsgBox("You must specify both a Unique Class Id and a Personalized Name.", MessageBoxButtons.RetryCancel)
            If retryDialog = DialogResult.Cancel Then
                Exit Sub
            ElseIf retryDialog = DialogResult.Retry Then
                addNewResult = AddNewUserOrClassForm.ShowDialog()
                If addNewResult = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        End While

        Dim newLine As String = AddNewUserOrClassForm.TeacherNameTextBox.Text & "," & AddNewUserOrClassForm.UniqueIDComboBox.Text & "," & AddNewUserOrClassForm.PersonalizedNameTextBox.Text

        Dim objWriter As New System.IO.StreamWriter(filename, True)
        objWriter.WriteLine(newLine)
        objWriter.Close()

        EvaluateClassList()
    End Sub

    Private Sub AddNewTeacher()

        AddNewUserOrClassForm.TeacherNameTextBox.Clear()
        AddNewUserOrClassForm.UniqueIDComboBox.Text = ""
        AddNewUserOrClassForm.PersonalizedNameTextBox.Clear()

        Dim strTeacherName As String
        Dim filename As String
        Dim sQuery As String

        If LoginNameRadioButton.Checked Then
            strTeacherName = "Teacher Login Name"
            filename = folderName & "\ClassesByTeacherLoginName.csv"
            sQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherLoginName.csv] ORDER BY UniqueClassIdentifier"
        ElseIf MachineNameRadioButton.Checked Then
            strTeacherName = "Teacher Machine Name"
            filename = folderName & "\ClassesByTeacherMachineName.csv"
            sQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherMachineName.csv] ORDER BY UniqueClassIdentifier"
        ElseIf ADNameRadioButton.Checked Then
            strTeacherName = "Teacher AD Name"
            filename = folderName & "\ClassesByTeacherADName.csv"
            sQuery = "SELECT DISTINCT [UniqueClassIdentifier] FROM [ClassesByTeacherADName.csv] ORDER BY UniqueClassIdentifier"
        Else
            Exit Sub
        End If

        AddNewUserOrClassForm.ClassList.Clear()

        Using adapt As New OleDbDataAdapter(sQuery, sConn)
            adapt.Fill(AddNewUserOrClassForm.ClassList)
        End Using

        AddNewUserOrClassForm.UniqueIDComboBox.DataSource = AddNewUserOrClassForm.ClassList
        AddNewUserOrClassForm.UniqueIDComboBox.DisplayMember = "UniqueClassIdentifier"
        AddNewUserOrClassForm.UniqueIDComboBox.ValueMember = "UniqueClassIdentifier"

        AddNewUserOrClassForm.TeacherNameLabel.Text = strTeacherName

        Dim addNewResult As New DialogResult
        Dim retryDialog As New DialogResult

        addNewResult = AddNewUserOrClassForm.ShowDialog()

        If addNewResult = DialogResult.Cancel Then
            Exit Sub
        End If

        While AddNewUserOrClassForm.TeacherNameTextBox.Text = "" Or AddNewUserOrClassForm.UniqueIDComboBox.Text = "" Or AddNewUserOrClassForm.PersonalizedNameTextBox.Text = ""
            retryDialog = MsgBox("You must specify a Teacher Name, a Unique Class Id, and a Personalized Class Name.", MessageBoxButtons.RetryCancel)
            If retryDialog = DialogResult.Cancel Then
                Exit Sub
            ElseIf retryDialog = DialogResult.Retry Then
                addNewResult = AddNewUserOrClassForm.ShowDialog()
                If addNewResult = DialogResult.Cancel Then
                    Exit Sub
                End If
            End If
        End While

        Dim newLine As String = AddNewUserOrClassForm.TeacherNameTextBox.Text & "," & AddNewUserOrClassForm.UniqueIDComboBox.Text & "," & AddNewUserOrClassForm.PersonalizedNameTextBox.Text

        Dim objWriter As New System.IO.StreamWriter(filename, True)
        objWriter.WriteLine(newLine)
        objWriter.Close()

        LoadCSVData()

        If LoginNameRadioButton.Checked Then
            LoginNameComboBox.Text = AddNewUserOrClassForm.TeacherNameTextBox.Text
        ElseIf MachineNameRadioButton.Checked Then
            MachineNameComboBox.Text = AddNewUserOrClassForm.TeacherNameTextBox.Text
        ElseIf ADNameRadioButton.Checked Then
            ADNameComboBox.Text = AddNewUserOrClassForm.TeacherNameTextBox.Text
        End If

    End Sub

    Private Sub ClassListBoxRCMenuAdd_Click(sender As Object, e As EventArgs) Handles ClassListBoxRCMenuAdd.Click
        AddClassToTeacher()
    End Sub

    Private Sub ClassListBoxRCMenuDelete_Click(sender As Object, e As EventArgs) Handles ClassListBoxRCMenuDelete.Click
        DeleteClassFromTeacher()
    End Sub

    Private Sub RefreshStuListBoxRCMenuStrip_Click(sender As Object, e As EventArgs) Handles RefreshStuListBoxRCMenuStrip.Click
        EvaluateStudentList()
    End Sub

    Private Sub RefreshClassListBoxRCMenuStrip_Click(sender As Object, e As EventArgs) Handles RefreshClassListBoxRCMenuStrip.Click
        EvaluateClassList()
    End Sub

    Private Sub LoginNameAddNewButton_Click(sender As Object, e As EventArgs) Handles LoginNameAddNewButton.Click
        AddNewTeacher()
    End Sub

    Private Sub MachineNameAddNewButton_Click(sender As Object, e As EventArgs) Handles MachineNameAddNewButton.Click
        AddNewTeacher()
    End Sub

    Private Sub ADNameAddNewButton_Click(sender As Object, e As EventArgs) Handles ADNameAddNewButton.Click
        AddNewTeacher()
    End Sub
End Class

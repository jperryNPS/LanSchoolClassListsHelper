Imports System.Data.OleDb

Public Class LanSchoolClassListsHelper

    Private folderOpened As Boolean = False
    Private folderName As String
    Private sConn As String
    Private uniqueID As String

    Private LoginNameTeacherList As New DataTable()
    Private MachineNameTeacherList As New DataTable()
    Private ADNameTeacherList As New DataTable()

    Private TeacherClassList As New DataTable()
    Private ClassStudentList As New DataTable()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximizeBox = False
        FolderPathTextBox.Text = My.Application.Info.DirectoryPath
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
            'LoginNameAddNewButton.Enabled = True
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
            'MachineNameAddNewButton.Enabled = True
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
            'ADNameAddNewButton.Enabled = True
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

        EvaluateStudentList()
    End Sub

    Private Sub EvaluateStudentList()
        If (TeacherClassList.Rows.Count > 0) Then
            If Not (ClassNameListBox.SelectedValue.ToString = "" Or ClassNameListBox.SelectedValue.ToString = "System.Data.DataRowView") Then

                StudentListBox.Enabled = True

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

    End Sub
End Class

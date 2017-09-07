<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LanSchoolClassListsHelper
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
        Me.radioLoginName = New System.Windows.Forms.RadioButton()
        Me.radioMachineName = New System.Windows.Forms.RadioButton()
        Me.radioADName = New System.Windows.Forms.RadioButton()
        Me.comboLoginName = New System.Windows.Forms.ComboBox()
        Me.comboMachineName = New System.Windows.Forms.ComboBox()
        Me.comboADName = New System.Windows.Forms.ComboBox()
        Me.listboxClassName = New System.Windows.Forms.ListBox()
        Me.listboxStudents = New System.Windows.Forms.ListBox()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.textboxFolderPath = New System.Windows.Forms.TextBox()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.buttonLoad = New System.Windows.Forms.Button()
        Me.buttonAddNewLoginName = New System.Windows.Forms.Button()
        Me.buttonAddNewMachineName = New System.Windows.Forms.Button()
        Me.buttonAddNewADName = New System.Windows.Forms.Button()
        Me.buttonAddNewClass = New System.Windows.Forms.Button()
        Me.buttonAddNewStudent = New System.Windows.Forms.Button()
        Me.labelClassCount = New System.Windows.Forms.Label()
        Me.labelStudentCount = New System.Windows.Forms.Label()
        Me.rcmenuStudentListBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.rcitemRefreshStudents = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.rcitemDeleteStudent = New System.Windows.Forms.ToolStripMenuItem()
        Me.rcitemAddStudent = New System.Windows.Forms.ToolStripMenuItem()
        Me.rcmenuClassListBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.rcitemRefreshClasses = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.rcitemDeleteClass = New System.Windows.Forms.ToolStripMenuItem()
        Me.rcitemAddClass = New System.Windows.Forms.ToolStripMenuItem()
        Me.rcitemAddTeacher = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsitemChangeDirectory = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsitemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsitemAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsitemAddLoginNameCSVFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsitemAddMachineNameCSVFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsitemAddADNameCSVFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsitemHideEmptyClasses = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsitemShowOnlyEmptyClasses = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsitemShowAllClassesByType = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsitemSaveABackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsitemRestoreABackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.rcmenuStudentListBox.SuspendLayout()
        Me.rcmenuClassListBox.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'radioLoginName
        '
        Me.radioLoginName.AutoSize = True
        Me.radioLoginName.Enabled = False
        Me.radioLoginName.Location = New System.Drawing.Point(12, 68)
        Me.radioLoginName.Name = "radioLoginName"
        Me.radioLoginName.Size = New System.Drawing.Size(82, 17)
        Me.radioLoginName.TabIndex = 4
        Me.radioLoginName.TabStop = True
        Me.radioLoginName.Text = "Login Name"
        Me.radioLoginName.UseVisualStyleBackColor = True
        '
        'radioMachineName
        '
        Me.radioMachineName.AutoSize = True
        Me.radioMachineName.Enabled = False
        Me.radioMachineName.Location = New System.Drawing.Point(12, 104)
        Me.radioMachineName.Name = "radioMachineName"
        Me.radioMachineName.Size = New System.Drawing.Size(97, 17)
        Me.radioMachineName.TabIndex = 7
        Me.radioMachineName.TabStop = True
        Me.radioMachineName.Text = "Machine Name"
        Me.radioMachineName.UseVisualStyleBackColor = True
        '
        'radioADName
        '
        Me.radioADName.AutoSize = True
        Me.radioADName.Enabled = False
        Me.radioADName.Location = New System.Drawing.Point(12, 140)
        Me.radioADName.Name = "radioADName"
        Me.radioADName.Size = New System.Drawing.Size(131, 17)
        Me.radioADName.TabIndex = 10
        Me.radioADName.TabStop = True
        Me.radioADName.Text = "Active Directory Name"
        Me.radioADName.UseVisualStyleBackColor = True
        '
        'comboLoginName
        '
        Me.comboLoginName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.comboLoginName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.comboLoginName.Enabled = False
        Me.comboLoginName.FormattingEnabled = True
        Me.comboLoginName.Location = New System.Drawing.Point(168, 66)
        Me.comboLoginName.Name = "comboLoginName"
        Me.comboLoginName.Size = New System.Drawing.Size(121, 21)
        Me.comboLoginName.TabIndex = 5
        '
        'comboMachineName
        '
        Me.comboMachineName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.comboMachineName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.comboMachineName.Enabled = False
        Me.comboMachineName.FormattingEnabled = True
        Me.comboMachineName.Location = New System.Drawing.Point(168, 102)
        Me.comboMachineName.Name = "comboMachineName"
        Me.comboMachineName.Size = New System.Drawing.Size(121, 21)
        Me.comboMachineName.TabIndex = 8
        '
        'comboADName
        '
        Me.comboADName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.comboADName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.comboADName.Enabled = False
        Me.comboADName.FormattingEnabled = True
        Me.comboADName.Location = New System.Drawing.Point(168, 138)
        Me.comboADName.Name = "comboADName"
        Me.comboADName.Size = New System.Drawing.Size(121, 21)
        Me.comboADName.TabIndex = 11
        '
        'listboxClassName
        '
        Me.listboxClassName.Enabled = False
        Me.listboxClassName.FormattingEnabled = True
        Me.listboxClassName.Location = New System.Drawing.Point(12, 175)
        Me.listboxClassName.Name = "listboxClassName"
        Me.listboxClassName.Size = New System.Drawing.Size(211, 368)
        Me.listboxClassName.TabIndex = 13
        '
        'listboxStudents
        '
        Me.listboxStudents.Enabled = False
        Me.listboxStudents.FormattingEnabled = True
        Me.listboxStudents.Location = New System.Drawing.Point(238, 175)
        Me.listboxStudents.Name = "listboxStudents"
        Me.listboxStudents.Size = New System.Drawing.Size(211, 368)
        Me.listboxStudents.TabIndex = 14
        '
        'FolderBrowserDialog
        '
        Me.FolderBrowserDialog.Description = "Please select the folder containing the LanSchool Class List CSV Files..."
        Me.FolderBrowserDialog.ShowNewFolderButton = False
        '
        'textboxFolderPath
        '
        Me.textboxFolderPath.Location = New System.Drawing.Point(12, 27)
        Me.textboxFolderPath.Name = "textboxFolderPath"
        Me.textboxFolderPath.Size = New System.Drawing.Size(277, 20)
        Me.textboxFolderPath.TabIndex = 1
        '
        'BrowseButton
        '
        Me.BrowseButton.Location = New System.Drawing.Point(295, 25)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.BrowseButton.TabIndex = 2
        Me.BrowseButton.Text = "Browse"
        Me.BrowseButton.UseVisualStyleBackColor = True
        '
        'buttonLoad
        '
        Me.buttonLoad.Enabled = False
        Me.buttonLoad.Location = New System.Drawing.Point(376, 25)
        Me.buttonLoad.Name = "buttonLoad"
        Me.buttonLoad.Size = New System.Drawing.Size(75, 23)
        Me.buttonLoad.TabIndex = 3
        Me.buttonLoad.Text = "Load"
        Me.buttonLoad.UseVisualStyleBackColor = True
        '
        'buttonAddNewLoginName
        '
        Me.buttonAddNewLoginName.Enabled = False
        Me.buttonAddNewLoginName.Location = New System.Drawing.Point(295, 64)
        Me.buttonAddNewLoginName.Name = "buttonAddNewLoginName"
        Me.buttonAddNewLoginName.Size = New System.Drawing.Size(75, 23)
        Me.buttonAddNewLoginName.TabIndex = 6
        Me.buttonAddNewLoginName.Text = "Add New"
        Me.buttonAddNewLoginName.UseVisualStyleBackColor = True
        '
        'buttonAddNewMachineName
        '
        Me.buttonAddNewMachineName.Enabled = False
        Me.buttonAddNewMachineName.Location = New System.Drawing.Point(295, 100)
        Me.buttonAddNewMachineName.Name = "buttonAddNewMachineName"
        Me.buttonAddNewMachineName.Size = New System.Drawing.Size(75, 23)
        Me.buttonAddNewMachineName.TabIndex = 9
        Me.buttonAddNewMachineName.Text = "Add New"
        Me.buttonAddNewMachineName.UseVisualStyleBackColor = True
        '
        'buttonAddNewADName
        '
        Me.buttonAddNewADName.Enabled = False
        Me.buttonAddNewADName.Location = New System.Drawing.Point(295, 136)
        Me.buttonAddNewADName.Name = "buttonAddNewADName"
        Me.buttonAddNewADName.Size = New System.Drawing.Size(75, 23)
        Me.buttonAddNewADName.TabIndex = 12
        Me.buttonAddNewADName.Text = "Add New"
        Me.buttonAddNewADName.UseVisualStyleBackColor = True
        '
        'buttonAddNewClass
        '
        Me.buttonAddNewClass.Enabled = False
        Me.buttonAddNewClass.Location = New System.Drawing.Point(148, 549)
        Me.buttonAddNewClass.Name = "buttonAddNewClass"
        Me.buttonAddNewClass.Size = New System.Drawing.Size(75, 23)
        Me.buttonAddNewClass.TabIndex = 16
        Me.buttonAddNewClass.Text = "Add New"
        Me.buttonAddNewClass.UseVisualStyleBackColor = True
        '
        'buttonAddNewStudent
        '
        Me.buttonAddNewStudent.Enabled = False
        Me.buttonAddNewStudent.Location = New System.Drawing.Point(374, 549)
        Me.buttonAddNewStudent.Name = "buttonAddNewStudent"
        Me.buttonAddNewStudent.Size = New System.Drawing.Size(75, 23)
        Me.buttonAddNewStudent.TabIndex = 18
        Me.buttonAddNewStudent.Text = "Add New"
        Me.buttonAddNewStudent.UseVisualStyleBackColor = True
        '
        'labelClassCount
        '
        Me.labelClassCount.AutoSize = True
        Me.labelClassCount.Location = New System.Drawing.Point(12, 554)
        Me.labelClassCount.Name = "labelClassCount"
        Me.labelClassCount.Size = New System.Drawing.Size(39, 13)
        Me.labelClassCount.TabIndex = 15
        Me.labelClassCount.Text = "Label1"
        Me.labelClassCount.Visible = False
        '
        'labelStudentCount
        '
        Me.labelStudentCount.AutoSize = True
        Me.labelStudentCount.Location = New System.Drawing.Point(235, 554)
        Me.labelStudentCount.Name = "labelStudentCount"
        Me.labelStudentCount.Size = New System.Drawing.Size(39, 13)
        Me.labelStudentCount.TabIndex = 17
        Me.labelStudentCount.Text = "Label2"
        Me.labelStudentCount.Visible = False
        '
        'rcmenuStudentListBox
        '
        Me.rcmenuStudentListBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rcitemRefreshStudents, Me.ToolStripSeparator1, Me.rcitemDeleteStudent, Me.rcitemAddStudent})
        Me.rcmenuStudentListBox.Name = "StudentListBoxRCMenuStrip"
        Me.rcmenuStudentListBox.Size = New System.Drawing.Size(124, 76)
        '
        'rcitemRefreshStudents
        '
        Me.rcitemRefreshStudents.Name = "rcitemRefreshStudents"
        Me.rcitemRefreshStudents.Size = New System.Drawing.Size(123, 22)
        Me.rcitemRefreshStudents.Text = "Refresh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(120, 6)
        '
        'rcitemDeleteStudent
        '
        Me.rcitemDeleteStudent.Enabled = False
        Me.rcitemDeleteStudent.Name = "rcitemDeleteStudent"
        Me.rcitemDeleteStudent.Size = New System.Drawing.Size(123, 22)
        Me.rcitemDeleteStudent.Text = "Delete"
        '
        'rcitemAddStudent
        '
        Me.rcitemAddStudent.Name = "rcitemAddStudent"
        Me.rcitemAddStudent.Size = New System.Drawing.Size(123, 22)
        Me.rcitemAddStudent.Text = "Add New"
        '
        'rcmenuClassListBox
        '
        Me.rcmenuClassListBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rcitemRefreshClasses, Me.ToolStripSeparator2, Me.rcitemDeleteClass, Me.rcitemAddClass, Me.rcitemAddTeacher})
        Me.rcmenuClassListBox.Name = "ClassListBoxRCMenuStrip"
        Me.rcmenuClassListBox.Size = New System.Drawing.Size(185, 98)
        '
        'rcitemRefreshClasses
        '
        Me.rcitemRefreshClasses.Name = "rcitemRefreshClasses"
        Me.rcitemRefreshClasses.Size = New System.Drawing.Size(184, 22)
        Me.rcitemRefreshClasses.Text = "Refresh"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(181, 6)
        '
        'rcitemDeleteClass
        '
        Me.rcitemDeleteClass.Enabled = False
        Me.rcitemDeleteClass.Name = "rcitemDeleteClass"
        Me.rcitemDeleteClass.Size = New System.Drawing.Size(184, 22)
        Me.rcitemDeleteClass.Text = "Delete"
        '
        'rcitemAddClass
        '
        Me.rcitemAddClass.Name = "rcitemAddClass"
        Me.rcitemAddClass.Size = New System.Drawing.Size(184, 22)
        Me.rcitemAddClass.Text = "Add New"
        '
        'rcitemAddTeacher
        '
        Me.rcitemAddTeacher.Enabled = False
        Me.rcitemAddTeacher.Name = "rcitemAddTeacher"
        Me.rcitemAddTeacher.Size = New System.Drawing.Size(184, 22)
        Me.rcitemAddTeacher.Text = "Add Teacher to Class"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsitemChangeDirectory, Me.ToolStripSeparator3, Me.tsitemSaveABackup, Me.tsitemRestoreABackup, Me.ToolStripSeparator5, Me.tsitemExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'tsitemChangeDirectory
        '
        Me.tsitemChangeDirectory.Name = "tsitemChangeDirectory"
        Me.tsitemChangeDirectory.Size = New System.Drawing.Size(175, 22)
        Me.tsitemChangeDirectory.Text = "Change Directory..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(172, 6)
        '
        'tsitemExit
        '
        Me.tsitemExit.Name = "tsitemExit"
        Me.tsitemExit.Size = New System.Drawing.Size(175, 22)
        Me.tsitemExit.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsitemAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'tsitemAbout
        '
        Me.tsitemAbout.Name = "tsitemAbout"
        Me.tsitemAbout.Size = New System.Drawing.Size(152, 22)
        Me.tsitemAbout.Text = "About"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(461, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsitemAddLoginNameCSVFiles, Me.tsitemAddMachineNameCSVFiles, Me.tsitemAddADNameCSVFiles})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'tsitemAddLoginNameCSVFiles
        '
        Me.tsitemAddLoginNameCSVFiles.Enabled = False
        Me.tsitemAddLoginNameCSVFiles.Name = "tsitemAddLoginNameCSVFiles"
        Me.tsitemAddLoginNameCSVFiles.Size = New System.Drawing.Size(230, 22)
        Me.tsitemAddLoginNameCSVFiles.Text = "Add Login Name CSV Files"
        '
        'tsitemAddMachineNameCSVFiles
        '
        Me.tsitemAddMachineNameCSVFiles.Enabled = False
        Me.tsitemAddMachineNameCSVFiles.Name = "tsitemAddMachineNameCSVFiles"
        Me.tsitemAddMachineNameCSVFiles.Size = New System.Drawing.Size(230, 22)
        Me.tsitemAddMachineNameCSVFiles.Text = "Add Machine Name CSV Files"
        '
        'tsitemAddADNameCSVFiles
        '
        Me.tsitemAddADNameCSVFiles.Enabled = False
        Me.tsitemAddADNameCSVFiles.Name = "tsitemAddADNameCSVFiles"
        Me.tsitemAddADNameCSVFiles.Size = New System.Drawing.Size(230, 22)
        Me.tsitemAddADNameCSVFiles.Text = "Add AD Name CSV Files"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsitemHideEmptyClasses, Me.tsitemShowOnlyEmptyClasses, Me.ToolStripSeparator4, Me.tsitemShowAllClassesByType})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'tsitemHideEmptyClasses
        '
        Me.tsitemHideEmptyClasses.Name = "tsitemHideEmptyClasses"
        Me.tsitemHideEmptyClasses.Size = New System.Drawing.Size(205, 22)
        Me.tsitemHideEmptyClasses.Text = "Hide empty classes"
        '
        'tsitemShowOnlyEmptyClasses
        '
        Me.tsitemShowOnlyEmptyClasses.Name = "tsitemShowOnlyEmptyClasses"
        Me.tsitemShowOnlyEmptyClasses.Size = New System.Drawing.Size(205, 22)
        Me.tsitemShowOnlyEmptyClasses.Text = "Show only empty classes"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(202, 6)
        '
        'tsitemShowAllClassesByType
        '
        Me.tsitemShowAllClassesByType.Name = "tsitemShowAllClassesByType"
        Me.tsitemShowAllClassesByType.Size = New System.Drawing.Size(205, 22)
        Me.tsitemShowAllClassesByType.Text = "Show all classes by type"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(172, 6)
        '
        'tsitemSaveABackup
        '
        Me.tsitemSaveABackup.Name = "tsitemSaveABackup"
        Me.tsitemSaveABackup.Size = New System.Drawing.Size(175, 22)
        Me.tsitemSaveABackup.Text = "Save a Backup..."
        '
        'tsitemRestoreABackup
        '
        Me.tsitemRestoreABackup.Name = "tsitemRestoreABackup"
        Me.tsitemRestoreABackup.Size = New System.Drawing.Size(175, 22)
        Me.tsitemRestoreABackup.Text = "Restore a Backup..."
        '
        'LanSchoolClassListsHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 584)
        Me.Controls.Add(Me.labelStudentCount)
        Me.Controls.Add(Me.labelClassCount)
        Me.Controls.Add(Me.buttonAddNewStudent)
        Me.Controls.Add(Me.buttonAddNewClass)
        Me.Controls.Add(Me.buttonAddNewADName)
        Me.Controls.Add(Me.buttonAddNewMachineName)
        Me.Controls.Add(Me.buttonAddNewLoginName)
        Me.Controls.Add(Me.buttonLoad)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.textboxFolderPath)
        Me.Controls.Add(Me.listboxStudents)
        Me.Controls.Add(Me.listboxClassName)
        Me.Controls.Add(Me.comboADName)
        Me.Controls.Add(Me.comboMachineName)
        Me.Controls.Add(Me.comboLoginName)
        Me.Controls.Add(Me.radioADName)
        Me.Controls.Add(Me.radioMachineName)
        Me.Controls.Add(Me.radioLoginName)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "LanSchoolClassListsHelper"
        Me.Text = "LanSchool Class Lists Helper"
        Me.rcmenuStudentListBox.ResumeLayout(False)
        Me.rcmenuClassListBox.ResumeLayout(False)
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents radioLoginName As RadioButton
    Friend WithEvents radioMachineName As RadioButton
    Friend WithEvents radioADName As RadioButton
    Friend WithEvents comboLoginName As ComboBox
    Friend WithEvents comboMachineName As ComboBox
    Friend WithEvents comboADName As ComboBox
    Friend WithEvents listboxClassName As ListBox
    Friend WithEvents listboxStudents As ListBox
    Friend WithEvents FolderBrowserDialog As FolderBrowserDialog
    Friend WithEvents textboxFolderPath As TextBox
    Friend WithEvents BrowseButton As Button
    Friend WithEvents buttonLoad As Button
    Friend WithEvents buttonAddNewLoginName As Button
    Friend WithEvents buttonAddNewMachineName As Button
    Friend WithEvents buttonAddNewADName As Button
    Friend WithEvents buttonAddNewClass As Button
    Friend WithEvents buttonAddNewStudent As Button
    Friend WithEvents labelClassCount As Label
    Friend WithEvents labelStudentCount As Label
    Friend WithEvents rcmenuStudentListBox As ContextMenuStrip
    Friend WithEvents rcitemDeleteStudent As ToolStripMenuItem
    Friend WithEvents rcitemAddStudent As ToolStripMenuItem
    Friend WithEvents rcmenuClassListBox As ContextMenuStrip
    Friend WithEvents rcitemDeleteClass As ToolStripMenuItem
    Friend WithEvents rcitemAddClass As ToolStripMenuItem
    Friend WithEvents rcitemRefreshStudents As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents rcitemRefreshClasses As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents rcitemAddTeacher As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsitemChangeDirectory As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsitemExit As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsitemAbout As ToolStripMenuItem
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsitemHideEmptyClasses As ToolStripMenuItem
    Friend WithEvents tsitemShowOnlyEmptyClasses As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsitemShowAllClassesByType As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsitemAddLoginNameCSVFiles As ToolStripMenuItem
    Friend WithEvents tsitemAddMachineNameCSVFiles As ToolStripMenuItem
    Friend WithEvents tsitemAddADNameCSVFiles As ToolStripMenuItem
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents tsitemSaveABackup As ToolStripMenuItem
    Friend WithEvents tsitemRestoreABackup As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
End Class

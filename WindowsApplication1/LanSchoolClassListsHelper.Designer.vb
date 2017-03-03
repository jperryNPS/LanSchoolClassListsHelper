<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LanSchoolClassListsHelper
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginNameRadioButton = New System.Windows.Forms.RadioButton()
        Me.MachineNameRadioButton = New System.Windows.Forms.RadioButton()
        Me.ADNameRadioButton = New System.Windows.Forms.RadioButton()
        Me.LoginNameComboBox = New System.Windows.Forms.ComboBox()
        Me.MachineNameComboBox = New System.Windows.Forms.ComboBox()
        Me.ADNameComboBox = New System.Windows.Forms.ComboBox()
        Me.ClassNameListBox = New System.Windows.Forms.ListBox()
        Me.StudentListBox = New System.Windows.Forms.ListBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderPathTextBox = New System.Windows.Forms.TextBox()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.LoadButton = New System.Windows.Forms.Button()
        Me.LoginNameAddNewButton = New System.Windows.Forms.Button()
        Me.MachineNameAddNewButton = New System.Windows.Forms.Button()
        Me.ADNameAddNewButton = New System.Windows.Forms.Button()
        Me.AddNewClassButton = New System.Windows.Forms.Button()
        Me.AddNewStudentButton = New System.Windows.Forms.Button()
        Me.ClassCountLabel = New System.Windows.Forms.Label()
        Me.StudentCountLabel = New System.Windows.Forms.Label()
        Me.StudentListBoxRCMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteStuListBoxRCMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStuListBoxRCMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassListBoxRCMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClassListBoxRCMenuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassListBoxRCMenuAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshStuListBoxRCMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshClassListBoxRCMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1.SuspendLayout()
        Me.StudentListBoxRCMenuStrip.SuspendLayout()
        Me.ClassListBoxRCMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(461, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.OpenToolStripMenuItem.Text = "Open..."
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'LoginNameRadioButton
        '
        Me.LoginNameRadioButton.AutoSize = True
        Me.LoginNameRadioButton.Enabled = False
        Me.LoginNameRadioButton.Location = New System.Drawing.Point(12, 68)
        Me.LoginNameRadioButton.Name = "LoginNameRadioButton"
        Me.LoginNameRadioButton.Size = New System.Drawing.Size(82, 17)
        Me.LoginNameRadioButton.TabIndex = 4
        Me.LoginNameRadioButton.TabStop = True
        Me.LoginNameRadioButton.Text = "Login Name"
        Me.LoginNameRadioButton.UseVisualStyleBackColor = True
        '
        'MachineNameRadioButton
        '
        Me.MachineNameRadioButton.AutoSize = True
        Me.MachineNameRadioButton.Enabled = False
        Me.MachineNameRadioButton.Location = New System.Drawing.Point(12, 104)
        Me.MachineNameRadioButton.Name = "MachineNameRadioButton"
        Me.MachineNameRadioButton.Size = New System.Drawing.Size(97, 17)
        Me.MachineNameRadioButton.TabIndex = 7
        Me.MachineNameRadioButton.TabStop = True
        Me.MachineNameRadioButton.Text = "Machine Name"
        Me.MachineNameRadioButton.UseVisualStyleBackColor = True
        '
        'ADNameRadioButton
        '
        Me.ADNameRadioButton.AutoSize = True
        Me.ADNameRadioButton.Enabled = False
        Me.ADNameRadioButton.Location = New System.Drawing.Point(12, 140)
        Me.ADNameRadioButton.Name = "ADNameRadioButton"
        Me.ADNameRadioButton.Size = New System.Drawing.Size(131, 17)
        Me.ADNameRadioButton.TabIndex = 10
        Me.ADNameRadioButton.TabStop = True
        Me.ADNameRadioButton.Text = "Active Directory Name"
        Me.ADNameRadioButton.UseVisualStyleBackColor = True
        '
        'LoginNameComboBox
        '
        Me.LoginNameComboBox.Enabled = False
        Me.LoginNameComboBox.FormattingEnabled = True
        Me.LoginNameComboBox.Location = New System.Drawing.Point(168, 66)
        Me.LoginNameComboBox.Name = "LoginNameComboBox"
        Me.LoginNameComboBox.Size = New System.Drawing.Size(121, 21)
        Me.LoginNameComboBox.TabIndex = 5
        '
        'MachineNameComboBox
        '
        Me.MachineNameComboBox.Enabled = False
        Me.MachineNameComboBox.FormattingEnabled = True
        Me.MachineNameComboBox.Location = New System.Drawing.Point(168, 102)
        Me.MachineNameComboBox.Name = "MachineNameComboBox"
        Me.MachineNameComboBox.Size = New System.Drawing.Size(121, 21)
        Me.MachineNameComboBox.TabIndex = 8
        '
        'ADNameComboBox
        '
        Me.ADNameComboBox.Enabled = False
        Me.ADNameComboBox.FormattingEnabled = True
        Me.ADNameComboBox.Location = New System.Drawing.Point(168, 138)
        Me.ADNameComboBox.Name = "ADNameComboBox"
        Me.ADNameComboBox.Size = New System.Drawing.Size(121, 21)
        Me.ADNameComboBox.TabIndex = 11
        '
        'ClassNameListBox
        '
        Me.ClassNameListBox.Enabled = False
        Me.ClassNameListBox.FormattingEnabled = True
        Me.ClassNameListBox.Location = New System.Drawing.Point(12, 175)
        Me.ClassNameListBox.Name = "ClassNameListBox"
        Me.ClassNameListBox.Size = New System.Drawing.Size(211, 368)
        Me.ClassNameListBox.TabIndex = 13
        '
        'StudentListBox
        '
        Me.StudentListBox.Enabled = False
        Me.StudentListBox.FormattingEnabled = True
        Me.StudentListBox.Location = New System.Drawing.Point(238, 175)
        Me.StudentListBox.Name = "StudentListBox"
        Me.StudentListBox.Size = New System.Drawing.Size(211, 368)
        Me.StudentListBox.TabIndex = 14
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Please select the folder containing the LanSchool Class List CSV Files..."
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'FolderPathTextBox
        '
        Me.FolderPathTextBox.Location = New System.Drawing.Point(12, 27)
        Me.FolderPathTextBox.Name = "FolderPathTextBox"
        Me.FolderPathTextBox.Size = New System.Drawing.Size(277, 20)
        Me.FolderPathTextBox.TabIndex = 1
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
        'LoadButton
        '
        Me.LoadButton.Enabled = False
        Me.LoadButton.Location = New System.Drawing.Point(376, 25)
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.Size = New System.Drawing.Size(75, 23)
        Me.LoadButton.TabIndex = 3
        Me.LoadButton.Text = "Load"
        Me.LoadButton.UseVisualStyleBackColor = True
        '
        'LoginNameAddNewButton
        '
        Me.LoginNameAddNewButton.Enabled = False
        Me.LoginNameAddNewButton.Location = New System.Drawing.Point(295, 64)
        Me.LoginNameAddNewButton.Name = "LoginNameAddNewButton"
        Me.LoginNameAddNewButton.Size = New System.Drawing.Size(75, 23)
        Me.LoginNameAddNewButton.TabIndex = 6
        Me.LoginNameAddNewButton.Text = "Add New"
        Me.LoginNameAddNewButton.UseVisualStyleBackColor = True
        '
        'MachineNameAddNewButton
        '
        Me.MachineNameAddNewButton.Enabled = False
        Me.MachineNameAddNewButton.Location = New System.Drawing.Point(295, 100)
        Me.MachineNameAddNewButton.Name = "MachineNameAddNewButton"
        Me.MachineNameAddNewButton.Size = New System.Drawing.Size(75, 23)
        Me.MachineNameAddNewButton.TabIndex = 9
        Me.MachineNameAddNewButton.Text = "Add New"
        Me.MachineNameAddNewButton.UseVisualStyleBackColor = True
        '
        'ADNameAddNewButton
        '
        Me.ADNameAddNewButton.Enabled = False
        Me.ADNameAddNewButton.Location = New System.Drawing.Point(295, 136)
        Me.ADNameAddNewButton.Name = "ADNameAddNewButton"
        Me.ADNameAddNewButton.Size = New System.Drawing.Size(75, 23)
        Me.ADNameAddNewButton.TabIndex = 12
        Me.ADNameAddNewButton.Text = "Add New"
        Me.ADNameAddNewButton.UseVisualStyleBackColor = True
        '
        'AddNewClassButton
        '
        Me.AddNewClassButton.Enabled = False
        Me.AddNewClassButton.Location = New System.Drawing.Point(148, 549)
        Me.AddNewClassButton.Name = "AddNewClassButton"
        Me.AddNewClassButton.Size = New System.Drawing.Size(75, 23)
        Me.AddNewClassButton.TabIndex = 16
        Me.AddNewClassButton.Text = "Add New"
        Me.AddNewClassButton.UseVisualStyleBackColor = True
        '
        'AddNewStudentButton
        '
        Me.AddNewStudentButton.Enabled = False
        Me.AddNewStudentButton.Location = New System.Drawing.Point(374, 549)
        Me.AddNewStudentButton.Name = "AddNewStudentButton"
        Me.AddNewStudentButton.Size = New System.Drawing.Size(75, 23)
        Me.AddNewStudentButton.TabIndex = 18
        Me.AddNewStudentButton.Text = "Add New"
        Me.AddNewStudentButton.UseVisualStyleBackColor = True
        '
        'ClassCountLabel
        '
        Me.ClassCountLabel.AutoSize = True
        Me.ClassCountLabel.Location = New System.Drawing.Point(12, 554)
        Me.ClassCountLabel.Name = "ClassCountLabel"
        Me.ClassCountLabel.Size = New System.Drawing.Size(39, 13)
        Me.ClassCountLabel.TabIndex = 15
        Me.ClassCountLabel.Text = "Label1"
        Me.ClassCountLabel.Visible = False
        '
        'StudentCountLabel
        '
        Me.StudentCountLabel.AutoSize = True
        Me.StudentCountLabel.Location = New System.Drawing.Point(235, 554)
        Me.StudentCountLabel.Name = "StudentCountLabel"
        Me.StudentCountLabel.Size = New System.Drawing.Size(39, 13)
        Me.StudentCountLabel.TabIndex = 17
        Me.StudentCountLabel.Text = "Label2"
        Me.StudentCountLabel.Visible = False
        '
        'StudentListBoxRCMenuStrip
        '
        Me.StudentListBoxRCMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshStuListBoxRCMenuStrip, Me.ToolStripSeparator1, Me.DeleteStuListBoxRCMenuStrip, Me.AddStuListBoxRCMenuStrip})
        Me.StudentListBoxRCMenuStrip.Name = "StudentListBoxRCMenuStrip"
        Me.StudentListBoxRCMenuStrip.Size = New System.Drawing.Size(124, 76)
        '
        'DeleteStuListBoxRCMenuStrip
        '
        Me.DeleteStuListBoxRCMenuStrip.Enabled = False
        Me.DeleteStuListBoxRCMenuStrip.Name = "DeleteStuListBoxRCMenuStrip"
        Me.DeleteStuListBoxRCMenuStrip.Size = New System.Drawing.Size(123, 22)
        Me.DeleteStuListBoxRCMenuStrip.Text = "Delete"
        '
        'AddStuListBoxRCMenuStrip
        '
        Me.AddStuListBoxRCMenuStrip.Name = "AddStuListBoxRCMenuStrip"
        Me.AddStuListBoxRCMenuStrip.Size = New System.Drawing.Size(123, 22)
        Me.AddStuListBoxRCMenuStrip.Text = "Add New"
        '
        'ClassListBoxRCMenuStrip
        '
        Me.ClassListBoxRCMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshClassListBoxRCMenuStrip, Me.ToolStripSeparator2, Me.ClassListBoxRCMenuDelete, Me.ClassListBoxRCMenuAdd})
        Me.ClassListBoxRCMenuStrip.Name = "ClassListBoxRCMenuStrip"
        Me.ClassListBoxRCMenuStrip.Size = New System.Drawing.Size(124, 76)
        '
        'ClassListBoxRCMenuDelete
        '
        Me.ClassListBoxRCMenuDelete.Enabled = False
        Me.ClassListBoxRCMenuDelete.Name = "ClassListBoxRCMenuDelete"
        Me.ClassListBoxRCMenuDelete.Size = New System.Drawing.Size(152, 22)
        Me.ClassListBoxRCMenuDelete.Text = "Delete"
        '
        'ClassListBoxRCMenuAdd
        '
        Me.ClassListBoxRCMenuAdd.Name = "ClassListBoxRCMenuAdd"
        Me.ClassListBoxRCMenuAdd.Size = New System.Drawing.Size(152, 22)
        Me.ClassListBoxRCMenuAdd.Text = "Add New"
        '
        'RefreshStuListBoxRCMenuStrip
        '
        Me.RefreshStuListBoxRCMenuStrip.Name = "RefreshStuListBoxRCMenuStrip"
        Me.RefreshStuListBoxRCMenuStrip.Size = New System.Drawing.Size(123, 22)
        Me.RefreshStuListBoxRCMenuStrip.Text = "Refresh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(120, 6)
        '
        'RefreshClassListBoxRCMenuStrip
        '
        Me.RefreshClassListBoxRCMenuStrip.Name = "RefreshClassListBoxRCMenuStrip"
        Me.RefreshClassListBoxRCMenuStrip.Size = New System.Drawing.Size(152, 22)
        Me.RefreshClassListBoxRCMenuStrip.Text = "Refresh"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'LanSchoolClassListsHelper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 584)
        Me.Controls.Add(Me.StudentCountLabel)
        Me.Controls.Add(Me.ClassCountLabel)
        Me.Controls.Add(Me.AddNewStudentButton)
        Me.Controls.Add(Me.AddNewClassButton)
        Me.Controls.Add(Me.ADNameAddNewButton)
        Me.Controls.Add(Me.MachineNameAddNewButton)
        Me.Controls.Add(Me.LoginNameAddNewButton)
        Me.Controls.Add(Me.LoadButton)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.FolderPathTextBox)
        Me.Controls.Add(Me.StudentListBox)
        Me.Controls.Add(Me.ClassNameListBox)
        Me.Controls.Add(Me.ADNameComboBox)
        Me.Controls.Add(Me.MachineNameComboBox)
        Me.Controls.Add(Me.LoginNameComboBox)
        Me.Controls.Add(Me.ADNameRadioButton)
        Me.Controls.Add(Me.MachineNameRadioButton)
        Me.Controls.Add(Me.LoginNameRadioButton)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "LanSchoolClassListsHelper"
        Me.Text = "LanSchool Class Lists Helper"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StudentListBoxRCMenuStrip.ResumeLayout(False)
        Me.ClassListBoxRCMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoginNameRadioButton As RadioButton
    Friend WithEvents MachineNameRadioButton As RadioButton
    Friend WithEvents ADNameRadioButton As RadioButton
    Friend WithEvents LoginNameComboBox As ComboBox
    Friend WithEvents MachineNameComboBox As ComboBox
    Friend WithEvents ADNameComboBox As ComboBox
    Friend WithEvents ClassNameListBox As ListBox
    Friend WithEvents StudentListBox As ListBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents FolderPathTextBox As TextBox
    Friend WithEvents BrowseButton As Button
    Friend WithEvents LoadButton As Button
    Friend WithEvents LoginNameAddNewButton As Button
    Friend WithEvents MachineNameAddNewButton As Button
    Friend WithEvents ADNameAddNewButton As Button
    Friend WithEvents AddNewClassButton As Button
    Friend WithEvents AddNewStudentButton As Button
    Friend WithEvents ClassCountLabel As Label
    Friend WithEvents StudentCountLabel As Label
    Friend WithEvents StudentListBoxRCMenuStrip As ContextMenuStrip
    Friend WithEvents DeleteStuListBoxRCMenuStrip As ToolStripMenuItem
    Friend WithEvents AddStuListBoxRCMenuStrip As ToolStripMenuItem
    Friend WithEvents ClassListBoxRCMenuStrip As ContextMenuStrip
    Friend WithEvents ClassListBoxRCMenuDelete As ToolStripMenuItem
    Friend WithEvents ClassListBoxRCMenuAdd As ToolStripMenuItem
    Friend WithEvents RefreshStuListBoxRCMenuStrip As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents RefreshClassListBoxRCMenuStrip As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class

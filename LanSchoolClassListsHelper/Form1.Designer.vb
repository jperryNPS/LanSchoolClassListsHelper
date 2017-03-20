<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddNewUserOrClassForm
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
        Me.OKButton = New System.Windows.Forms.Button()
        Me.CancelButton1 = New System.Windows.Forms.Button()
        Me.TeacherNameLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UniqueIDComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PersonalizedNameTextBox = New System.Windows.Forms.TextBox()
        Me.TeacherNameTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKButton.Location = New System.Drawing.Point(134, 113)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 6
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'CancelButton1
        '
        Me.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton1.Location = New System.Drawing.Point(215, 113)
        Me.CancelButton1.Name = "CancelButton1"
        Me.CancelButton1.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton1.TabIndex = 7
        Me.CancelButton1.Text = "Cancel"
        Me.CancelButton1.UseVisualStyleBackColor = True
        '
        'TeacherNameLabel
        '
        Me.TeacherNameLabel.AutoSize = True
        Me.TeacherNameLabel.Location = New System.Drawing.Point(12, 15)
        Me.TeacherNameLabel.Name = "TeacherNameLabel"
        Me.TeacherNameLabel.Size = New System.Drawing.Size(122, 13)
        Me.TeacherNameLabel.TabIndex = 0
        Me.TeacherNameLabel.Text = "Teacher Machine Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Unique Class ID"
        '
        'UniqueIDComboBox
        '
        Me.UniqueIDComboBox.FormattingEnabled = True
        Me.UniqueIDComboBox.Location = New System.Drawing.Point(144, 46)
        Me.UniqueIDComboBox.Name = "UniqueIDComboBox"
        Me.UniqueIDComboBox.Size = New System.Drawing.Size(146, 21)
        Me.UniqueIDComboBox.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Personalized Class Name"
        '
        'PersonalizedNameTextBox
        '
        Me.PersonalizedNameTextBox.Location = New System.Drawing.Point(144, 80)
        Me.PersonalizedNameTextBox.Name = "PersonalizedNameTextBox"
        Me.PersonalizedNameTextBox.Size = New System.Drawing.Size(146, 20)
        Me.PersonalizedNameTextBox.TabIndex = 5
        '
        'TeacherNameTextBox
        '
        Me.TeacherNameTextBox.Location = New System.Drawing.Point(144, 12)
        Me.TeacherNameTextBox.Name = "TeacherNameTextBox"
        Me.TeacherNameTextBox.Size = New System.Drawing.Size(146, 20)
        Me.TeacherNameTextBox.TabIndex = 8
        '
        'AddNewUserOrClassForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 149)
        Me.Controls.Add(Me.TeacherNameTextBox)
        Me.Controls.Add(Me.PersonalizedNameTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.UniqueIDComboBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TeacherNameLabel)
        Me.Controls.Add(Me.CancelButton1)
        Me.Controls.Add(Me.OKButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "AddNewUserOrClassForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New User or Class"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OKButton As Button
    Friend WithEvents CancelButton1 As Button
    Friend WithEvents TeacherNameLabel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Public WithEvents UniqueIDComboBox As ComboBox
    Public WithEvents PersonalizedNameTextBox As TextBox
    Friend WithEvents TeacherNameTextBox As TextBox
End Class

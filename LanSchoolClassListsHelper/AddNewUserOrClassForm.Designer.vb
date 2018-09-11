<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddNewUserOrClassForm
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
        Me.OKButton = New System.Windows.Forms.Button()
        Me.CancelButton1 = New System.Windows.Forms.Button()
        Me.labelTeacherNamePrompt = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.comboUniqueClassID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textboxPersonalizedName = New System.Windows.Forms.TextBox()
        Me.textboxTeacherName = New System.Windows.Forms.TextBox()
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
        'labelTeacherNamePrompt
        '
        Me.labelTeacherNamePrompt.AutoSize = True
        Me.labelTeacherNamePrompt.Location = New System.Drawing.Point(12, 15)
        Me.labelTeacherNamePrompt.Name = "labelTeacherNamePrompt"
        Me.labelTeacherNamePrompt.Size = New System.Drawing.Size(122, 13)
        Me.labelTeacherNamePrompt.TabIndex = 0
        Me.labelTeacherNamePrompt.Text = "Teacher Machine Name"
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
        'comboUniqueClassID
        '
        Me.comboUniqueClassID.FormattingEnabled = True
        Me.comboUniqueClassID.Location = New System.Drawing.Point(144, 46)
        Me.comboUniqueClassID.Name = "comboUniqueClassID"
        Me.comboUniqueClassID.Size = New System.Drawing.Size(146, 21)
        Me.comboUniqueClassID.TabIndex = 3
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
        'textboxPersonalizedName
        '
        Me.textboxPersonalizedName.Location = New System.Drawing.Point(144, 80)
        Me.textboxPersonalizedName.Name = "textboxPersonalizedName"
        Me.textboxPersonalizedName.Size = New System.Drawing.Size(146, 20)
        Me.textboxPersonalizedName.TabIndex = 5
        '
        'textboxTeacherName
        '
        Me.textboxTeacherName.Location = New System.Drawing.Point(144, 12)
        Me.textboxTeacherName.Name = "textboxTeacherName"
        Me.textboxTeacherName.Size = New System.Drawing.Size(146, 20)
        Me.textboxTeacherName.TabIndex = 8
        '
        'AddNewUserOrClassForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 149)
        Me.Controls.Add(Me.textboxTeacherName)
        Me.Controls.Add(Me.textboxPersonalizedName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.comboUniqueClassID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.labelTeacherNamePrompt)
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
    Friend WithEvents labelTeacherNamePrompt As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Public WithEvents comboUniqueClassID As ComboBox
    Public WithEvents textboxPersonalizedName As TextBox
    Friend WithEvents textboxTeacherName As TextBox
End Class

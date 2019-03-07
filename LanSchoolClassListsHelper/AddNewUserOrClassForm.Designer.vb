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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKButton.Location = New System.Drawing.Point(135, 82)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 6
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'CancelButton1
        '
        Me.CancelButton1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelButton1.Location = New System.Drawing.Point(216, 82)
        Me.CancelButton1.Name = "CancelButton1"
        Me.CancelButton1.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton1.TabIndex = 7
        Me.CancelButton1.Text = "Cancel"
        Me.CancelButton1.UseVisualStyleBackColor = True
        '
        'labelTeacherNamePrompt
        '
        Me.labelTeacherNamePrompt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelTeacherNamePrompt.AutoSize = True
        Me.labelTeacherNamePrompt.Location = New System.Drawing.Point(3, 0)
        Me.labelTeacherNamePrompt.Name = "labelTeacherNamePrompt"
        Me.labelTeacherNamePrompt.Size = New System.Drawing.Size(126, 26)
        Me.labelTeacherNamePrompt.TabIndex = 0
        Me.labelTeacherNamePrompt.Text = "Teacher Machine Name"
        Me.labelTeacherNamePrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 27)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Unique Class ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'comboUniqueClassID
        '
        Me.comboUniqueClassID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.comboUniqueClassID, 3)
        Me.comboUniqueClassID.FormattingEnabled = True
        Me.comboUniqueClassID.Location = New System.Drawing.Point(135, 29)
        Me.comboUniqueClassID.Name = "comboUniqueClassID"
        Me.comboUniqueClassID.Size = New System.Drawing.Size(156, 21)
        Me.comboUniqueClassID.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 26)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Personalized Class Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textboxPersonalizedName
        '
        Me.textboxPersonalizedName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.textboxPersonalizedName, 3)
        Me.textboxPersonalizedName.Location = New System.Drawing.Point(135, 56)
        Me.textboxPersonalizedName.Name = "textboxPersonalizedName"
        Me.textboxPersonalizedName.Size = New System.Drawing.Size(156, 20)
        Me.textboxPersonalizedName.TabIndex = 5
        '
        'textboxTeacherName
        '
        Me.textboxTeacherName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.textboxTeacherName, 3)
        Me.textboxTeacherName.Location = New System.Drawing.Point(135, 3)
        Me.textboxTeacherName.Name = "textboxTeacherName"
        Me.textboxTeacherName.Size = New System.Drawing.Size(156, 20)
        Me.textboxTeacherName.TabIndex = 8
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CancelButton1, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.labelTeacherNamePrompt, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.OKButton, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.textboxTeacherName, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.comboUniqueClassID, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.textboxPersonalizedName, 1, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(294, 108)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'AddNewUserOrClassForm
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelButton1
        Me.ClientSize = New System.Drawing.Size(318, 132)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "AddNewUserOrClassForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add New User or Class"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OKButton As Button
    Friend WithEvents CancelButton1 As Button
    Friend WithEvents labelTeacherNamePrompt As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Public WithEvents comboUniqueClassID As ComboBox
    Public WithEvents textboxPersonalizedName As TextBox
    Friend WithEvents textboxTeacherName As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
End Class

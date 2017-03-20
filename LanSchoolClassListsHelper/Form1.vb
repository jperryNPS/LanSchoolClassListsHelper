Public Class AddNewUserOrClassForm
    Public TeacherList As New DataTable()
    Public ClassList As New DataTable()

    Private Sub AddNewUserOrClassForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximizeBox = False
        MinimizeBox = False
    End Sub
End Class
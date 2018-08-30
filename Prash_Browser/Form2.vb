Public Class Form2

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        MsgBox("Theme Changed to " & ComboBox1.SelectedItem.ToString())
        If ComboBox1.SelectedItem.ToString() = "Red" Then
            Form1.BackColor = Color.Red
        ElseIf ComboBox1.SelectedItem.ToString() = "Green" Then
            Form1.BackColor = Color.Green
        ElseIf ComboBox1.SelectedItem.ToString() = "Blue" Then
            Form1.BackColor = Color.Blue
        Else
            Form1.BackColor = Color.White

        End If
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub WebBrowser1_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WebBrowser1.NewWindow


        Dim myElement As HtmlElement = WebBrowser1.Document.ActiveElement
        Dim target As String = myElement.GetAttribute("href")

        Dim newInstance As New Form3
        newInstance.Show()
        newInstance.WebBrowser1.ScriptErrorsSuppressed = True
        newInstance.WebBrowser1.Navigate(target)

        e.Cancel = True
    End Sub

    Private Sub WebBrowser1_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles WebBrowser1.ProgressChanged
        ProgressBar1.Value = 0
        If e.MaximumProgress <> 0 And e.MaximumProgress >= e.CurrentProgress Then
            ProgressBar1.Value = Convert.ToInt32(100 * e.CurrentProgress / e.MaximumProgress)

        Else
            With ProgressBar1
                .Value = 100
                .Visible = True
            End With
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Dim page As String = WebBrowser1.DocumentTitle
        If String.Compare(page, "Navigation Canceled") = 0 Then
            Me.Text = "Error : From Browsiee , copyrights prashanth kondedath"
        ElseIf String.Compare(page, "Internet Explorer cannot display the webpage") = 0 Then
            Me.Text = "Error : From Browsiee , copyrights prashanth kondedath"
        Else
            Me.Text = page & " : From Browsiee , copyrights prashanth kondedath"
        End If
    End Sub
End Class
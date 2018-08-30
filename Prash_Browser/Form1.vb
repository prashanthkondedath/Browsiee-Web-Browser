Imports FlickrNet
Public Class Form1
    Private m_PanStartPoint As New Point
    Dim i As Integer = 1
    ' Dim FirstTime As Boolean = True
    Dim WebB As WebBrowser
    Dim lasttabdel As Boolean = False
    Dim firstload As Boolean = True
    ' Dim flickr As New Flickr("69f89bdd1acde0be4b30e1c3a951040a")


    'Private Sub Form1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

    '    TabControl1.Visible = True
    '    Button7.Visible = True
    '    Button8.Visible = True
    'End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        PictureBox1.Visible = False
        nonet.Visible = False




        Button7.Visible = True
        AddNewtab("www.google.com")


    End Sub

    Private Sub AddNewtab(ByVal url As String)
        Try
            '     If FirstTime = True Then
            Dim tab As New TabPage
            Dim brws As New WebBrowser
            AddHandler brws.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf Run_Me_On_Load)
            AddHandler brws.ProgressChanged, New WebBrowserProgressChangedEventHandler(AddressOf Run_on_webBrowserProgress_Change)

            AddHandler brws.NewWindow, AddressOf BrowserNewWindow
            brws.Dock = DockStyle.Fill
            tab.Text = "loading.."
            Me.Text = "loading.."
            tab.Controls.Add(brws)
            Me.TabControl1.TabPages.Add(tab)
            Me.TabControl1.SelectedTab = tab
            brws.ScriptErrorsSuppressed = True
            brws.Navigate(url)

            '      End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.Control And e.KeyCode = Keys.Enter Then
            TextBox1.Text = "www." & TextBox1.Text & ".com"
            '  WebBrowser1.Navigate(TextBox1.Text)
            If TabControl1.TabPages.Count > 0 Then
                CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(TextBox1.Text)
            Else
                AddNewtab(TextBox1.Text)
            End If
        ElseIf e.KeyData = Keys.Enter And TabControl1.TabPages.Count > 0 Then
            '  WebBrowser1.Navigate(TextBox1.Text)
            If TabControl1.TabPages.Count > 0 Then
                CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(TextBox1.Text)
            Else
                AddNewtab(TextBox1.Text)
            End If
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Form2.Show()
    End Sub
    'Private Sub WebBrowser1_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WebBrowser1.NewWindow


    '    Dim myElement As HtmlElement = WebBrowser1.Document.ActiveElement
    '    Dim target As String = myElement.GetAttribute("href")

    '    Dim newInstance As New Form1
    '    newInstance.Show()
    '    newInstance.WebBrowser1.Navigate(target)

    '    e.Cancel = True
    'End Sub

    'Private Sub WebBrowser1_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
    '    Try
    '        TextBox1.Text = WebBrowser1.Url.ToString()
    '    Catch
    '    End Try
    '    'TextBox1.Text = "loaded"
    'End Sub

    'Private Sub WebBrowser1_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles WebBrowser1.ProgressChanged
    '    If e.MaximumProgress <> 0 And e.MaximumProgress >= e.CurrentProgress Then
    '        ProgressBar1.Value = Convert.ToInt32(100 * e.CurrentProgress / e.MaximumProgress)

    '    Else
    '        With ProgressBar1
    '            .Value = 0
    '            .Visible = True
    '        End With
    '    End If
    'End Sub





    'Private Sub WebBrowser_DocumentCompleted(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
    '    'your url text box will show the actual url of the page after the page is fully loaded        
    '    ' cbxUrl.Text = e.Url.ToString
    '    Me.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle & " - Webbrowser's name"
    '    TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle

    'End Sub


    'Private Sub WebBrowser_Navigated(ByVal sender As Object, ByVal e As WebBrowserNavigatedEventArgs)
    '    Me.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle & " - WebBrowser's Name"
    '    TabControl1.SelectedTab.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle
    'End Sub



    Private Sub deletebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deletebtn.Click
        'TabControl1.TabPages.RemoveAt(TabControl1.SelectedIndex)
        'If TabControl1.TabPages.Count > 0 Then
        '    TabControl1.SelectTab(TabControl1.TabPages.Count - 1)
        '    If i <> 1 Then
        '        i = i - 1
        '    End If
        'Else
        'End If
        TabControl1.Controls.Remove(TabControl1.SelectedTab)
        If TabControl1.TabPages.Count = 0 Then
            TabControl1.Visible = False
            lasttabdel = True
            PictureBox1.Visible = True
        End If


    End Sub


    Private Sub plusbtn_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plusbtn.MouseHover
        ToolTip1.SetToolTip(plusbtn, "new tab")
    End Sub

    Private Sub deletebtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles deletebtn.MouseDown
        deletebtn.BackgroundImage = My.Resources.delete_on_click
    End Sub
    Private Sub deletebtn_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deletebtn.MouseHover
        ToolTip1.SetToolTip(deletebtn, "delete tab")
    End Sub



    Private Sub gobtn_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gobtn.MouseHover
        ToolTip1.SetToolTip(gobtn, "go!")

    End Sub

    Private Sub backbutton_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backbtn.MouseHover
        ToolTip1.SetToolTip(backbtn, "go back")
    End Sub


    Private Sub BrowsieeIcon_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover

        ' TabControl1.Width = 1192
        ' Me.BackgroundImage = My.Resources.New_York_City_Pictures_HD_Wallpaper
        TabControl1.Visible = True
        PictureBox1.Visible = False
        Button7.Visible = True
    End Sub
    Private Sub Button7_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseHover
        'TabControl1.Width = 10
        PictureBox1.Visible = True
        PictureBox1.BackgroundImage = My.Resources.browsiee_title
        TabControl1.Visible = False
        Button7.Visible = False
    End Sub



    'Private Sub Form1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
    '    TabControl1.Visible = False
    '    Button7.Visible = False
    '    Button8.Visible = False
    'End Sub
    Public Sub Run_Me_On_Load(ByVal sender As Object, ByVal e As EventArgs)
        'MessageBox.Show("Finished loading")
        Dim page As String
        page = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).DocumentTitle
        If String.Compare(page, "Navigation Canceled") = 0 Then
            nonet.Visible = True
            Me.Text = " Error : From Browsiee - beta 1.2 copyrights prashanth kondedath"
            TabControl1.SelectedTab.Text = "Error: Try Connection"
        ElseIf String.Compare(page, "Internet Explorer cannot display the webpage") = 0 Then
            nonet.Visible = True
            Me.Text = " Error : From Browsiee - beta 1.2 copyrights prashanth kondedath"
            TabControl1.SelectedTab.Text = "Error: Try Connection"
        Else
            nonet.Visible = False
            Me.Text = page & " : From Browsiee - beta 1.2 copyrights prashanth kondedath"
            TabControl1.SelectedTab.Text = page
        End If
        TextBox1.Text = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Url.ToString
        'knowbtn.Location = New Point(758, 637)
    End Sub

    Public Sub Run_on_webBrowserProgress_Change(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs)

        '   Dim x As Integer = 0
        If e.MaximumProgress <> 0 And e.MaximumProgress >= e.CurrentProgress Then
            ProgressBar1.Value = Convert.ToInt32(100 * e.CurrentProgress / e.MaximumProgress)
            '    x = Convert.ToInt32(50 * e.CurrentProgress / e.MaximumProgress)
            '    x = x + knowbtn.Location.X
            '   knowbtn.Location = New Point(x, 637)

        Else
            With ProgressBar1
                .Value = 100
                .Visible = True
            End With
        End If

    End Sub
    Public Sub Run_on_navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventHandler)


    End Sub
    Private Sub BrowserNewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim myElement As HtmlElement = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Document.ActiveElement

        ' FirstTime = False
        WebB = CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser)
        Dim target As String = myElement.GetAttribute("href")

        Dim newInstance As New Form3
        newInstance.Show()
        newInstance.WebBrowser1.ScriptErrorsSuppressed = True
        newInstance.WebBrowser1.Navigate(target)


        e.Cancel = True
    End Sub



    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        TabControl1.Visible = True
        PictureBox1.Visible = False
        Button7.Visible = True

    End Sub

    Private Sub plusbtn_mousedown(ByVal sender As Object, ByVal e As System.EventArgs) Handles plusbtn.MouseDown
        plusbtn.BackgroundImage = My.Resources.add_on_click

    End Sub
    Private Sub plusbtn_mouseup(ByVal sender As Object, ByVal e As System.EventArgs) Handles plusbtn.MouseUp
        plusbtn.BackgroundImage = My.Resources.addtab_click

    End Sub

    Private Sub plusbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plusbtn.Click
        Try
            Dim tab As New TabPage
            Dim brws As New WebBrowser
            AddHandler brws.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf Run_Me_On_Load)
            AddHandler brws.ProgressChanged, New WebBrowserProgressChangedEventHandler(AddressOf Run_on_webBrowserProgress_Change)
            AddHandler brws.NewWindow, AddressOf BrowserNewWindow
            brws.Dock = DockStyle.Fill
            tab.Text = "loading.."
            tab.Controls.Add(brws)
            Me.TabControl1.TabPages.Add(tab)
            Me.TabControl1.SelectedTab = tab
            brws.ScriptErrorsSuppressed = True
            brws.Navigate("www.google.com")
            tab.Text = brws.Url.Host

        Catch ex As Exception

        End Try
    End Sub

    Private Sub settingbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles settingbtn.Click
        Form2.Show()
        Me.BackgroundImage = My.Resources.New_York_City_Pictures_HD_Wallpaper
    End Sub

    Private Sub settingbtn_mousedown(ByVal sender As Object, ByVal e As System.EventArgs) Handles settingbtn.MouseDown
        settingbtn.BackgroundImage = My.Resources.setting
    End Sub
    Private Sub settingbtn_mouseup(ByVal sender As Object, ByVal e As System.EventArgs) Handles settingbtn.MouseUp
        settingbtn.BackgroundImage = My.Resources.settings_button_click
    End Sub

    Private Sub gobtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gobtn.Click
        Try
            If TabControl1.TabPages.Count > 0 Then
                CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(TextBox1.Text)
            Else
                AddNewtab(TextBox1.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gobtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gobtn.MouseDown
        gobtn.BackgroundImage = My.Resources.sailboat
    End Sub

    Private Sub gobtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gobtn.MouseUp
        gobtn.BackgroundImage = My.Resources.sailboat_Go_click
    End Sub

    Private Sub deletebtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles deletebtn.MouseUp
        deletebtn.BackgroundImage = My.Resources.deletetab_click
    End Sub

    Private Sub backbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles backbtn.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoBack()
    End Sub


    Private Sub backbtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles backbtn.MouseDown
        backbtn.BackgroundImage = My.Resources.windy
    End Sub

    Private Sub backbtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles backbtn.MouseUp
        backbtn.BackgroundImage = My.Resources.windy_back_btn_click
    End Sub

    Private Sub fblink_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles fblink.MouseDown
        fblink.BackgroundImage = My.Resources.facebook
    End Sub

    Private Sub fblink_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles fblink.MouseUp
        fblink.BackgroundImage = My.Resources.facebook_click2
    End Sub

    Private Sub twitterlink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles twitterlink.Click

        Dim target As String = "https://twitter.com/pkondedath"

        Dim newInstance As New Form3
        newInstance.Show()

        newInstance.WebBrowser1.ScriptErrorsSuppressed = True
        newInstance.WebBrowser1.Navigate(target)


        ' e.Cancel = True
    End Sub

    Private Sub twitterlink_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles twitterlink.MouseDown
        twitterlink.BackgroundImage = My.Resources.twitter
    End Sub

    Private Sub twitterlink_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles twitterlink.MouseHover
        ToolTip1.SetToolTip(twitterlink, "contact developer on twitter")
    End Sub

    Private Sub twitterlink_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles twitterlink.MouseUp
        twitterlink.BackgroundImage = My.Resources.twitter_click2
    End Sub

    Private Sub gplus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gplus.Click
        Dim target As String = "google.com/+PrashanthNairCoder/"

        Dim newInstance As New Form3
        newInstance.Show()
        newInstance.WebBrowser1.ScriptErrorsSuppressed = True
        newInstance.WebBrowser1.Navigate(target)

    End Sub

    Private Sub gplus_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gplus.MouseDown
        gplus.BackgroundImage = My.Resources.google
    End Sub

    Private Sub gplus_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gplus.MouseMove
        ToolTip1.SetToolTip(gplus, "contact developer on google+")
    End Sub

    Private Sub gplus_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gplus.MouseUp
        gplus.BackgroundImage = My.Resources.google_click2
    End Sub

    Private Sub linkedin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkedin.Click
        Dim target As String = "https://www.linkedin.com/pub/prashanth-kondedath"

        Dim newInstance As New Form3
        newInstance.Show()
        newInstance.WebBrowser1.ScriptErrorsSuppressed = True
        newInstance.WebBrowser1.Navigate(target)
    End Sub

    Private Sub linkedin_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles linkedin.MouseDown
        linkedin.BackgroundImage = My.Resources.linkdin
    End Sub

    Private Sub linkedin_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkedin.MouseHover
        ToolTip1.SetToolTip(linkedin, "contact developer on linkedin")
    End Sub

    Private Sub linkedin_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles linkedin.MouseUp
        linkedin.BackgroundImage = My.Resources.linkdin_click2
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub nonet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles nonet.Click
        nonet.Visible = False
    End Sub

    Private Sub knowbtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles knowbtn.MouseDown
        knowbtn.BackgroundImage = My.Resources.browsiee_title
    End Sub

    Private Sub knowbtn_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles knowbtn.MouseHover
        ToolTip1.SetToolTip(knowbtn, "Know about Browsiee")
    End Sub

    Private Sub knowbtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles knowbtn.MouseUp
        knowbtn.BackgroundImage = My.Resources.browsiee_title_click
    End Sub

    Private Sub knowbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles knowbtn.Click
        'about.Show()
        Dim mypic As New FlickrNet.Photo
        Dim filname As String
        Dim flickr As New Flickr("69f89bdd1acde0be4b30e1c3a951040a", "6565fcc2c8649625")

        ' Get 100 most recent pictures with the tag "Hawaii"
        Dim options As New PhotoSearchOptions()
        'Me.BackgroundImage = My.Resources.New_York_City_Pictures_HD_Wallpaper

        options.PerPage = 10
        'options.Tags = "tajmahal"
        options.Tags = TextBox2.Text




        options.Extras = PhotoSearchExtras.OriginalFormat
        ' options.Extras = PhotoSearchExtras.Large2048Url
        '  options.ExifMinExposure = 2000
        '  options.PrivacyFilter = PrivacyFilter.PublicPhotos
        '  options.SafeSearch = SafetyLevel.Moderate
        ' options.ExifMinExposure = 2000

        Dim searchResults As PhotoCollection = flickr.PhotosSearch(options)

        mypic = searchResults.First
        Label2.Text = mypic.Description
        ' Dim myindex As Integer
        'While IsNothing(mypic.OriginalUrl) And Not myindex.Equals(options.PerPage)
        '    mypic = searchResults.ElementAtOrDefault(myindex)
        '    myindex = myindex + 1
        'End While

        ' PictureBox2.ImageLocation = FlickrNet.ge
        '  PictureBox1.Image.
        'PictureBox2.ImageLocation = mypic.OriginalUrl
        Me.BackgroundImage = My.Resources.New_York_City_Pictures_HD_Wallpaper
        If Not firstload Then
            Me.BackgroundImage.Dispose()

        End If
        firstload = False
        If System.IO.File.Exists("D:\Image for browser\bg\image.jpg") = True Then
            System.IO.File.Delete("D:\Image for browser\bg\image.jpg")
            '    MsgBox("File Deleted")
        End If
        If Not String.Compare(mypic.LargeUrl, "") Then
            My.Computer.Network.DownloadFile(mypic.LargeUrl, "D:\Image for browser\bg\image.jpg")
            '    TextBox2.Text = "orig - " & mypic.LargeUrl
        End If
        If Not mypic.Title = "" Then
            Label2.Text = mypic.Title
            If Not mypic.Description = "" Then
                Label2.Text = Label2.Text & " :" & mypic.Description
            End If
            If Not mypic.OwnerName = "" Then
                Label2.Text = Label2.Text & " by " & mypic.OwnerName
            End If
        End If
        Me.BackgroundImage = Image.FromFile("D:\Image for browser\bg\image.jpg")
        TextBox2.Text = mypic.Description
        '  flickr.

        'Me.BackgroundImage = My.Resources.No_net_connection

        'PictureBox2.Image = My.Resources.New_York_City_Pictures_HD_Wallpaper

        ' PictureBox2.SizeMode = PictureBoxSizeMode.AutoSize
        ' PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        'PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage


        '   PictureBox2.RectangleToScreen()
        '    TextBox2.Text = mypic.OriginalUrl



    End Sub

    Private Sub TextBox2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.MouseHover
        ToolTip1.SetToolTip(TextBox2, "type a tag you need, we'll try to load best background<under developement- error prone>")
    End Sub
End Class

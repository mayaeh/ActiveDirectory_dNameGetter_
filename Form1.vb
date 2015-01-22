Public Class Form1

    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        ' タイトルバーを消す
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None


        ' ディスプレイサイズを取得し、ウインドウの表示位置を右下に設定する
        Dim screenH, screenW As Integer
        screenH = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        screenW = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width

        Me.Location = New Point(screenW - My.Settings.MarginRight, screenH - My.Settings.MarginBottom)

        ' ウインドウサイズを変更する
        Me.Size = New Size(My.Settings.FormWidth, My.Settings.FormHeight)


        ' フォントと背景色を変更する
        Me.Label1.Font = New Font(My.Settings.FontName, My.Settings.FontSize)
        Me.Label1.ForeColor = Color.FromName(My.Settings.FontColor)

        Me.Label2.Font = New Font(My.Settings.FontName, My.Settings.FontSize)
        Me.Label2.ForeColor = Color.FromName(My.Settings.FontColor)

        ' 右クリックメニューのフォントを変更する
        Me.ContextMenuStrip1.Font = New Font(My.Settings.MenuFontName, My.Settings.MenuFontSize)

        Me.BackColor = Color.FromName(My.Settings.BackgroundColor)

        ' もしラベル１を非表示にする設定なら非表示にする
        If My.Settings.ShowLabel1 = False Then
            Me.Label1.Visible = False
            Me.Label2.Left = 10
        End If


        ' ##### ユーザー名・ドメイン名を取得し DirectoryService に問い合わせ、フルネームを取得する #####

        Dim uName As String = Environment.UserName
        Dim domain As String = Environment.UserDomainName

        ' ユーザー名 / ドメイン名 を出力
        'Me.Label2.Text = uName & " / " & domain

        Dim path As String = "WinNT://" & domain & "/" & uName

        Dim dirEnt As System.DirectoryServices.DirectoryEntry = New System.DirectoryServices.DirectoryEntry(path)

        Dim dName As String = dirEnt.Properties("FullName").Value.ToString()

        ' 空欄の場合はユーザー名を表示する
        If dName = "" Then
            Me.Label2.Text = uName

        Else
            Me.Label2.Text = dName
        End If


    End Sub




    ' 終了ボタン
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    ' 情報ボタン
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        AboutBox1.Show()
    End Sub


    ' ##### タイトルバーのないウインドウでもドラッグ可能にする #####

    ' マウスのクリック位置を記憶
    Private mousePoint As Point

    ' Form1 の MouseDown イベントハンドラ
    Private Sub Form1_MouseDown(ByVal ByValsender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            ' 位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If
    End Sub

    ' Form1 の MouseMove イベントハンドラ
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Location = New Point( _
                Me.Location.X + e.X - mousePoint.X, _
                Me.Location.Y + e.Y - mousePoint.Y)

        End If
    End Sub



    ' タスクトレイのアイコンをクリック・ダブルクリックした時も右クリックのメニューを表示させる
    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Me.ContextMenuStrip1.Show(System.Windows.Forms.Cursor.Position)
    End Sub

    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        Me.ContextMenuStrip1.Show(System.Windows.Forms.Cursor.Position)
    End Sub


End Class

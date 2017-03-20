# ActiveDirectory_dNameGetter_

このアプリケーションについて

ユーザーのフルネームを取得し、デスクトップ右下に表示します。

終了させるには表示を右クリックして終了を選ぶか、タスクトレイからアイコンを右クリックし終了を選んでください。


詳細

ユーザー名・ドメイン名を取得し、Active Directory に問い合わせてフルネームを取得しています。
取得できなかった場合はユーザー名を表示しています。
フォントやウインドウサイズ、座標はアプリケーションと同じフォルダ内にある設定ファイル
 ( ActiveDirectory_fullNameGetter.exe.config ) を書き換えることで変更可能です。

色の名前は原色大辞典様ほかを参考にしてください。
http://www.colordic.org/



実行には .NetFramework 4.0 以降が必要です。
動作確認は Windows 7 x32 SP1 でしか行っていません。



謝辞

アイコンは IconArcive 様から探し使用させていただきました。
http://www.iconarchive.com/search?q=ico+files&page=1

コードの大半は DOBON.NET 様のサンプルコードを参考にさせていただきました。
http://dobon.net/

IDE は Microsoft Visual Studio 2017 RC および 
Microsoft Visual Basic 2010 Expless を使用させていただきました。

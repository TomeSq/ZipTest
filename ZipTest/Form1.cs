using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace ZipTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 圧縮元ディレクトリ指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrcRef_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            fbd.Description = "圧縮したいフォルダーを指定してください。";

            fbd.ShowNewFolderButton = false;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                textSrc.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// 圧縮先指定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDistRef_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.Filter = "Zipファイル(*.zip;)|*zip";
            sfd.Title = "保存先のファイルを指定してください。";
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textDist.Text = sfd.FileName;
            }
        }

        private int _uptoFileCount;
        private int _totalFileCount;
        private void btnCompress_Click(object sender, EventArgs e)
        {
            try
            {
                if (textSrc.Text.Length <= 0)
                {
                    MessageBox.Show("圧縮フォルダーを指定してください。");
                    return;
                }

                if (textDist.Text.Length <= 0)
                {
                    MessageBox.Show("保存先のファイルを指定してください。");
                    return;
                }

                #region Zip処理イベント関係
                FastZipEvents fastZipEvents = new FastZipEvents();
                fastZipEvents.ProcessFile = new ICSharpCode.SharpZipLib.Core.ProcessFileHandler(ProcessFile); // 1つの圧縮展開を始める前に呼び出される
                fastZipEvents.Progress = new ICSharpCode.SharpZipLib.Core.ProgressHandler(Progress); // 1つの進捗
                fastZipEvents.CompletedFile = new ICSharpCode.SharpZipLib.Core.CompletedFileHandler(CompletedFile); // 完了イベント
                fastZipEvents.ProcessDirectory = new ICSharpCode.SharpZipLib.Core.ProcessDirectoryHandler(ProcessDirectory); // １つのフォルダを作成したときに呼び出される
                fastZipEvents.FileFailure = new ICSharpCode.SharpZipLib.Core.FileFailureHandler(FileFailure); // 圧縮展開に失敗した場合
                fastZipEvents.DirectoryFailure = new ICSharpCode.SharpZipLib.Core.DirectoryFailureHandler(DirectoryFailure); //フォルダの圧縮・解凍に失敗したとき
                #endregion

                // プログレスバー初期化
                progressBar.Minimum = 0;
                progressBar.Maximum = 100;
                progressBar.Value = 0;
                _uptoFileCount = 0;
                _totalFileCount = FolderContentsCount(textSrc.Text);

                FastZip fastZip = new FastZip(fastZipEvents);
                fastZip.CreateEmptyDirectories = true; // 空フォルダも圧縮
                fastZip.UseZip64 = UseZip64.Dynamic; // 必要に応じてzip64を行う
                fastZip.CreateZip(textDist.Text, textSrc.Text, true, null, null); // 再帰的に圧縮
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //1つのファイルの圧縮、展開を始める時
        private void ProcessFile(Object sender, ICSharpCode.SharpZipLib.Core.ScanEventArgs e)
        {
            _uptoFileCount++;
            progressBar.Value = _uptoFileCount * 100 / _totalFileCount;
            progressBar.Update();

            labelProgress.Text = string.Format("{0}/100", progressBar.Value);
            labelProgress.Update();
        }

        //1つのファイルの圧縮、展開の進行状況
        private void Progress(Object sender, ICSharpCode.SharpZipLib.Core.ProgressEventArgs e)
        {
        }

        //1つのファイルの圧縮、展開が完了した時
        private void CompletedFile(Object sender,
            ICSharpCode.SharpZipLib.Core.ScanEventArgs e)
        {
//            Console.WriteLine("\"{0}\"の処理が完了", e.Name);
        }

        //1つのフォルダの圧縮、展開が完了した時
        private void ProcessDirectory(Object sender, ICSharpCode.SharpZipLib.Core.DirectoryEventArgs e)
        {
//            Console.WriteLine("フォルダ\"{0}\"の処理を開始", e.Name);
        }

        //ファイルの圧縮、展開でエラーが発生した時
        private void FileFailure(Object sender, ICSharpCode.SharpZipLib.Core.ScanFailureEventArgs e)
        {
//            Console.WriteLine("\"{0}\"の処理中にエラー({1})が発生", e.Name, e.Exception.Message);

            //e.ContinueRunning = false;
            //とすると、以降の処理をキャンセル
        }

        //フォルダの圧縮、展開でエラーが発生した時
        private void DirectoryFailure(Object sender,
            ICSharpCode.SharpZipLib.Core.ScanFailureEventArgs e)
        {
//            Console.WriteLine("フォルダ\"{0}\"の処理中にエラー({1})が発生", e.Name, e.Exception.Message);
        }

        /// <summary>
        /// フォルダー配下のファイル数をカウントする
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private int FolderContentsCount(string path)
        {
            int result = Directory.GetFiles(path).Length;
            string[] subFolders = Directory.GetDirectories(path);
            foreach (string subFolder in subFolders)
            {
                result += FolderContentsCount(subFolder);
            }
            return result;
        }
    }
}

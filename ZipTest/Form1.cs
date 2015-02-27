using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            }
        }
    }
}

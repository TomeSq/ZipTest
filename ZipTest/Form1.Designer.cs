namespace ZipTest
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textSrc = new System.Windows.Forms.TextBox();
            this.btnSrcRef = new System.Windows.Forms.Button();
            this.btnDistRef = new System.Windows.Forms.Button();
            this.textDist = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.btnCompress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "フォルダー指定";
            // 
            // textSrc
            // 
            this.textSrc.Location = new System.Drawing.Point(15, 20);
            this.textSrc.Name = "textSrc";
            this.textSrc.Size = new System.Drawing.Size(416, 19);
            this.textSrc.TabIndex = 1;
            // 
            // btnSrcRef
            // 
            this.btnSrcRef.Location = new System.Drawing.Point(437, 18);
            this.btnSrcRef.Name = "btnSrcRef";
            this.btnSrcRef.Size = new System.Drawing.Size(75, 23);
            this.btnSrcRef.TabIndex = 2;
            this.btnSrcRef.Text = "参照";
            this.btnSrcRef.UseVisualStyleBackColor = true;
            this.btnSrcRef.Click += new System.EventHandler(this.btnSrcRef_Click);
            // 
            // btnDistRef
            // 
            this.btnDistRef.Location = new System.Drawing.Point(437, 97);
            this.btnDistRef.Name = "btnDistRef";
            this.btnDistRef.Size = new System.Drawing.Size(75, 23);
            this.btnDistRef.TabIndex = 5;
            this.btnDistRef.Text = "参照";
            this.btnDistRef.UseVisualStyleBackColor = true;
            this.btnDistRef.Click += new System.EventHandler(this.btnDistRef_Click);
            // 
            // textDist
            // 
            this.textDist.Location = new System.Drawing.Point(15, 99);
            this.textDist.Name = "textDist";
            this.textDist.Size = new System.Drawing.Size(416, 19);
            this.textDist.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "出力先";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 202);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(497, 23);
            this.progressBar.TabIndex = 6;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(13, 187);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(29, 12);
            this.labelProgress.TabIndex = 3;
            this.labelProgress.Text = "進捗";
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(437, 139);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(75, 23);
            this.btnCompress.TabIndex = 7;
            this.btnCompress.Text = "圧縮！";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 335);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnDistRef);
            this.Controls.Add(this.textDist);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSrcRef);
            this.Controls.Add(this.textSrc);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textSrc;
        private System.Windows.Forms.Button btnSrcRef;
        private System.Windows.Forms.Button btnDistRef;
        private System.Windows.Forms.TextBox textDist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Button btnCompress;
    }
}


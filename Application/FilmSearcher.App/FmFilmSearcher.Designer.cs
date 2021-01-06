
namespace FilmSearcher.App
{
    partial class fmDistributorSearcher
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtKeyword = new System.Windows.Forms.TextBox();
            this.ListBoxFilm = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // TxtKeyword
            // 
            this.TxtKeyword.Font = new System.Drawing.Font("新細明體", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TxtKeyword.Location = new System.Drawing.Point(12, 12);
            this.TxtKeyword.Name = "TxtKeyword";
            this.TxtKeyword.Size = new System.Drawing.Size(163, 55);
            this.TxtKeyword.TabIndex = 0;
            this.TxtKeyword.TextChanged += new System.EventHandler(this.TxtKeyword_TextChanged);
            // 
            // ListBoxFilm
            // 
            this.ListBoxFilm.Font = new System.Drawing.Font("新細明體", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ListBoxFilm.FormattingEnabled = true;
            this.ListBoxFilm.ItemHeight = 29;
            this.ListBoxFilm.Location = new System.Drawing.Point(12, 73);
            this.ListBoxFilm.Name = "ListBoxFilm";
            this.ListBoxFilm.Size = new System.Drawing.Size(713, 352);
            this.ListBoxFilm.TabIndex = 2;
            this.ListBoxFilm.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // fmDistributorSearcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 452);
            this.Controls.Add(this.ListBoxFilm);
            this.Controls.Add(this.TxtKeyword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "fmDistributorSearcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "影片商搜尋器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtKeyword;
        private System.Windows.Forms.ListBox ListBoxFilm;
    }
}


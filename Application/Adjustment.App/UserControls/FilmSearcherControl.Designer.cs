
namespace Adjustment.App.UserControls
{
    partial class FilmSearcherControl
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabTotal = new System.Windows.Forms.Label();
            this.TxtKeyword = new System.Windows.Forms.TextBox();
            this.ListBoxFilm = new System.Windows.Forms.ListBox();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LabTotal, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TxtKeyword, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ListBoxFilm, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxHistory, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.07407F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.92593F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 653);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LabTotal
            // 
            this.LabTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LabTotal.AutoSize = true;
            this.LabTotal.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LabTotal.Location = new System.Drawing.Point(3, 476);
            this.LabTotal.Name = "LabTotal";
            this.LabTotal.Size = new System.Drawing.Size(55, 32);
            this.LabTotal.TabIndex = 4;
            this.LabTotal.Text = "Total: 0";
            this.LabTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtKeyword
            // 
            this.TxtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtKeyword.Font = new System.Drawing.Font("新細明體", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TxtKeyword.Location = new System.Drawing.Point(3, 3);
            this.TxtKeyword.Name = "TxtKeyword";
            this.TxtKeyword.Size = new System.Drawing.Size(265, 55);
            this.TxtKeyword.TabIndex = 1;
            this.TxtKeyword.TextChanged += new System.EventHandler(this.TxtKeyword_TextChanged);
            // 
            // ListBoxFilm
            // 
            this.ListBoxFilm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxFilm.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ListBoxFilm.FormattingEnabled = true;
            this.ListBoxFilm.HorizontalScrollbar = true;
            this.ListBoxFilm.ItemHeight = 16;
            this.ListBoxFilm.Location = new System.Drawing.Point(3, 68);
            this.ListBoxFilm.Name = "ListBoxFilm";
            this.ListBoxFilm.Size = new System.Drawing.Size(719, 405);
            this.ListBoxFilm.TabIndex = 3;
            this.ListBoxFilm.DoubleClick += new System.EventHandler(this.ListBoxFilm_DoubleClick);
            // 
            // listBoxHistory
            // 
            this.listBoxHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHistory.FormattingEnabled = true;
            this.listBoxHistory.Location = new System.Drawing.Point(3, 511);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(719, 139);
            this.listBoxHistory.TabIndex = 5;
            // 
            // FilmSearcherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FilmSearcherControl";
            this.Size = new System.Drawing.Size(725, 653);
            this.Load += new System.EventHandler(this.FilmSearcherControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtKeyword;
        private System.Windows.Forms.ListBox ListBoxFilm;
        private System.Windows.Forms.Label LabTotal;
        private System.Windows.Forms.ListBox listBoxHistory;
    }
}

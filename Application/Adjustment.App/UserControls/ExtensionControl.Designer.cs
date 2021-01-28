
namespace Adjustment.App.UserControls
{
    partial class ExtensionControl
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
            this.OneLeftToRightButton = new System.Windows.Forms.Button();
            this.AllLeftToRightButton = new System.Windows.Forms.Button();
            this.AllRightToLeftButton = new System.Windows.Forms.Button();
            this.OneRightToLeftButton = new System.Windows.Forms.Button();
            this.FilmExtensionListBox = new System.Windows.Forms.ListBox();
            this.OtherExtensionListBox = new System.Windows.Forms.ListBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.OneLeftToRightButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.AllLeftToRightButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.AllRightToLeftButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.OneRightToLeftButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.FilmExtensionListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.OtherExtensionListBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ExportButton, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(651, 528);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // OneLeftToRightButton
            // 
            this.OneLeftToRightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OneLeftToRightButton.Location = new System.Drawing.Point(253, 192);
            this.OneLeftToRightButton.Name = "OneLeftToRightButton";
            this.OneLeftToRightButton.Size = new System.Drawing.Size(144, 23);
            this.OneLeftToRightButton.TabIndex = 0;
            this.OneLeftToRightButton.Text = "＞";
            this.OneLeftToRightButton.UseVisualStyleBackColor = true;
            this.OneLeftToRightButton.Click += new System.EventHandler(this.OneLeftToRightButton_Click);
            // 
            // AllLeftToRightButton
            // 
            this.AllLeftToRightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AllLeftToRightButton.Location = new System.Drawing.Point(253, 232);
            this.AllLeftToRightButton.Name = "AllLeftToRightButton";
            this.AllLeftToRightButton.Size = new System.Drawing.Size(144, 23);
            this.AllLeftToRightButton.TabIndex = 1;
            this.AllLeftToRightButton.Text = "＞＞";
            this.AllLeftToRightButton.UseVisualStyleBackColor = true;
            this.AllLeftToRightButton.Click += new System.EventHandler(this.AllLeftToRightButton_Click);
            // 
            // AllRightToLeftButton
            // 
            this.AllRightToLeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AllRightToLeftButton.Location = new System.Drawing.Point(253, 272);
            this.AllRightToLeftButton.Name = "AllRightToLeftButton";
            this.AllRightToLeftButton.Size = new System.Drawing.Size(144, 23);
            this.AllRightToLeftButton.TabIndex = 2;
            this.AllRightToLeftButton.Text = "＜＜";
            this.AllRightToLeftButton.UseVisualStyleBackColor = true;
            this.AllRightToLeftButton.Click += new System.EventHandler(this.AllRightToLeftButton_Click);
            // 
            // OneRightToLeftButton
            // 
            this.OneRightToLeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.OneRightToLeftButton.Location = new System.Drawing.Point(253, 312);
            this.OneRightToLeftButton.Name = "OneRightToLeftButton";
            this.OneRightToLeftButton.Size = new System.Drawing.Size(144, 23);
            this.OneRightToLeftButton.TabIndex = 3;
            this.OneRightToLeftButton.Text = "＜";
            this.OneRightToLeftButton.UseVisualStyleBackColor = true;
            this.OneRightToLeftButton.Click += new System.EventHandler(this.OneRightToLeftButton_Click);
            // 
            // FilmExtensionListBox
            // 
            this.FilmExtensionListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilmExtensionListBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FilmExtensionListBox.FormattingEnabled = true;
            this.FilmExtensionListBox.HorizontalScrollbar = true;
            this.FilmExtensionListBox.ItemHeight = 16;
            this.FilmExtensionListBox.Location = new System.Drawing.Point(3, 3);
            this.FilmExtensionListBox.Name = "FilmExtensionListBox";
            this.tableLayoutPanel1.SetRowSpan(this.FilmExtensionListBox, 6);
            this.FilmExtensionListBox.Size = new System.Drawing.Size(244, 522);
            this.FilmExtensionListBox.TabIndex = 4;
            // 
            // OtherExtensionListBox
            // 
            this.OtherExtensionListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OtherExtensionListBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OtherExtensionListBox.FormattingEnabled = true;
            this.OtherExtensionListBox.HorizontalScrollbar = true;
            this.OtherExtensionListBox.ItemHeight = 16;
            this.OtherExtensionListBox.Location = new System.Drawing.Point(403, 3);
            this.OtherExtensionListBox.Name = "OtherExtensionListBox";
            this.tableLayoutPanel1.SetRowSpan(this.OtherExtensionListBox, 6);
            this.OtherExtensionListBox.Size = new System.Drawing.Size(245, 522);
            this.OtherExtensionListBox.TabIndex = 5;
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ExportButton.Location = new System.Drawing.Point(287, 502);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 6;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ExtensionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExtensionControl";
            this.Size = new System.Drawing.Size(651, 528);
            this.Load += new System.EventHandler(this.ExtensionControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button OneLeftToRightButton;
        private System.Windows.Forms.Button AllLeftToRightButton;
        private System.Windows.Forms.Button AllRightToLeftButton;
        private System.Windows.Forms.Button OneRightToLeftButton;
        private System.Windows.Forms.ListBox FilmExtensionListBox;
        private System.Windows.Forms.ListBox OtherExtensionListBox;
        private System.Windows.Forms.Button ExportButton;
    }
}

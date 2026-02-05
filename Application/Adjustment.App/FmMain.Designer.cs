
namespace Adjustment.App
{
    partial class FmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPageDefineSetting = new System.Windows.Forms.TabPage();
            TlDefineSetting = new System.Windows.Forms.TableLayoutPanel();
            tabPageEmptyDirs = new System.Windows.Forms.TabPage();
            tabPageExtension = new System.Windows.Forms.TabPage();
            button1 = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageDefineSetting.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 0);
            tableLayoutPanel1.Controls.Add(button1, 1, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1426, 850);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            tableLayoutPanel1.SetColumnSpan(tabControl1, 2);
            tabControl1.Controls.Add(tabPageDefineSetting);
            tabControl1.Controls.Add(tabPageEmptyDirs);
            tabControl1.Controls.Add(tabPageExtension);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(4, 5);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1418, 792);
            tabControl1.TabIndex = 1;
            // 
            // tabPageDefineSetting
            // 
            tabPageDefineSetting.Controls.Add(TlDefineSetting);
            tabPageDefineSetting.Location = new System.Drawing.Point(4, 28);
            tabPageDefineSetting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageDefineSetting.Name = "tabPageDefineSetting";
            tabPageDefineSetting.Size = new System.Drawing.Size(1410, 760);
            tabPageDefineSetting.TabIndex = 3;
            tabPageDefineSetting.Text = "Category Define";
            tabPageDefineSetting.UseVisualStyleBackColor = true;
            // 
            // TlDefineSetting
            // 
            TlDefineSetting.ColumnCount = 2;
            TlDefineSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TlDefineSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            TlDefineSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            TlDefineSetting.Location = new System.Drawing.Point(0, 0);
            TlDefineSetting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            TlDefineSetting.Name = "TlDefineSetting";
            TlDefineSetting.RowCount = 2;
            TlDefineSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.4444427F));
            TlDefineSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.5555573F));
            TlDefineSetting.Size = new System.Drawing.Size(1410, 760);
            TlDefineSetting.TabIndex = 1;
            // 
            // tabPageEmptyDirs
            // 
            tabPageEmptyDirs.Location = new System.Drawing.Point(4, 28);
            tabPageEmptyDirs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageEmptyDirs.Name = "tabPageEmptyDirs";
            tabPageEmptyDirs.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageEmptyDirs.Size = new System.Drawing.Size(1410, 760);
            tabPageEmptyDirs.TabIndex = 0;
            tabPageEmptyDirs.Text = "EmptyDirs";
            tabPageEmptyDirs.UseVisualStyleBackColor = true;
            // 
            // tabPageExtension
            // 
            tabPageExtension.Location = new System.Drawing.Point(4, 28);
            tabPageExtension.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageExtension.Name = "tabPageExtension";
            tabPageExtension.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            tabPageExtension.Size = new System.Drawing.Size(1410, 760);
            tabPageExtension.TabIndex = 1;
            tabPageExtension.Text = "Extensions";
            tabPageExtension.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(1310, 808);
            button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(112, 36);
            button1.TabIndex = 2;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1426, 850);
            Controls.Add(tableLayoutPanel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "FmMain";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Gatchan";
            Load += FmMain_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageDefineSetting.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDefineSetting;
        private System.Windows.Forms.TableLayoutPanel TlDefineSetting;
        private System.Windows.Forms.TabPage tabPageEmptyDirs;
        private System.Windows.Forms.TabPage tabPageExtension;
        private System.Windows.Forms.Button button1;
    }
}


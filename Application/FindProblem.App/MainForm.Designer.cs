
namespace FindProblem.App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RuleListBox = new System.Windows.Forms.ListBox();
            this.DetailListBox = new System.Windows.Forms.ListBox();
            this.SuggestionListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.RuleListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DetailListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SuggestionListBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1150, 719);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RuleListBox
            // 
            this.RuleListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RuleListBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RuleListBox.FormattingEnabled = true;
            this.RuleListBox.ItemHeight = 16;
            this.RuleListBox.Location = new System.Drawing.Point(3, 3);
            this.RuleListBox.Name = "RuleListBox";
            this.RuleListBox.Size = new System.Drawing.Size(569, 144);
            this.RuleListBox.TabIndex = 0;
            // 
            // DetailListBox
            // 
            this.DetailListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailListBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DetailListBox.FormattingEnabled = true;
            this.DetailListBox.HorizontalScrollbar = true;
            this.DetailListBox.ItemHeight = 16;
            this.DetailListBox.Location = new System.Drawing.Point(3, 153);
            this.DetailListBox.Name = "DetailListBox";
            this.DetailListBox.Size = new System.Drawing.Size(569, 563);
            this.DetailListBox.TabIndex = 1;
            // 
            // SuggestionListBox
            // 
            this.SuggestionListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuggestionListBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SuggestionListBox.FormattingEnabled = true;
            this.SuggestionListBox.ItemHeight = 16;
            this.SuggestionListBox.Location = new System.Drawing.Point(578, 153);
            this.SuggestionListBox.Name = "SuggestionListBox";
            this.SuggestionListBox.Size = new System.Drawing.Size(569, 563);
            this.SuggestionListBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 719);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "尋找有問題的影片";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox RuleListBox;
        private System.Windows.Forms.ListBox DetailListBox;
        private System.Windows.Forms.ListBox SuggestionListBox;
    }
}


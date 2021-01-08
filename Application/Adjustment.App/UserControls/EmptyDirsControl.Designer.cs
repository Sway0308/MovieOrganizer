
namespace Adjustment.App.UserControls
{
    partial class EmptyDirsControl
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
            this.EmptyDirListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // EmptyDirListBox
            // 
            this.EmptyDirListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmptyDirListBox.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EmptyDirListBox.FormattingEnabled = true;
            this.EmptyDirListBox.HorizontalScrollbar = true;
            this.EmptyDirListBox.ItemHeight = 16;
            this.EmptyDirListBox.Location = new System.Drawing.Point(0, 0);
            this.EmptyDirListBox.Name = "EmptyDirListBox";
            this.EmptyDirListBox.Size = new System.Drawing.Size(555, 501);
            this.EmptyDirListBox.TabIndex = 0;
            this.EmptyDirListBox.DoubleClick += new System.EventHandler(this.EmptyDirListBox_DoubleClick);
            // 
            // EmptyDirsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EmptyDirListBox);
            this.Name = "EmptyDirsControl";
            this.Size = new System.Drawing.Size(555, 501);
            this.Load += new System.EventHandler(this.EmptyDirsControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox EmptyDirListBox;
    }
}

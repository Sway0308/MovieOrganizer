
namespace Adjustment.App.UserControls
{
    partial class ClassificationDefineControl
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
            this.TxtActor = new System.Windows.Forms.TextBox();
            this.TxtGenre = new System.Windows.Forms.TextBox();
            this.LbDistributor = new System.Windows.Forms.ListBox();
            this.LbGenre = new System.Windows.Forms.ListBox();
            this.LbActor = new System.Windows.Forms.ListBox();
            this.BtnAddDistributor = new System.Windows.Forms.Button();
            this.TxtDistributor = new System.Windows.Forms.TextBox();
            this.BtnDelDistributor = new System.Windows.Forms.Button();
            this.BtnAddGenre = new System.Windows.Forms.Button();
            this.BtnDelGenre = new System.Windows.Forms.Button();
            this.BtnAddActor = new System.Windows.Forms.Button();
            this.BtnDelActor = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Controls.Add(this.TxtActor, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtGenre, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.LbDistributor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LbGenre, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.LbActor, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnAddDistributor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TxtDistributor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnDelDistributor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BtnAddGenre, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnDelGenre, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.BtnAddActor, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnDelActor, 5, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(837, 580);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtActor
            // 
            this.TxtActor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtActor.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TxtActor.Location = new System.Drawing.Point(557, 532);
            this.TxtActor.Name = "TxtActor";
            this.tableLayoutPanel1.SetRowSpan(this.TxtActor, 2);
            this.TxtActor.Size = new System.Drawing.Size(221, 36);
            this.TxtActor.TabIndex = 8;
            // 
            // TxtGenre
            // 
            this.TxtGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtGenre.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TxtGenre.Location = new System.Drawing.Point(280, 532);
            this.TxtGenre.Name = "TxtGenre";
            this.tableLayoutPanel1.SetRowSpan(this.TxtGenre, 2);
            this.TxtGenre.Size = new System.Drawing.Size(221, 36);
            this.TxtGenre.TabIndex = 7;
            // 
            // LbDistributor
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.LbDistributor, 2);
            this.LbDistributor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbDistributor.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbDistributor.FormattingEnabled = true;
            this.LbDistributor.HorizontalScrollbar = true;
            this.LbDistributor.ItemHeight = 16;
            this.LbDistributor.Location = new System.Drawing.Point(3, 3);
            this.LbDistributor.Name = "LbDistributor";
            this.LbDistributor.Size = new System.Drawing.Size(271, 514);
            this.LbDistributor.TabIndex = 0;
            // 
            // LbGenre
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.LbGenre, 2);
            this.LbGenre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbGenre.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbGenre.FormattingEnabled = true;
            this.LbGenre.HorizontalScrollbar = true;
            this.LbGenre.ItemHeight = 16;
            this.LbGenre.Location = new System.Drawing.Point(280, 3);
            this.LbGenre.Name = "LbGenre";
            this.LbGenre.Size = new System.Drawing.Size(271, 514);
            this.LbGenre.TabIndex = 1;
            // 
            // LbActor
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.LbActor, 2);
            this.LbActor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbActor.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LbActor.FormattingEnabled = true;
            this.LbActor.HorizontalScrollbar = true;
            this.LbActor.ItemHeight = 16;
            this.LbActor.Location = new System.Drawing.Point(557, 3);
            this.LbActor.Name = "LbActor";
            this.LbActor.Size = new System.Drawing.Size(277, 514);
            this.LbActor.TabIndex = 2;
            // 
            // BtnAddDistributor
            // 
            this.BtnAddDistributor.Location = new System.Drawing.Point(230, 523);
            this.BtnAddDistributor.Name = "BtnAddDistributor";
            this.BtnAddDistributor.Size = new System.Drawing.Size(44, 23);
            this.BtnAddDistributor.TabIndex = 6;
            this.BtnAddDistributor.Text = "＋";
            this.BtnAddDistributor.UseVisualStyleBackColor = true;
            // 
            // TxtDistributor
            // 
            this.TxtDistributor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDistributor.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TxtDistributor.Location = new System.Drawing.Point(3, 532);
            this.TxtDistributor.Name = "TxtDistributor";
            this.tableLayoutPanel1.SetRowSpan(this.TxtDistributor, 2);
            this.TxtDistributor.Size = new System.Drawing.Size(221, 36);
            this.TxtDistributor.TabIndex = 3;
            // 
            // BtnDelDistributor
            // 
            this.BtnDelDistributor.Location = new System.Drawing.Point(230, 553);
            this.BtnDelDistributor.Name = "BtnDelDistributor";
            this.BtnDelDistributor.Size = new System.Drawing.Size(44, 23);
            this.BtnDelDistributor.TabIndex = 9;
            this.BtnDelDistributor.Text = "－";
            this.BtnDelDistributor.UseVisualStyleBackColor = true;
            // 
            // BtnAddGenre
            // 
            this.BtnAddGenre.Location = new System.Drawing.Point(507, 523);
            this.BtnAddGenre.Name = "BtnAddGenre";
            this.BtnAddGenre.Size = new System.Drawing.Size(44, 23);
            this.BtnAddGenre.TabIndex = 10;
            this.BtnAddGenre.Text = "＋";
            this.BtnAddGenre.UseVisualStyleBackColor = true;
            // 
            // BtnDelGenre
            // 
            this.BtnDelGenre.Location = new System.Drawing.Point(507, 553);
            this.BtnDelGenre.Name = "BtnDelGenre";
            this.BtnDelGenre.Size = new System.Drawing.Size(44, 23);
            this.BtnDelGenre.TabIndex = 11;
            this.BtnDelGenre.Text = "－";
            this.BtnDelGenre.UseVisualStyleBackColor = true;
            // 
            // BtnAddActor
            // 
            this.BtnAddActor.Location = new System.Drawing.Point(784, 523);
            this.BtnAddActor.Name = "BtnAddActor";
            this.BtnAddActor.Size = new System.Drawing.Size(47, 23);
            this.BtnAddActor.TabIndex = 12;
            this.BtnAddActor.Text = "＋";
            this.BtnAddActor.UseVisualStyleBackColor = true;
            // 
            // BtnDelActor
            // 
            this.BtnDelActor.Location = new System.Drawing.Point(784, 553);
            this.BtnDelActor.Name = "BtnDelActor";
            this.BtnDelActor.Size = new System.Drawing.Size(47, 23);
            this.BtnDelActor.TabIndex = 13;
            this.BtnDelActor.Text = "－";
            this.BtnDelActor.UseVisualStyleBackColor = true;
            // 
            // ClassificationDefineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClassificationDefineControl";
            this.Size = new System.Drawing.Size(837, 580);
            this.Load += new System.EventHandler(this.FilmDefineControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox LbDistributor;
        private System.Windows.Forms.ListBox LbGenre;
        private System.Windows.Forms.ListBox LbActor;
        private System.Windows.Forms.Button BtnAddDistributor;
        private System.Windows.Forms.TextBox TxtDistributor;
        private System.Windows.Forms.TextBox TxtActor;
        private System.Windows.Forms.TextBox TxtGenre;
        private System.Windows.Forms.Button BtnDelDistributor;
        private System.Windows.Forms.Button BtnAddGenre;
        private System.Windows.Forms.Button BtnDelGenre;
        private System.Windows.Forms.Button BtnAddActor;
        private System.Windows.Forms.Button BtnDelActor;
    }
}

﻿
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDefineSetting = new System.Windows.Forms.TabPage();
            this.TlDefineSetting = new System.Windows.Forms.TableLayoutPanel();
            this.tabPageEmptyDirs = new System.Windows.Forms.TabPage();
            this.tabPageExtension = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageDefineSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDefineSetting);
            this.tabControl1.Controls.Add(this.tabPageEmptyDirs);
            this.tabControl1.Controls.Add(this.tabPageExtension);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1045, 729);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageDefineSetting
            // 
            this.tabPageDefineSetting.Controls.Add(this.TlDefineSetting);
            this.tabPageDefineSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageDefineSetting.Name = "tabPageDefineSetting";
            this.tabPageDefineSetting.Size = new System.Drawing.Size(1037, 703);
            this.tabPageDefineSetting.TabIndex = 3;
            this.tabPageDefineSetting.Text = "Category Define";
            this.tabPageDefineSetting.UseVisualStyleBackColor = true;
            // 
            // TlDefineSetting
            // 
            this.TlDefineSetting.ColumnCount = 2;
            this.TlDefineSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlDefineSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlDefineSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlDefineSetting.Location = new System.Drawing.Point(0, 0);
            this.TlDefineSetting.Name = "TlDefineSetting";
            this.TlDefineSetting.RowCount = 2;
            this.TlDefineSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.TlDefineSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlDefineSetting.Size = new System.Drawing.Size(1037, 703);
            this.TlDefineSetting.TabIndex = 1;
            // 
            // tabPageEmptyDirs
            // 
            this.tabPageEmptyDirs.Location = new System.Drawing.Point(4, 22);
            this.tabPageEmptyDirs.Name = "tabPageEmptyDirs";
            this.tabPageEmptyDirs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmptyDirs.Size = new System.Drawing.Size(1037, 703);
            this.tabPageEmptyDirs.TabIndex = 0;
            this.tabPageEmptyDirs.Text = "EmptyDirs";
            this.tabPageEmptyDirs.UseVisualStyleBackColor = true;
            // 
            // tabPageExtension
            // 
            this.tabPageExtension.Location = new System.Drawing.Point(4, 22);
            this.tabPageExtension.Name = "tabPageExtension";
            this.tabPageExtension.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExtension.Size = new System.Drawing.Size(1037, 703);
            this.tabPageExtension.TabIndex = 1;
            this.tabPageExtension.Text = "Extensions";
            this.tabPageExtension.UseVisualStyleBackColor = true;
            // 
            // FmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 729);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gatchan";
            this.Load += new System.EventHandler(this.FmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDefineSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageEmptyDirs;
        private System.Windows.Forms.TabPage tabPageExtension;
        private System.Windows.Forms.TabPage tabPageDefineSetting;
        private System.Windows.Forms.TableLayoutPanel TlDefineSetting;
    }
}


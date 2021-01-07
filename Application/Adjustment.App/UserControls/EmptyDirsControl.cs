﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class EmptyDirsControl : UserControl
    {
        private readonly IList<string> EmptyDirs;
        public EmptyDirsControl(IList<string> emptyDirs)
        {
            InitializeComponent();
            EmptyDirs = emptyDirs;
        }

        private void EmptyDirsControl_Load(object sender, EventArgs e)
        {
            EmptyDirListBox.DataSource = EmptyDirs;
        }

        private void EmptyDirListBox_DoubleClick(object sender, EventArgs e)
        {
            if (EmptyDirListBox.SelectedItem == null)
                return;

            Process prc = Process.GetCurrentProcess();
            prc.StartInfo.FileName = EmptyDirListBox.SelectedItem.ToString();
            prc.Start();
        }
    }
}

﻿using Adjustment.App.Interfaces;
using Category.Standard.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class EmptyDirsControl : UserControl, IInitControls
    {
        private ICatalog Catalog;
        private IReadOnlyList<string> EmptyDirs => Catalog.EmptyDirs;
        public EmptyDirsControl()
        {
            InitializeComponent();
        }

        public void InitControls(ICatalog catalog)
        {
            Catalog = catalog;
            Init();
        }

        private void Init()
        {
            EmptyDirListBox.DataSource = null;
            if (EmptyDirs?.Count == 0)
                return;
            EmptyDirListBox.DataSource = EmptyDirs;
        }

        private void EmptyDirsControl_Load(object sender, EventArgs e)
        {
            Init();
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

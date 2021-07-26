using Adjustment.App.Interfaces;
using Category.Standard.Adaptors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class EmptyDirsControl : UserControl, IInitControls
    {
        private IList<string> EmptyDirs;
        public EmptyDirsControl()
        {
            InitializeComponent();
        }

        public void InitControls(CatalogAdaptor Adaptor)
        {
            Init();
            EmptyDirs = Adaptor.EmptyDirs;
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

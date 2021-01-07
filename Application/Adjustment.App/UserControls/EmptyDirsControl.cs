using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class EmptyDirsControl : UserControl
    {
        private readonly IList<string> EmptyDirs;
        public EmptyDirsControl()
        {
            InitializeComponent();
        }

        public EmptyDirsControl(IList<string> emptyDirs) : base()
        {
            EmptyDirs = emptyDirs;
        }

        private void EmptyDirsControl_Load(object sender, EventArgs e)
        {
            if (EmptyDirs?.Count == 0)
                return;

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

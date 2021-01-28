using Category.Standard.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class ExtensionControl : UserControl
    {
        private readonly Extension Extensions;
        private readonly Action ExportAction;
        private IList<string> FilmExtensions => Extensions.FilmExtensions;
        private IList<string> OtherExtensions => Extensions.OtherExtensions;

        public ExtensionControl()
        {
            InitializeComponent();
        }

        public ExtensionControl(Extension extensions, Action exportAction) : base()
        {
            InitializeComponent();
            Extensions = extensions;

            ExportAction = exportAction;
        }

        private void AllLeftToRightButton_Click(object sender, System.EventArgs e)
        {
            AllSourceToDest(FilmExtensions, OtherExtensions);
        }

        private void AllRightToLeftButton_Click(object sender, System.EventArgs e)
        {
            AllSourceToDest(OtherExtensions, FilmExtensions);
        }

        private void AllSourceToDest(IList<string> sources, IList<string> dests)
        {
            if (sources.Count == 0)
                return;

            foreach (var item in sources)
            {
                if (dests.IndexOf(item) >= 0)
                    continue;
                dests.Add(item);
            }

            sources.Clear();
            ReloadDataSource();
        }

        private void OneLeftToRightButton_Click(object sender, System.EventArgs e)
        {
            OneSourceToDest(FilmExtensionListBox.SelectedItem as string, FilmExtensions, OtherExtensions);
        }

        private void OneRightToLeftButton_Click(object sender, System.EventArgs e)
        {
            OneSourceToDest(OtherExtensionListBox.SelectedItem as string, OtherExtensions, FilmExtensions);
        }

        private void OneSourceToDest(string item, IList<string> sources, IList<string> dests)
        {
            if (string.IsNullOrEmpty(item))
                return;

            if (dests.IndexOf(item) < 0)
                dests.Add(item);
            sources.Remove(item);
            ReloadDataSource();
        }

        private void ExtensionControl_Load(object sender, System.EventArgs e)
        {
            ReloadDataSource();
        }

        private void ReloadDataSource()
        { 
            FilmExtensionListBox.DataSource = new List<string>(FilmExtensions);
            OtherExtensionListBox.DataSource = new List<string>(OtherExtensions);
        }

        private void ExportButton_Click(object sender, System.EventArgs e)
        {
            ExportAction.Invoke();
        }
    }
}

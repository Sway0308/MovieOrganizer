using Category.Standard.Models;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class ExtensionControl : UserControl
    {
        private readonly Extension Extensions;

        public ExtensionControl(Extension extensions)
        {
            InitializeComponent();
            Extensions = extensions;
            FilmExtensionListBox.DataSource = Extensions.FilmExtensions;
            OtherExtensionListBox.DataSource = Extensions.OtherExtensions;
        }

        private void OneLeftToRightButton_Click(object sender, System.EventArgs e)
        {
            var ext = FilmExtensionListBox.SelectedItem;
            if (ext == null)
                return;

            OtherExtensionListBox.Items.Add(ext);
            FilmExtensionListBox.Items.Remove(ext);
        }

        private void AllLeftToRightButton_Click(object sender, System.EventArgs e)
        {
            if (FilmExtensionListBox.Items.Count == 0)
                return;

            OtherExtensionListBox.Items.AddRange(FilmExtensionListBox.Items);
            FilmExtensionListBox.Items.Clear();
        }

        private void AllRightToLeftButton_Click(object sender, System.EventArgs e)
        {
            if (OtherExtensionListBox.Items.Count == 0)
                return;

            FilmExtensionListBox.Items.AddRange(OtherExtensionListBox.Items);
            OtherExtensionListBox.Items.Clear();
        }

        private void OneRightToLeftButton_Click(object sender, System.EventArgs e)
        {
            var ext = OtherExtensionListBox.SelectedItem;
            if (ext == null)
                return;

            FilmExtensionListBox.Items.Add(ext);
            OtherExtensionListBox.Items.Remove(ext);
        }
    }
}

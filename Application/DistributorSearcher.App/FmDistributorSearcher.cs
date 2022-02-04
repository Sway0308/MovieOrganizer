using Category.Standard.Adaptors;
using Category.Standard.Helpers;
using Category.Standard.Interfaces;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace DistributorSearcher.App
{
    public partial class FmDistributorSearcher : Form
    {
        private readonly ICatalog Catalog;

        public FmDistributorSearcher()
        {
            InitializeComponent();
            txtCategory.Focus();

            var exportPath = ConfigurationManager.AppSettings["ExportPath"];
            Catalog = new CatalogAdaptor(exportPath);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchDistributor();
        }

        private void txtCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchDistributor();
                txtCategory.SelectAll();
            }
        }

        private void SearchDistributor()
        {
            var searchText = txtCategory.Text;
            if (string.IsNullOrEmpty(searchText))
                return;

            var result = FilmHelper.GetSuggestFilmName(Catalog, searchText);
            var cht = cbCht.Checked ? "(中文字幕)" : string.Empty;
            txtDistributor.Text = result.distributor;
            Clipboard.SetText(result.suggestName + cht);
        }

        private void txtDistributor_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Refresh?", "Refresh Catalog", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            ReCatalogAdaptor();
        }

        private void ReCatalogAdaptor()
        {
            Catalog.Init();
            txtCategory.Text = string.Empty;
            txtDistributor.Text = string.Empty;
            txtCategory.Focus();
        }
    }
}

using Category.Standard.Adaptors;
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

            var keyword = searchText;
            var dashIndex = searchText.IndexOf("-");
            if (dashIndex >= 0)
            {
                keyword = searchText.Substring(0, dashIndex);
            }

            var distributor = DoSearchDistributor(keyword);
            txtDistributor.Text = distributor;
            if (!string.IsNullOrEmpty(distributor))
            {
                if (dashIndex < 0)
                    Clipboard.SetText($"({distributor})");
                else
                {
                    var identity = searchText.Substring(0, searchText.IndexOf(" "));
                    var name = searchText.Substring(searchText.IndexOf(" ") + 1, searchText.Length - identity.Length - 1);

                    Clipboard.SetText($"({distributor})({identity}){name}");
                }
            }
        }

        private string DoSearchDistributor(string keyword)
        { 
            return Catalog.FindDistributor(keyword);
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

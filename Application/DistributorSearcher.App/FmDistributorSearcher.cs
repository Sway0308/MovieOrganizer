using Category.Standard.Adaptors;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace DistributorSearcher.App
{
    public partial class FmDistributorSearcher : Form
    {
        private readonly CatalogAdaptor Adaptor;

        public FmDistributorSearcher()
        {
            InitializeComponent();
            txtCategory.Focus();

            var exportPath = ConfigurationManager.AppSettings["ExportPath"];
            Adaptor = new CatalogAdaptor(exportPath);
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
            }
        }

        private void SearchDistributor()
        {
            var keyword = txtCategory.Text;
            if (string.IsNullOrEmpty(keyword))
                return;

            var distributor = Adaptor.FindDistributor(keyword);
            txtDistributor.Text = distributor;
            if (!string.IsNullOrEmpty(distributor))
                Clipboard.SetText(distributor);
        }
    }
}

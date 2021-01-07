using Category.Standard.Adaptors;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FilmSearcher.App
{
    public partial class fmDistributorSearcher : Form
    {
        private readonly CatalogAdaptor Adaptor;

        public fmDistributorSearcher()
        {
            InitializeComponent();
            TxtKeyword.Focus();

            var exportPath = ConfigurationManager.AppSettings["ExportPath"];
            Adaptor = new CatalogAdaptor(exportPath);
        }

        private void SearchDistributor()
        {
            var keyword = TxtKeyword.Text;
            if (string.IsNullOrEmpty(keyword))
            {
                ListBoxFilm.DataSource = null;
                return;
            }

            var films = Adaptor.FindFilms(keyword);
            ListBoxFilm.DataSource = films.Select(x => x.FilePath).ToList();
            LabTotal.Text = $"Total: {ListBoxFilm.Items.Count}";
        }

        private void TxtKeyword_TextChanged(object sender, EventArgs e)
        {
            SearchDistributor();
        }

        private void ListBoxFilm_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxFilm.SelectedItem == null)
                return;

            var filePath = ListBoxFilm.SelectedItem.ToString();
            var dirPath = Directory.GetParent(filePath);

            Process prc =  Process.GetCurrentProcess();
            prc.StartInfo.FileName = dirPath.FullName;
            prc.Start();
        }
    }
}

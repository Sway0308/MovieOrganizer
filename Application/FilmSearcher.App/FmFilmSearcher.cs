using Category.Standard.Adaptors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
                return;

            var films = new List<string> { @"C:\SourceCode", @"C:\Collaborate" }; //Adaptor.FindFilms(keyword);
            ListBoxFilm.DataSource = films;
        }

        private void TxtKeyword_TextChanged(object sender, EventArgs e)
        {
            SearchDistributor();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxFilm.Items.Count == 0 || ListBoxFilm.SelectedItem == null)
                return;

            var filePath = ListBoxFilm.SelectedItem.ToString();
            var dirPath = Directory.GetParent(filePath);

            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = dirPath.FullName;
            prc.Start();
        }
    }
}

using Adjustment.App.Interfaces;
using Category.Standard.Interfaces;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class FilmSearcherControl : UserControl, IInitControls
    {
        private ICatalog Catalog;
        private readonly Action<Film> NotifyAction;

        public FilmSearcherControl()
        {
            InitializeComponent();
        }

        public FilmSearcherControl(Action<Film> action) : base()
        {
            InitializeComponent();
            NotifyAction = action;
        }

        private void TxtKeyword_TextChanged(object sender, EventArgs e)
        {
            SearchFilms();
        }

        private void SearchFilms()
        {
            var keyword = TxtKeyword.Text;
            if (string.IsNullOrEmpty(keyword))
            {
                ListBoxFilm.DataSource = null;
                listBoxHistory.DataSource = null;
                NotifyAction.Invoke(null);
                return;
            }

            var films = Catalog.FindFilms(keyword);
            ListBoxFilm.DataSource = films.Select(x => x.FilePath).ToList();
            LabTotal.Text = $"Total: {ListBoxFilm.Items.Count}";

            var historys = Catalog.FindHistoryFilms(keyword);
            listBoxHistory.DataSource = historys.Select(x => x.FilePath).ToList();

            var film = ListBoxFilm.Items.Count == 0 ? new Film(string.Empty) : films.ElementAt(0);
            NotifyAction.Invoke(film);
        }

        private void ListBoxFilm_DoubleClick(object sender, EventArgs e)
        {
            if (ListBoxFilm.SelectedItem == null)
                return;

            var filePath = ListBoxFilm.SelectedItem.ToString();
            var dirPath = Directory.GetParent(filePath);

            Process prc = Process.GetCurrentProcess();
            prc.StartInfo.FileName = dirPath.FullName;
            prc.Start();
        }

        private void FilmSearcherControl_Load(object sender, EventArgs e)
        {
            TxtKeyword.Focus();
            ListBoxFilm.SelectedIndexChanged += (s, ev) => {
                if (NotifyAction == null || ListBoxFilm.SelectedItem == null)
                    return;

                var film = Catalog.FilmInfos.FirstOrDefault(x => x.FilePath.SameText(ListBoxFilm.SelectedItem.ToString()));
                if (film == null)
                    return;

                NotifyAction.Invoke(film);
            };
        }

        public void InitControls(ICatalog catalog)
        {
            Catalog = catalog;
            TxtKeyword.Text = string.Empty;
            SearchFilms();
        }
    }
}

using Adjustment.App.Interfaces;
using Category.Standard.Adaptors;
using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class FilmSearcherControl : UserControl, IInitControls
    {
        private IList<Film> FilmInfos;
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
                NotifyAction.Invoke(null);
                return;
            }

            var films = FilmInfos.Where(x => x.FilePath.IncludeText(keyword));
            ListBoxFilm.DataSource = films.Select(x => x.FilePath).ToList();
            LabTotal.Text = $"Total: {ListBoxFilm.Items.Count}";
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
            ListBoxFilm.Click += (s, ev) => {
                if (NotifyAction == null || ListBoxFilm.SelectedItem == null)
                    return;

                var film = FilmInfos.FirstOrDefault(x => x.FilePath.SameText(ListBoxFilm.SelectedItem.ToString()));
                if (film == null)
                    return;

                NotifyAction.Invoke(film);
            };
        }

        public void InitControls(CatalogAdaptor Adaptor)
        {
            TxtKeyword.Text = string.Empty;
            SearchFilms();
            FilmInfos = Adaptor.FilmInfos;
        }
    }
}

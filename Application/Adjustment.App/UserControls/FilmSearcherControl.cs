﻿using Category.Standard.Models;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class FilmSearcherControl : UserControl
    {
        private readonly IList<Film> FilmInfos;

        public FilmSearcherControl()
        {
            InitializeComponent();
        }

        public FilmSearcherControl(IList<Film> filmInfos) : base()
        {
            InitializeComponent();
            FilmInfos = filmInfos;
        }

        public FilmSearcherControl(IList<Film> filmInfos, Action<Film> action) : base()
        {
            InitializeComponent();
            FilmInfos = filmInfos;

            NotifyAction = action;
        }

        private readonly Action<Film> NotifyAction;

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
                return;
            }

            var films = FilmInfos.Where(x => x.FileName.IncludeText(keyword));
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
    }
}

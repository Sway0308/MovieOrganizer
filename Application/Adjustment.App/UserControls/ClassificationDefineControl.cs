﻿using Category.Standard.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class ClassificationDefineControl : UserControl
    {
        private readonly ClassificationDefine ClassificationDefine;
        private IList<string> Distributors => ClassificationDefine.Distributors;
        private IList<string> Genres => ClassificationDefine.Genres;
        private IList<string> Actors => ClassificationDefine.Actors;

        public ClassificationDefineControl()
        {
            InitializeComponent();
        }

        public ClassificationDefineControl(ClassificationDefine filmDefine) : base()
        {
            InitializeComponent();
            ClassificationDefine = filmDefine;
        }

        private void FilmDefineControl_Load(object sender, System.EventArgs e)
        {
            if (ClassificationDefine == null)
                return;

            LbDistributor.DataSource = Distributors;
            LbGenre.DataSource = Genres;
            LbActor.DataSource = Actors;

            LbDistributor.Click += (s, ev) => ShowSelectedItem(LbDistributor, TxtDistributor);
            BtnAddDistributor.Click += (s, ev) => AddItem(Distributors, TxtDistributor);
            BtnDelDistributor.Click += (s, ev) => DeleteItem(Distributors, TxtDistributor);

            LbGenre.Click += (s, ev) => ShowSelectedItem(LbGenre, TxtGenre);
            BtnAddGenre.Click += (s, ev) => AddItem(Genres, TxtGenre);
            BtnDelGenre.Click += (s, ev) => DeleteItem(Genres, TxtGenre);

            LbActor.Click += (s, ev) => ShowSelectedItem(LbActor, TxtActor);
            BtnAddActor.Click += (s, ev) => AddItem(Actors, TxtActor);
            BtnDelActor.Click += (s, ev) => DeleteItem(Actors, TxtActor);
        }

        private void ShowSelectedItem(ListBox listBox, TextBox textBox)
        {
            textBox.Text = listBox.SelectedItem?.ToString();
            Clipboard.SetText(textBox.Text ?? string.Empty);
        }

        private void AddItem(IList<string> list, TextBox textBox)
        {
            var item = textBox.Text.Trim();
            if (string.IsNullOrEmpty(item))
                return;

            if (list.IndexOf(item) >= 0)
                return;

            list.Add(item);
        }

        private void DeleteItem(IList<string> list, TextBox textBox)
        {
            var item = textBox.Text.Trim();
            if (string.IsNullOrEmpty(item))
                return;

            if (list.IndexOf(item) < 0)
                return;
            list.Remove(item);
            textBox.Clear();
        }
    }
}

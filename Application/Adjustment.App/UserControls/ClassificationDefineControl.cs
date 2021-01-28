using Category.Standard.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class ClassificationDefineControl : UserControl
    {
        private readonly ClassificationDefine ClassificationDefine;
        private readonly Action SaveClassificationDefineAction;
        private IList<string> Distributors => ClassificationDefine.Distributors;
        private IList<string> Genres => ClassificationDefine.Genres;
        private IList<string> Actors => ClassificationDefine.Actors;

        public ClassificationDefineControl()
        {
            InitializeComponent();
        }

        public ClassificationDefineControl(ClassificationDefine filmDefine, Action saveClassificationDefine) : base()
        {
            InitializeComponent();
            ClassificationDefine = filmDefine;

            SaveClassificationDefineAction = saveClassificationDefine;
        }

        private void FilmDefineControl_Load(object sender, System.EventArgs e)
        {
            if (ClassificationDefine == null)
                return;

            LoadListControl();

            LbDistributor.Click += (s, ev) => ShowSelectedItem(LbDistributor, TxtDistributor);
            BtnAddDistributor.Click += (s, ev) => AddItem(Distributors, TxtDistributor);
            BtnDelDistributor.Click += (s, ev) => DeleteItem(Distributors, TxtDistributor);

            LbGenre.Click += (s, ev) => ShowSelectedItem(LbGenre, TxtGenre);
            BtnAddGenre.Click += (s, ev) => AddItem(Genres, TxtGenre);
            BtnDelGenre.Click += (s, ev) => DeleteItem(Genres, TxtGenre);

            LbActor.Click += (s, ev) => ShowSelectedItem(LbActor, TxtActor);
            BtnAddActor.Click += (s, ev) => AddItem(Actors, TxtActor);
            BtnDelActor.Click += (s, ev) => DeleteItem(Actors, TxtActor);

            ExportButton.Click += (s, ev) => SaveClassificationDefineAction.Invoke();
        }

        private void ShowSelectedItem(ListBox listBox, TextBox textBox)
        {
            textBox.Text = listBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(textBox.Text))
                return;
            Clipboard.SetText(textBox.Text);
        }

        private void AddItem(IList<string> list, TextBox textBox)
        {
            var item = textBox.Text.Trim();
            if (string.IsNullOrEmpty(item))
                return;

            if (list.IndexOf(item) >= 0)
                return;

            list.Add(item);
            LoadListControl();
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
            LoadListControl();
        }

        private void LoadListControl()
        {
            LbDistributor.DataSource = new List<string>(Distributors);
            LbGenre.DataSource = new List<string>(Genres);
            LbActor.DataSource = new List<string>(Actors);
        }
    }
}

using Adjustment.App.Interfaces;
using Category.Standard.Configs;
using Category.Standard.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class ClassificationDefineControl : UserControl, IInitControls
    {
        private ICatalog Catalog;
        private IReadOnlyList<string> Distributors => Catalog.ClassificationDefine.Distributors;
        private IReadOnlyList<string> Genres => Catalog.ClassificationDefine.Genres;
        private IReadOnlyList<string> Actors => Catalog.ClassificationDefine.Actors;

        public ClassificationDefineControl()
        {
            InitializeComponent();
        }

        private void FilmDefineControl_Load(object sender, System.EventArgs e)
        {
            LbDistributor.DoubleClick += (s, ev) => ShowSelectedItem(LbDistributor, TxtDistributor);
            BtnAddDistributor.Click += (s, ev) => AddItem(EClassificationDefine.Distributors, TxtDistributor);
            BtnDelDistributor.Click += (s, ev) => DeleteItem(EClassificationDefine.Distributors, TxtDistributor);

            LbGenre.DoubleClick += (s, ev) => ShowSelectedItem(LbGenre, TxtGenre);
            BtnAddGenre.Click += (s, ev) => AddItem(EClassificationDefine.Genres, TxtGenre);
            BtnDelGenre.Click += (s, ev) => DeleteItem(EClassificationDefine.Genres, TxtGenre);

            LbActor.DoubleClick += (s, ev) => ShowSelectedItem(LbActor, TxtActor);
            BtnAddActor.Click += (s, ev) => AddItem(EClassificationDefine.Actors, TxtActor);
            BtnDelActor.Click += (s, ev) => DeleteItem(EClassificationDefine.Actors, TxtActor);
        }

        private void ShowSelectedItem(ListBox listBox, TextBox textBox)
        {
            textBox.Text = listBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(textBox.Text))
                return;
            Clipboard.SetText(textBox.Text);
        }

        private void AddItem(EClassificationDefine classificationDefine, TextBox textBox)
        {
            var item = textBox.Text.Trim();
            if (string.IsNullOrEmpty(item))
                return;
            Catalog.AddClassificationDefine(classificationDefine, item);
            LoadListControl();
        }

        private void DeleteItem(EClassificationDefine classificationDefine, TextBox textBox)
        {
            var item = textBox.Text.Trim();
            if (string.IsNullOrEmpty(item))
                return;

            Catalog.DeleteClassificationDefine(classificationDefine, item);
            LoadListControl();
        }

        private void LoadListControl()
        {
            LbDistributor.DataSource = new List<string>(Distributors);
            LbDistributor.SelectedIndex = LbDistributor.Items.Count - 1;
            LbGenre.DataSource = new List<string>(Genres);
            LbGenre.SelectedIndex = LbGenre.Items.Count - 1;
            LbActor.DataSource = new List<string>(Actors);
            LbActor.SelectedIndex = LbActor.Items.Count - 1;
        }

        public void InitControls(ICatalog catalog)
        {
            Catalog = catalog;
            LoadListControl();
            TxtDistributor.Text = string.Empty;
            TxtGenre.Text = string.Empty;
            TxtActor.Text = string.Empty;
        }
    }
}

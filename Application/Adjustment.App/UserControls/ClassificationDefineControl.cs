using Category.Standard.Models;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class ClassificationDefineControl : UserControl
    {
        private readonly ClassificationDefine ClassificationDefine;
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

            LbDistributor.DataSource = ClassificationDefine.Distributors;
            LbGenre.DataSource = ClassificationDefine.Genres;
            LbActor.DataSource = ClassificationDefine.Actors;

            LbDistributor.Click += (s, ev) => ShowSelectedItem(LbDistributor, TxtDistributor);
            BtnAddDistributor.Click += (s, ev) => AddItem(LbDistributor, TxtDistributor);
            BtnDelDistributor.Click += (s, ev) => DeleteItem(LbDistributor, TxtDistributor);

            LbGenre.Click += (s, ev) => ShowSelectedItem(LbGenre, TxtGenre);
            BtnAddGenre.Click += (s, ev) => AddItem(LbGenre, TxtGenre);
            BtnDelGenre.Click += (s, ev) => DeleteItem(LbGenre, TxtGenre);

            LbActor.Click += (s, ev) => ShowSelectedItem(LbActor, TxtActor);
            BtnAddActor.Click += (s, ev) => AddItem(LbActor, TxtActor);
            BtnDelActor.Click += (s, ev) => DeleteItem(LbActor, TxtActor);
        }

        private void ShowSelectedItem(ListBox listBox, TextBox textBox)
        {
            textBox.Text = listBox.SelectedItem?.ToString();
            Clipboard.SetText(textBox.Text ?? string.Empty);
        }

        private void AddItem(ListBox listBox, TextBox textBox)
        {
            var item = textBox.Text.Trim();
            if (string.IsNullOrEmpty(item))
                return;

            if (listBox.Items.IndexOf(item) >= 0)
                return;
            listBox.Items.Add(item);
        }

        private void DeleteItem(ListBox listBox, TextBox textBox)
        {
            var item = textBox.Text.Trim();
            if (string.IsNullOrEmpty(item))
                return;

            if (listBox.Items.IndexOf(item) < 0)
                return;
            listBox.Items.Remove(item);
            textBox.Clear();
        }
    }
}

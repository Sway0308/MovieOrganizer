using Category.Standard.Models;
using System.Windows.Forms;

namespace Adjustment.App.UserControls
{
    public partial class FilmInfoControl : UserControl
    {
        public FilmInfoControl()
        {
            InitializeComponent();
        }

        public void ShowFilmInfo(Film filmInfo)
        {
            TxtPath.Text = filmInfo.FilePath;
            TxtName.Text = filmInfo.FileName;
            TxtDistributor.Text = filmInfo.Distributor;
            TxtIdentification.Text = filmInfo.Identification;

            LbGenres.DataSource = filmInfo.Genres;
            LbActors.DataSource = filmInfo.Actors;
            LbBrackets.DataSource = filmInfo.Brackets;
        }

        private void FilmInfoControl_Load(object sender, System.EventArgs e)
        {
            TxtPath.MouseEnter += (s, ev) => TextBoxEnter(TxtPath);
            TxtName.MouseEnter += (s, ev) => TextBoxEnter(TxtName);
            TxtDistributor.MouseEnter += (s, ev) => TextBoxEnter(TxtDistributor);
            TxtIdentification.MouseEnter += (s, ev) => TextBoxEnter(TxtIdentification);
        }

        private void TextBoxEnter(TextBox textBox)
        {
            //var value = textBox.Text ?? string.Empty;
            //if (string.IsNullOrEmpty(value))
            //    return;
            //
            //Clipboard.SetText(value);
        }
    }
}

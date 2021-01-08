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
            LbBrackets.DataSource = filmInfo.Brackets;
        }
    }
}

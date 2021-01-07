using Adjustment.App.UserControls;
using Category.Standard.Adaptors;
using Category.Standard.Models;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Adjustment.App
{
    public partial class FmMain : Form
    {
        private readonly CatalogAdaptor Adaptor;
        private readonly FilmInfoControl FilmInfoControl = new FilmInfoControl { Dock = DockStyle.Fill };

        public FmMain()
        {
            InitializeComponent(); 
            
            var exportPath = ConfigurationManager.AppSettings["ExportPath"];
            Adaptor = new CatalogAdaptor(exportPath);
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            tabPageFilmSearcher.Controls.Add(new FilmSearcherControl(Adaptor.FilmInfos) { Dock = DockStyle.Fill });
            tabPageEmptyDirs.Controls.Add(new EmptyDirsControl(Adaptor.EmptyDirs) { Dock = DockStyle.Fill });
            tabPageExtension.Controls.Add(new ExtensionControl(Adaptor.Extensions) { Dock = DockStyle.Fill });

            var filmDefine = new ClassificationDefineControl(Adaptor.ClassificationDefine) { Dock = DockStyle.Fill };
            TlDefineSetting.Controls.Add(filmDefine, 0, 0);
            TlDefineSetting.SetColumnSpan(filmDefine, 2);
            TlDefineSetting.Controls.Add(new FilmSearcherControl(Adaptor.FilmInfos) { Dock = DockStyle.Fill, IsNotifyRequired = true }, 0, 1);
            TlDefineSetting.Controls.Add(FilmInfoControl, 1, 1);
        }

        public void NotifySelectedFilmInfo(Film filmInfo)
        {
            FilmInfoControl.ShowFilmInfo(filmInfo);
        }
    }
}

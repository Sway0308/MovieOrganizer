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

        public FmMain()
        {
            InitializeComponent(); 
            
            var exportPath = ConfigurationManager.AppSettings["ExportPath"];
            Adaptor = new CatalogAdaptor(exportPath);
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            tabPageEmptyDirs.Controls.Add(new EmptyDirsControl(Adaptor.EmptyDirs) { Dock = DockStyle.Fill });
            tabPageExtension.Controls.Add(new ExtensionControl(Adaptor.Extensions, Adaptor.SaveExtention) { Dock = DockStyle.Fill });

            var filmDefine = new ClassificationDefineControl(Adaptor.ClassificationDefine, Adaptor.SaveClassificationDefine) { Dock = DockStyle.Fill };
            TlDefineSetting.Controls.Add(filmDefine, 0, 0);
            TlDefineSetting.SetColumnSpan(filmDefine, 2);

            var filmInfoControl = new FilmInfoControl { Dock = DockStyle.Fill };
            TlDefineSetting.Controls.Add(new FilmSearcherControl(Adaptor.FilmInfos, filmInfoControl.ShowFilmInfo) { Dock = DockStyle.Fill }, 0, 1);
            TlDefineSetting.Controls.Add(filmInfoControl, 1, 1);
        }
    }
}

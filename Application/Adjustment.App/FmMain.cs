using Adjustment.App.UserControls;
using Category.Standard.Adaptors;
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
            tabPageExtension.Controls.Add(new ExtensionControl(Adaptor.Extensions) { Dock = DockStyle.Fill });
        }
    }
}

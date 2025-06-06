﻿using Adjustment.App.Interfaces;
using Adjustment.App.UserControls;
using Category.Standard.Adaptors;
using Category.Standard.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace Adjustment.App
{
    public partial class FmMain : Form
    {
        private readonly ICatalog Catalog;
        private readonly List<UserControl> UserControls = new List<UserControl>();

        public FmMain()
        {
            InitializeComponent();
            var exportPath = ConfigurationManager.AppSettings["ExportPath"];
            Catalog = new CatalogAdaptor(exportPath);
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            var emptyDirsControl = new EmptyDirsControl { Dock = DockStyle.Fill };
            UserControls.Add(emptyDirsControl);
            tabPageEmptyDirs.Controls.Add(emptyDirsControl);

            var extensionControl = new ExtensionControl { Dock = DockStyle.Fill };
            UserControls.Add(extensionControl);
            tabPageExtension.Controls.Add(extensionControl);

            var filmDefine = new ClassificationDefineControl { Dock = DockStyle.Fill };
            UserControls.Add(filmDefine);
            TlDefineSetting.Controls.Add(filmDefine, 0, 0);
            TlDefineSetting.SetColumnSpan(filmDefine, 2);

            var filmInfoControl = new FilmInfoControl { Dock = DockStyle.Fill };
            UserControls.Add(filmInfoControl);
            TlDefineSetting.Controls.Add(filmInfoControl, 1, 1);
            var filmSearchControl = new FilmSearcherControl(filmInfoControl.ShowFilmInfo) { Dock = DockStyle.Fill };
            UserControls.Add(filmSearchControl);
            TlDefineSetting.Controls.Add(filmSearchControl, 0, 1);

            ReCatalogAdaptor();
        }

        private void InitUserControls(IInitControls usercontrol)
        {
            usercontrol.InitControls(Catalog);
        }

        private void ReCatalogAdaptor()
        {
            Catalog.Init();
            foreach (var item in UserControls)
            {
                if (item is IInitControls)
                    InitUserControls(item as IInitControls);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Refresh?", "Refresh Catalog", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            ReCatalogAdaptor();
        }
    }
}

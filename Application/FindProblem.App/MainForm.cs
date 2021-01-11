using Category.Standard.Adaptors;
using Category.Standard.Models;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FindProblem.App
{
    public partial class MainForm : Form
    {
        private readonly RuleAdaptor RuleAdaptor;

        public MainForm()
        {
            InitializeComponent();

            var exportPath = ConfigurationManager.AppSettings["ExportPath"];
            RuleAdaptor = new RuleAdaptor(exportPath);
        }

        private ObservableCollection<FilmNameSuggestion> Suggestions { get; set; }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            foreach (var item in RuleAdaptor.RuleTypes)
            {
                var desc = RuleAdaptor.GetDescription(item);
                RuleListBox.Items.Add(desc);
            }

            RuleListBox.Click += (s, ev) => {
                if (RuleListBox.SelectedItem != null)
                    return;

                var result = RuleAdaptor.FindByRule(RuleListBox.SelectedIndex);
                Suggestions = new ObservableCollection<FilmNameSuggestion>(result);
                DetailListBox.DataSource = Suggestions;
            };
            DetailListBox.Click += (s, ev) => {
                if (!string.IsNullOrEmpty(DetailListBox.SelectedItem?.ToString()))
                    return;

                var sugs = Suggestions.ElementAt(DetailListBox.SelectedIndex);
                SuggestionListBox.DataSource = sugs.SuggestNames;
            };
            DetailListBox.DoubleClick += (s, ev) => {
                if (!string.IsNullOrEmpty(DetailListBox.SelectedItem?.ToString()))
                    return;

                Process prc = Process.GetCurrentProcess();
                prc.StartInfo.FileName = DetailListBox.SelectedItem.ToString();
                prc.Start();
            };
            SuggestionListBox.Click += (s, ev) => {
                if (SuggestionListBox.SelectedItem != null)
                    return;

                Clipboard.SetText(SuggestionListBox.SelectedItem.ToString() ?? string.Empty);
            };
        }
    }
}

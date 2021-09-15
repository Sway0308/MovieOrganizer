using Category.Standard.Adaptors;
using Category.Standard.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        private IList<IRuleModel> Suggestions { get; set; }
        private IEnumerable<IRuleModel> DisplaySuggestions => Suggestions.Where(x => !x.Solved).Select(x => x);

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (var item in RuleAdaptor.RuleTypes)
            {
                var desc = RuleAdaptor.GetDescription(item);
                RuleListBox.Items.Add(desc);
            }

            RuleListBox.Click += (s, ev) => {
                if (RuleListBox.SelectedItem == null)
                    return;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Suggestions = RuleAdaptor.FindByRule(RuleListBox.SelectedIndex);
                    ShowDetails();
                    ShowSuggestions(DisplaySuggestions.FirstOrDefault());
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            };

            DetailListBox.Click += (s, ev) => {
                if (string.IsNullOrEmpty(DetailListBox.SelectedItem?.ToString()))
                    return;

                var ruleModel = GetSelectedRule();
                ShowSuggestions(ruleModel);

                Clipboard.SetText(ruleModel.GetCopyableMainText() ?? string.Empty);
            };

            DetailListBox.DoubleClick += (s, ev) => {
                if (string.IsNullOrEmpty(DetailListBox.SelectedItem?.ToString()))
                    return;

                var ruleModel = GetSelectedRule();
                OpenDirectory(ruleModel.OpenableMainText());
            };

            SuggestionListBox.DoubleClick += (s, ev) =>
            {
                if (SuggestionListBox.SelectedItem == null)
                    return;

                if (MessageBox.Show("Are you sure rename this file?", "Rename?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                var ruleModel = GetSelectedRule();
                ruleModel.Solve(ruleModel.Answers[SuggestionListBox.SelectedIndex]);
                ShowDetails();
                ShowSuggestions(DisplaySuggestions.FirstOrDefault());
            };
        }

        private void ShowDetails()
        {
            DetailListBox.DataSource = DisplaySuggestions.ToList();
        }

        private void ShowSuggestions(IRuleModel rule)
        {
            if (rule == null)
                return;

            SuggestionListBox.DataSource = rule.Answers;
        }

        private IRuleModel GetSelectedRule() => DisplaySuggestions.ElementAt(DetailListBox.SelectedIndex);

        private void OpenDirectory(string dirPath)
        {
            if (string.IsNullOrEmpty(dirPath) || !Directory.Exists(dirPath))
            {
                MessageBox.Show("No such file");
                return;
            }

            Process prc = Process.GetCurrentProcess();
            prc.StartInfo.FileName = dirPath;
            prc.Start();
        }
    }
}

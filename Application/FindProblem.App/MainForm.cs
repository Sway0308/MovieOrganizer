using Category.Standard.Adaptors;
using Category.Standard.Interfaces;
using System;
using System.Collections.Generic;
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

        private IList<IRuleModel> Suggestions { get; set; }

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

                Suggestions = RuleAdaptor.FindByRule(RuleListBox.SelectedIndex);
                DetailListBox.DataSource = Suggestions.Select(x => x.Main).ToList();

                if (!Suggestions.Any())
                    return;

                var ruleModel = Suggestions.First();
                SuggestionListBox.DataSource = ruleModel.Answers;
            };
            DetailListBox.Click += (s, ev) => {
                if (string.IsNullOrEmpty(DetailListBox.SelectedItem?.ToString()))
                    return;

                var ruleModel = Suggestions[DetailListBox.SelectedIndex];
                SuggestionListBox.DataSource = ruleModel.Answers;

                Clipboard.SetText(ruleModel.GetCopyableMainText() ?? string.Empty);
            };
            DetailListBox.DoubleClick += (s, ev) => {
                if (string.IsNullOrEmpty(DetailListBox.SelectedItem?.ToString()))
                    return;

                var ruleModel = Suggestions[DetailListBox.SelectedIndex];
                var openableText = ruleModel.OpenableMainText();
                if (string.IsNullOrEmpty(openableText))
                    return;

                Process prc = Process.GetCurrentProcess();
                prc.StartInfo.FileName = openableText;
                prc.Start();
            };
            SuggestionListBox.Click += (s, ev) => {
                if (SuggestionListBox.SelectedItem == null)
                    return;

                var ruleModel = Suggestions[DetailListBox.SelectedIndex];
                var answer = ruleModel.Answers.ElementAt(SuggestionListBox.SelectedIndex);

                Clipboard.SetText(ruleModel.GetCopyableAnswerText(answer) ?? string.Empty);
            };
            SuggestionListBox.DoubleClick += (s, ev) =>
            {
                if (SuggestionListBox.SelectedItem == null)
                    return;

                var ruleModel = Suggestions[DetailListBox.SelectedIndex];
                var answer = ruleModel.Answers.ElementAt(SuggestionListBox.SelectedIndex);
                var openableText = ruleModel.OpenableAnswerText(answer);
                if (string.IsNullOrEmpty(openableText))
                    return;

                Process prc = Process.GetCurrentProcess();
                prc.StartInfo.FileName = openableText;
                prc.Start();
            };
        }
    }
}

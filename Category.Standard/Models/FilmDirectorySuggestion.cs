using Category.Standard.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Category.Standard.Models
{
    public class FilmDirectorySuggestion : IRuleModel
    {
        public Film Film { get; set; }
        public IList<string> Suggestions { get; set; }
        public IList<string> Answers => Suggestions;
        public string Main => Film.DirectoryName;
        public bool Solved { get; private set; }

        public string GetCopyableAnswerText(string answer)
        {
            return answer;
        }

        public string GetCopyableMainText()
        {
            return Film.DirectoryPath;
        }

        public string OpenableAnswerText(string answer)
        {
            return answer;
        }

        public string OpenableMainText()
        {
            return Film.DirectoryPath;
        }

        public void Solve(string answer)
        {
            if (Solved) return;
            if (string.IsNullOrEmpty(answer)) return;
            if (!Directory.Exists(Film.DirectoryPath)) return;

            var newName = Path.Combine(Directory.GetParent(Film.DirectoryPath).FullName, answer);
            Directory.Move(Film.DirectoryPath, newName);

            Solved = true;
        }

        public override string ToString()
        {
            return Main;
        }
    }
}

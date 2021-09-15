using Category.Standard.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Category.Standard.Models
{
    public class FilmNameSuggestion : IRuleModel
    {
        public Film Film { get; set; }
        public IList<string> Suggestions { get; set; }

        public IList<string> Answers => Suggestions;

        public string Main => Film.FilePath;

        public bool Solved { get; private set; }

        public string GetCopyableAnswerText(string answer)
        {
            return answer;
        }

        public string GetCopyableMainText()
        {
            return Film.FileName;
        }

        public string OpenableAnswerText(string answer)
        {
            return null;
        }

        public string OpenableMainText()
        {
            return Film.DirectoryPath;
        }

        public void Solve(string answer)
        {
            if (Solved) return;
            if (string.IsNullOrEmpty(answer)) return;
            if (!File.Exists(Film.FilePath)) return;

            var newName = Path.Combine(Film.DirectoryPath, answer + Film.Extension);
            File.Move(Film.FilePath, newName);

            Solved = true;
        }

        public override string ToString()
        {
            return Film.FileName;  
        }
    }
}

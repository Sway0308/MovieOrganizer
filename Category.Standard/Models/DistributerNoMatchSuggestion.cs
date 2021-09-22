using Category.Standard.Interfaces;
using Gatchan.Base.Standard.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Category.Standard.Models
{
    public class DistributerNoMatchSuggestion : IRuleModel
    {
        public Film Film { get; set; }
        public IList<string> Answers { get; set; }

        public bool Solved { get; private set; }

        public string Main => Film.FileName;

        public string GetCopyableAnswerText(string answer)
        {
            return answer; //throw new NotImplementedException();
        }

        public string GetCopyableMainText()
        {
            return Main; //throw new NotImplementedException();
        }

        public string OpenableAnswerText(string answer)
        {
            return string.Empty; //throw new NotImplementedException();
        }

        public string OpenableMainText()
        {
            return Film.DirectoryPath; //throw new NotImplementedException();
        }

        public void Solve(string answer)
        {
            if (Solved) return;
            if (answer.IsEmpty()) return;
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

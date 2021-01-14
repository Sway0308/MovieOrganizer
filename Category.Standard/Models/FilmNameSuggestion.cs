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
            return Directory.GetParent(Film.FilePath).FullName;
        }
    }
}

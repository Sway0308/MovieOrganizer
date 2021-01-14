using Category.Standard.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Category.Standard.Models
{
    public class RepeatedIdentifications : IRuleModel
    {
        private IList<Film> _filmInfos;
        private IList<string> _answers;
        public string Identification { get; set; }
        public IList<Film> FilmInfos 
        {
            get => _filmInfos; 
            set 
            {
                _filmInfos = value;
                _answers = value.Select(x => x.FilePath).ToList();
            } 
        }

        public IList<string> Answers => _answers;

        public string Main => Identification;

        public string GetCopyableAnswerText(string answer)
        {
            return Path.GetFileName(answer);
        }

        public string GetCopyableMainText()
        {
            return Identification;
        }

        public string OpenableAnswerText(string answer)
        {
            return Directory.GetParent(answer).FullName;
        }

        public string OpenableMainText()
        {
            return null;
        }
    }
}

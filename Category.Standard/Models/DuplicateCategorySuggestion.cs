using Category.Standard.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Category.Standard.Models
{
    public class DuplicateCategorySuggestion : IRuleModel
    {
        public IList<string> Answers { get; set; }

        public bool Solved { get; }

        public string Main { get; set; }

        public string GetCopyableAnswerText(string answer)
        {
            return answer; // throw new NotImplementedException();
        }

        public string GetCopyableMainText()
        {
            return Main;
        }

        public string OpenableAnswerText(string answer)
        {
            return string.Empty; //throw new NotImplementedException();
        }

        public string OpenableMainText()
        {
            return string.Empty; //throw new NotImplementedException();
        }

        public void Solve(string answer)
        {
            //throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Main;
        }
    }
}

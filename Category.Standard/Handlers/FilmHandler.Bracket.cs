using Category.Standard.Models;
using System.Collections.Generic;

namespace Category.Standard.Handlers
{
    public partial class FilmHandler
    {
        private Film ExtractFilmInfo(string file)
        {
            var model = new Film(file);
            var brackets = new List<Bracket>();
            ExtractBrackets(model.FileName, brackets);
            model.AddBrackets(brackets);
            return model;
        }

        private void ExtractBrackets(string fileName, IList<Bracket> brackets)
        {
            if (!fileName.Contains("(") || !fileName.Contains(")"))
                return;

            var leftBracket = fileName.IndexOf("(");
            var rightBracket = fileName.IndexOf(")");

            var innerText = fileName.Substring(leftBracket, rightBracket - leftBracket + 1);
            brackets.Add(new Bracket { Text = innerText });
            var nextFileName = fileName.Replace(innerText, string.Empty);
            ExtractBrackets(nextFileName, brackets);
        }
    }
}

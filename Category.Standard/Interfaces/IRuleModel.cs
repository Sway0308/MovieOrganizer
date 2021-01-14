using System.Collections.Generic;

namespace Category.Standard.Interfaces
{
    public interface IRuleModel
    {
        string Main { get; }
        IList<string> Answers { get; }

        string GetCopyableMainText();
        string GetCopyableAnswerText(string answer);
        string OpenableMainText();
        string OpenableAnswerText(string answer);
    }
}

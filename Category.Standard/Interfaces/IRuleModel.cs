using System.Collections.Generic;

namespace Category.Standard.Interfaces
{
    public interface IRuleModel
    {
        IList<string> Answers { get; }
        bool Solved { get; }

        string Main { get; }

        void Solve(string answer);

        string GetCopyableMainText();
        string GetCopyableAnswerText(string answer);
        string OpenableMainText();
        string OpenableAnswerText(string answer);
    }
}

using Category.Standard.Configs;

namespace Category.Standard.Models
{
    public class Bracket
    {
        public string Text { get; set; }
        public CategoryType Type { get; set; }

        public override string ToString()
        {
            return Text + " - " + Type.ToString();
        }
    }
}

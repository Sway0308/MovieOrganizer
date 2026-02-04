namespace Category.Standard.Models
{
    public class ParserSetting
    {
        public string Name { get; set; }
        public string Pattern { get; set; }

        public ParserSetting() { }

        public ParserSetting(string name, string pattern)
        {
            Name = name;
            Pattern = pattern;
        }
    }
}

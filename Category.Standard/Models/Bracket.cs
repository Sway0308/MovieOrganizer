using Category.Standard.Configs;

namespace Category.Standard.Models
{
    /// <summary>
    /// 括弧內文字定義物件
    /// </summary>
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

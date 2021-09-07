using Gatchan.Base.Standard.Base;

namespace Category.Standard.Models
{
    /// <summary>
    /// 發行商-目錄
    /// </summary>
    public class DistributorCat
    {
        public string Distributor { get; set; }
        public string Category { get; set; }

        public override bool Equals(object obj)
        {
            var dis = obj as DistributorCat;
            if (Distributor == null)
                return false;
            return dis.Distributor.SameText(Distributor) && dis.Category.SameText(Category);
        }

        public override int GetHashCode()
        {
            return Distributor.GetHashCode() * Category.GetHashCode();
        }
    }
}

namespace FindMyItem.Domain
{
    public class SiteCategory// : IComparable
    {
        public CategoryType CategoryType { get; set; }
        public string URL { get; set; }
        public string CountNode { get; set; }

        //public int CompareTo(object obj)
        //{
        //    //if (obj == null) return 1;

        //    //var otherSiteCategory = obj as SiteCategory;

        //    //if (otherSiteCategory != null)
        //    //{
        //    //    return CategoryType.CompareTo(otherSiteCategory.CategoryType);
        //    //}
        //}
    }
}

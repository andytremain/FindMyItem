using System;
using System.Runtime.Serialization;

namespace FindMyItem.Domain
{
    [DataContract]
    public class WebSiteSearchResult
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string SiteName { get; set; }

        [DataMember]
        public CategoryType CategoryType { get; set; }

        [DataMember]
        public string Item { get; set; }

        [DataMember]
        public int ItemCount { get; set; }

        [DataMember]
        public string DispResultCount { get; set; }

        [DataMember]
        public string SiteURL { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        public WebSiteSearchResult(string site, CategoryType cat, string item, int? count, string url)
        {
            Id = Guid.NewGuid();
            SiteName = site;
            CategoryType = cat;
            Item = item;

            if (count != null)
            {
                ItemCount = (int)count;
                DispResultCount = count.ToString();
            }
            else
            {
                ItemCount = 0;
                DispResultCount = "n/a";
            }

            SiteURL = url;
        }
    }
}

using System;
using System.Collections.Generic;
using FindMyItem.Common.Helpers;

namespace FindMyItem.Domain
{
    public abstract class SiteBase : ISite
    {
        public String Name { get; set; }
        public String URL { get; set; }
        public string CountNode { get; set; }
        public int CharStartPos { get; set; }
        public int CountChars { get; set; }
        public string CharFindHelper { get; set; }
        public string PluginName { get; set; }
        public List<SiteCategory> Categories { get; set; }

        public SiteStatus Status
        {
            get
            {
                if (Enabled && SiteHelpers.SiteLive(this.URL))
                {
                    return SiteStatus.Active;
                }

                return !Enabled ? SiteStatus.Disabled : SiteStatus.ActiveWithError;
            }
        }

        public bool Enabled { get; set; }

        //public override string ToString()
        //{
        //    return String.Format("{0} Url: {1}, Plugin: {2}", Name, URL, PluginName);
        //}
    }
}

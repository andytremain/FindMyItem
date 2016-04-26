using System.Collections.Generic;

namespace FindMyItem.Domain
{
    public class SiteCacheDto
    {
        public List<Site> ActiveSites { get; set; }
        public List<Site> DisabledSites { get; set; }
    }
}

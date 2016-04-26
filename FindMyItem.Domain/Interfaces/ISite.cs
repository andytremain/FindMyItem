using System;
using System.Collections.Generic;

namespace FindMyItem.Domain
{
    public interface ISite
    {
        String Name { get; set; }
        String URL { get; set; }
        string CountNode { get; set; }
        int CharStartPos { get; set; }
        int CountChars { get; set; }
        string CharFindHelper { get; set; }
        string PluginName { get; set; }
        List<SiteCategory> Categories { get; set; }
        SiteStatus Status { get; }
    }
}

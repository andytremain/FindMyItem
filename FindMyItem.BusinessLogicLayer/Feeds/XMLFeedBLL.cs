using System;
using System.Diagnostics;
using System.Xml;

using FindMyItem.Domain;
using FindMyItem.Domain.Feeds;

namespace FindMyItem.BusinessLogicLayer.Feeds
{
    public class XMLFeedBLL : XMLFeedBaseBLL, IXMLFeed
    {
        public FeedSearchResult GetResults(string url, string item)
        {
            FeedSearchResult returnValue = new FeedSearchResult();
            Stopwatch sw = new Stopwatch();

            sw.Start();

            XmlReader xmlReader = XmlReader.Create(url);

            string feedURL = String.Empty;

            FeedResultBO fRes = null;

            while (xmlReader.Read())
            {
                // Start of current ad
                if ((xmlReader.Name.ToLower() == "ad") && (fRes == null))
                {
                    fRes = new FeedResultBO();
                }

                // End of current ad
                if ((xmlReader.NodeType == XmlNodeType.EndElement) && (xmlReader.Name.ToLower() == "ad"))
                {                    
                    if (fRes.Valid(item)) returnValue.FeedResults.Add(fRes);

                    fRes = null;
                }

                // Get Advert details
                if ((xmlReader.NodeType == XmlNodeType.Element) && fRes != null)
                {
                    if (xmlReader.Name == "url")
                    {
                        try
                        {
                            fRes.AdvertURL = CleanInnerXML(xmlReader.ReadInnerXml());
                        }
                        catch (Exception ex)
                        {
                            var t = "";

                        }

                    }

                    if (xmlReader.Name == "title")
                    {
                        fRes.Title = CleanInnerXML(xmlReader.ReadInnerXml());
                    }

                    //if (xmlReader.Name == "picture_url")
                    //{ 

                    //}
                }
            }

            sw.Stop();

            returnValue.SearchTime = sw.Elapsed;
            returnValue.Item = item;

            return returnValue;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

using BLL = FindMyItem.BusinessLogicLayer.Feeds;

namespace FindMyItem.Tests
{
    [TestClass]
    public class XMLFeedsTest
    {
        [TestMethod]
        public void XMLReaderTest()
        {
            BLL.XMLFeedBLL xmlBLL = new BLL.XMLFeedBLL();

            string url = "http://feeds.friday-ad.co.uk/xml/TrovitProductsXML.xml";
            string item = "clippers";

            var results = xmlBLL.GetResults(url, item);

            xmlBLL.Dispose();
        }
    }
}

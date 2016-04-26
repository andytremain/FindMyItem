using FindMyItem.Domain;
using FindMyItem.Managers;
using FindMyItem.REST;
using FindMyItem.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FindMyItem.Tests.Api
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public void SearchApiTest()
        {
            var controller = new Mock<HomeController>();
            var mockRestClient = new Mock<IRestCommands>();

            mockRestClient.Setup(x => x.Search("motors", "mondeo")).Returns(new SearchResult() );

            var sm = new SearchManager(mockRestClient.Object);

            var res = sm.Search("motors", "mondeo");

            Assert.AreNotEqual(res, null);
        }
    }
}

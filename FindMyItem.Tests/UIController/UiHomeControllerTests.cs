using System.Web.Mvc;
using FindMyItem.Managers;
using FindMyItem.REST;
using FindMyItem.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FindMyItem.Tests.UIController
{
    [TestClass]
    public class UiHomeControllerTests
    {
        [TestMethod, Ignore]
        public void HomeControllerAboutTest()
        {
            var searchManagerMock = new Mock<SearchManager>();
            var restCommandsMock = new Mock<IRestCommands>();
            var controller = new HomeController(searchManagerMock.Object, restCommandsMock.Object);

            var res = controller.About() as ViewResult;
            
            //Assert.IsNotNull(res.ViewBag);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using FindMyItem.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindMyItem.Tests.Site
{
    [TestClass]
    public class SearchTest
    {
        private IEnumerable<Domain.Site> GetSiteList()
        {
            var loader = new BusinessLogicLayer.SiteLoaderBLL();

            return loader.GetSitesList(false);
        }

        [TestMethod]
        public void TestAdmart()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Ad-Mart"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "macbook%20pro", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestAutotrader()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Autotrader")); 

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Motors);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestClassicCarsForSale()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("ClassicCarsForSale"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Motors);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestEbay()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Ebay")); 

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Motors);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestExchangeAndMart()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Exchange and Mart"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Motors);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestFreeads()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Freeads")); 

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestFridayAdCatAll()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Friday-Ad")); 

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestFridayAdCatMotor()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Friday-Ad"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Motors);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestGumtree()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Gumtree"));
                         
            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestLocanto()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Locanto")); 

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestLoot()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Loot"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestPistonheads()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Pistonheads")); 

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Motors);
            var res = bll.Search();
            
            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestPreloved()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Pre-Loved"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestTradeIt()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Trade-IT")); 

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestUkClassifieds()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("UK Classifieds"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestVivaStreet()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("VivaStreet")); 

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "mondeo", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestJobsite()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Jobsite"));  

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, ".net developer", CategoryType.Jobs);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestCwJobs()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("CwJobs"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, ".net developer", CategoryType.Jobs);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestMonster()
        {
            // Arrange
            var siteList = GetSiteList();

            Domain.Site site = siteList.FirstOrDefault(o => o.Name.Equals("Monster"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, ".net developer", CategoryType.Jobs);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestReed()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("Reed"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, ".net developer", CategoryType.Jobs);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestTotalJobs()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("TotalJobs")); 

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, ".net developer", CategoryType.Jobs);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }

        [TestMethod]
        public void TestNewsNow()
        {
            // Arrange
            var siteList = GetSiteList();

            var site = siteList.FirstOrDefault(o => o.Name.Equals("NewsNow"));

            // Act
            var bll = new BusinessLogicLayer.Plugins.PluginBLL(site, "guitar", CategoryType.Classifieds);
            var res = bll.Search();

            // Assert
            Assert.IsNotNull(res.ItemCount);
        }    
    }
}

using FindMyItem.Domain;
using FindMyItem.Domain.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindMyItem.Tests
{
    [TestClass]
    public class SiteFactoryTests
    {
        [TestMethod]
        public void EbaySiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Ebay);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Ebay");
        }

        [TestMethod]
        public void FreeadsSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Freeads);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Freeads");
        }

        [TestMethod]
        public void FridayAdSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.FridayAd);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Friday-Ad");
        }

        [TestMethod]
        public void GumtreeSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Gumtree);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Gumtree");
        }

        [TestMethod]
        public void AdmartSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.AdMart);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Ad-Mart");
        }

        [TestMethod]
        public void NewsNowSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.NewsNow);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "NewsNow");
        }

        [TestMethod]
        public void PrelovedSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Preloved);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Pre-Loved");
        }

        [TestMethod]
        public void VivaStreetSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.VivaStreet);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "VivaStreet");
        }

        [TestMethod]
        public void LootStreetSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Loot);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Loot");
        }

        [TestMethod]
        public void UkClassifiedsSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.UkClassifieds);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "UkClassifieds");
        }

        [TestMethod]
        public void LocantoSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Locanto);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Locanto");
        }

        [TestMethod]
        public void TradeItSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.TradeIt);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Trade-IT");
        }

        [TestMethod]
        public void PistonheadsSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Pistonheads);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Pistonheads");
        }

        [TestMethod]
        public void ClassicCarsForSaleSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.ClassicCarsForSale);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "ClassicCarsForSale");
        }

        [TestMethod]
        public void AutotraderForSaleSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Autotrader);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Autotrader");
        }

        [TestMethod]
        public void ExchangeAndMartSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.ExchangeAndMart);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Exchange and Mart");
        }

        [TestMethod]
        public void JobsiteSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.JobSite);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Jobsite");
        }

        [TestMethod]
        public void CwJobsSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.CwJobs);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "CwJobs");
        }

        [TestMethod]
        public void MonsterSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Monster);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Monster");
        }

        [TestMethod]
        public void ReedSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.Reed);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "Reed");
        }

        [TestMethod]
        public void TotalJobsSiteCreateTest()
        {
            var siteFactory = new SiteFactory(ESite.TotalJobs);

            var site = siteFactory.Create();

            Assert.AreEqual(site.Name, "TotalJobs");
        }
    }
}

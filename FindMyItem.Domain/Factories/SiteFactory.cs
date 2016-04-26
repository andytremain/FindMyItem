using System.Collections.Generic;
using FindMyItem.Common;

namespace FindMyItem.Domain.Factories
{
    public interface ICreateSite
    {
        ISite Create();
    }

    public class SiteFactory : ICreateSite
    {
        private readonly int _site;

        public SiteFactory(ESite site)
        {
            _site = (int)site;
        }

        public ISite Create()
        {
            switch (_site)
            {
                case (0):
                    var ebay = new Site
                    {
                        Name = "Ebay",
                        URL = "http://www.ebay.co.uk",
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Classifieds,
                                URL =
                                    "http://www.ebay.co.uk/sch/i.html?_trksid=p2050601.m570.l1313.TR11.TRC1.A0.Xbmw&_nkw={0}&_sacat=0&_from=R40"
                            },
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Motors,
                                URL =
                                    "http://www.ebay.co.uk/sch/i.html?_trksid=p2050890.m570.l1313.TR11.TRC1.A0.Xbmw&_nkw={0}&_sacat=0&_from=R40"
                            }
                        },
                        PluginName = Constants.PLUGIN_EBAY,
                        Enabled = true
                    };

                    return ebay;
                case (1):
                    var freeads = new Site
                    {
                        Name = "Freeads",
                        URL = "http://www.freeads.co.uk",
                        PluginName = Constants.PLUGIN_FREEADS,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Classifieds,
                                URL = "http://www.freeads.co.uk/search?for={0}",
                                CountNode = "//div[@id='top-box']//h2"
                            },
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Motors,
                                URL = "http://www.freeads.co.uk/uk/buy__sell/motors/search?for={0}"
                            }
                        },
                        Enabled = true
                    };
                    return freeads;
                case (2):
                    var fridayAd = new Site
                    {
                        Name = "Friday-Ad",
                        URL = "http://www.friday-ad.co.uk",
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Classifieds,
                                URL = "http://www.friday-ad.co.uk/uk/query-N-?Range=20&Terms={0}",
                                CountNode = "//span[@id='ctl02_lblAdCount']"
                            },
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Motors,
                                URL = "http://motors.friday-ad.co.uk/uk/query-N-1z140tf?Terms={0}",
                                CountNode = "//span[@id='ctl02_lblAdCountMotoring']"
                            }
                        },
                        PluginName = Constants.PLUGIN_FRIDAYAD,
                        Enabled = true
                    };

                    return fridayAd;
                case (3):
                    var gumtree = new Site
                    {
                        Name = "Gumtree",
                        URL = "http://www.gumtree.com",
                        PluginName = Constants.PLUGIN_GUMTREE,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Classifieds,
                                URL = "http://www.gumtree.com/search?q={0}&category=all&search_location=&current-distance=0.0&search_scope=title"
                            }
                        },
                        Enabled = true
                    };

                    return gumtree;
                case (4):
                    var admart = new Site
                    {
                        Name = "Ad-Mart",
                        URL = "http://www.ad-mart.co.uk",
                        PluginName = Constants.PLUGIN_ADMART,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Classifieds,
                                URL = "http://www.ad-mart.co.uk/index.php?page=search&s_res=OR&cid=0&stype=all&q={0}"
                            }
                        },
                        Enabled = true
                    };

                    return admart;
                case (5):
                    var newsNow = new Site
                    {
                        Name = "NewsNow",
                        URL = "http://www.newsnow.co.uk/classifieds",
                        PluginName = Constants.PLUGIN_NEWSNOW,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Classifieds,
                                URL = "http://www.newsnow.co.uk/classifieds/uk/{0}.html"
                            }
                        },
                        Enabled = true
                    };

                    return newsNow;
                case (6):
                    var preLoved = new Site
                    {
                        Name = "Pre-Loved",
                        URL = "http://www.preloved.co.uk",
                        PluginName = Constants.PLUGIN_PRELOVED,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Classifieds,
                                URL = "http://www.preloved.co.uk/search/all?keyword={0}&x=25&y=11"
                            }
                        },
                        Enabled = true
                    };

                    return preLoved;
                case (7):
                    var vivaStreet = new Site
                    {
                        Name = "VivaStreet",
                        URL = "http://www.vivastreet.co.uk",
                        PluginName = Constants.PLUGIN_VIVASTREET,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Classifieds,
                                URL = "http://search.vivastreet.co.uk/search?lb=new&search=1&start_field=1&keywords={0}&main_category=0&geosearch_text=&searchGeoId=-1&end_field=1"
                            }
                        },
                        Enabled = true
                    };

                    return vivaStreet;

                case (8):
                    var loot = new Site
                    {
                        Name = "Loot",
                        URL = "http://www.loot.com",
                        PluginName = Constants.PLUGIN_LOOT,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Classifieds,
                                URL = "http://www.loot.com/ad/search?CategoryText=All+categories&category=&keyword={0}&location=&doSearch="
                            }
                        },
                        Enabled = true
                    };

                    return loot;
                case (9):
                    var ukClassifieds = new Site
                    {
                        Name = "UkClassifieds",
                        URL = "http://www.ukclassifieds.co.uk",
                        PluginName = Constants.PLUGIN_UKCLASSIFIEDS,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                                {
                                    CategoryType = CategoryType.Classifieds,
                                    URL = "http://www.ukclassifieds.co.uk/index.php?page=search&s_res=OR&cid=0&stype=exact&q={0}"
                                }
                        },
                        Enabled = true
                    };

                    return ukClassifieds;
                case (10):
                    var locanto = new Site
                    {
                        Name = "Locanto",
                        URL = "http://www.locanto.co.uk",
                        PluginName = Constants.PLUGIN_LOCANTO,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                                {
                                    CategoryType = CategoryType.Classifieds,
                                    URL = "http://www.locanto.co.uk/q/?query={0}&area=&geoid="
                                }
                        },
                        Enabled = true
                    };

                    return locanto;
                case (11):
                    var tradeIt = new Site
                    {
                        Name = "Trade-IT",
                        URL = "http://www.trade-it.co.uk",
                        PluginName = Constants.PLUGIN_TRADEIT,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                                {
                                    CategoryType = CategoryType.Classifieds,
                                    URL = "http://www.trade-it.co.uk/region-w-uk-bristol-south-west/query-N-?Terms={0}"
                                }
                        },
                        Enabled = true
                    };

                    return tradeIt;
                case (12):
                    var pistonheads = new Site
                    {
                        Name = "Pistonheads",
                        URL = "http://www.pistonheads.com",
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                                {
                                    CategoryType = CategoryType.Motors,
                                    URL = "http://classifieds.pistonheads.com/classifieds?CategoryType=used-cars&Keyword={0}&KeywordCleanedValue={0}"
                                }
                        },
                        PluginName = Constants.PLUGIN_PISTONHEADS,
                        Enabled = true
                    };

                    return pistonheads;

                case(13):
                    var classicCarsForSale = new Site
                    {
                        Name = "ClassicCarsForSale",
                        URL = "http://www.classiccarsforsale.co.uk/",
                        Categories = new List<SiteCategory>() 
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Motors,
                                URL = "http://www.carandclassic.co.uk/classic_cars.php?category=&make=&region=&country=&era=&advert_type=&price=&keyword={0}&S.x=0&S.y=0&S=Search"
                            }
                        },
                        PluginName = Constants.PLUGIN_CLASSICCARSFORSALE,
                        Enabled = true
                    };

                    return classicCarsForSale;

                case (14):
                    var autotrader = new Site
                    {
                        Name = "Autotrader",
                        URL = "http://www.autotrader.co.uk/",
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Motors,
                                URL = "http://www.autotrader.co.uk/search/used/cars/postcode/sw49rl/radius/1500/keywords/{0}/onesearchad/used%2Cnearlynew%2Cnew/quicksearch/true"
                       
                            }
                        },
                        PluginName = Constants.PLUGIN_AUTOTRADER,
                        Enabled = true
                    };

                    return autotrader;
                case (15):
                    var exchangeAndMart = new Site
                    {
                        Name = "Exchange and Mart",
                        URL = "http://www.exchangeandmart.co.uk/",
                        PluginName = Constants.PLUGIN_EXCHANGEANDMART,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Motors,
                                URL = "http://www.exchangeandmart.co.uk/used-cars-for-sale/any-distance-from-sw49rl?keyword={0}"                
                            }
                        },
                        Enabled = true
                    };

                    return exchangeAndMart;
                case (16):
                    var jobSite = new Site
                    {
                        Name = "Jobsite",
                        URL = "http://www.jobsite.co.uk/",
                        PluginName = Constants.PLUGIN_JOBSITE,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Jobs,
                                URL = "http://www.jobsite.co.uk/cgi-bin/advsearch?search_type=quick&fp_skill_include={0}&location_include=&location_within=20&search_currency_code=GBP&search_salary_type=A&search_salary_low=ANY&search_salary_high=ANY&jobtype=E&daysback=7"
                            }
                        },
                        Enabled = true
                    };

                    return jobSite;
                case (17):
                    var cwJobs = new Site
                    {
                        Name = "CwJobs",
                        URL = "http://www.cwjobs.co.uk/",
                        PluginName = Constants.PLUGIN_CWJOBS,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                            {
                                CategoryType = CategoryType.Jobs,
                                URL = "http://www.cwjobs.co.uk/JobSearch/Results.aspx?Keywords={0}"
                            }
                        },
                        Enabled = true
                    };
                    return cwJobs;
                case (18):
                    var monster = new Site
                    {
                        Name = "Monster",
                        URL = "http://www.monster.co.uk/",
                        PluginName = Constants.PLUGIN_MONSTER,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                                {
                                    CategoryType = CategoryType.Jobs,
                                    URL = "http://jobsearch.monster.co.uk/search/{0}_5"
                                }
                        },
                        Enabled = true
                    };

                    return monster;
                case (19):
                    var reed = new Site
                    {
                        Name = "Reed",
                        URL = "http://www.reed.co.uk/",
                        PluginName = Constants.PLUGIN_REED,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                                {
                                    CategoryType = CategoryType.Jobs,
                                    URL = "http://www.reed.co.uk/jobs?keywords={0}"
                                }
                        },
                        Enabled = true
                    };

                    return reed;
                case (20):
                    var totalJobs = new Site
                    {
                        Name = "TotalJobs",
                        URL = "http://www.totaljobs.co.uk/",
                        PluginName = Constants.PLUGIN_TOTALJOBS,
                        Categories = new List<SiteCategory>()
                        {
                            new SiteCategory
                                {
                                    CategoryType = CategoryType.Jobs,
                                    URL = "http://www.totaljobs.com/JobSearch/Results.aspx?Keywords={0}"
                                }
                        },
                        Enabled = true
                    };

                    return totalJobs;
            }

            return null;
        }
    }
}

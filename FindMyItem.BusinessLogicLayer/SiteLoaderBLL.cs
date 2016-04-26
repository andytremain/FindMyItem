using System;
using System.Web.Caching;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using FindMyItem.Domain;
using FindMyItem.Common;
using FindMyItem.Common.Helpers;

namespace FindMyItem.BusinessLogicLayer
{
    public class SiteLoaderBLL
    {
        private List<Site> _activeSites = new List<Site>();
        private List<Site> _disabledSites = new List<Site>();

        public IEnumerable<Site> GetCacheSites()
        {
            List<Site> returnValue = null;

            if (HttpContext.Current.Cache.Get(Constants.CACHE_NAME) != null)
            {
                returnValue = (List<Site>)HttpContext.Current.Cache.Get(Constants.CACHE_NAME);
            }
            else
            {
                var path = CacheHelpers.GetCachePath();
                var fullPath = CacheHelpers.GetCachePathWithFilename();

                if (Directory.Exists(path))
                {
                    if (File.Exists(fullPath))
                    {
                        string json;
                        using (var sr = new StreamReader(fullPath))
                        {
                            json = sr.ReadToEnd();
                        }

                        if (string.IsNullOrEmpty(json)) throw new ApplicationException("no json found");

                        returnValue = JSON.Deserialize<List<Site>>(json); // Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(List<Site>));
                    }
                    else
                        throw new ApplicationException("Cache file does not exsits");
                }
                else
                {
                    throw new ApplicationException("Cache directory doesn't exist");
                }
            }

            if (returnValue == null)
                throw new ApplicationException("No cache found");

            return returnValue;
        }

        public IEnumerable<Site> GetSitesList(bool testLive = true)
        {
            var ebay = new Site
            {
                Name = "Ebay",
                URL = "http://www.ebay.co.uk",
                Categories = new List<SiteCategory>(),
                PluginName = Constants.PLUGIN_EBAY,
                Enabled = true
            };

            ebay.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.ebay.co.uk/sch/i.html?_trksid=p2050601.m570.l1313.TR11.TRC1.A0.Xbmw&_nkw={0}&_sacat=0&_from=R40"
            });

            ebay.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Motors,
                URL = "http://www.ebay.co.uk/sch/i.html?_trksid=p2050890.m570.l1313.TR11.TRC1.A0.Xbmw&_nkw={0}&_sacat=0&_from=R40"
            });

            AddToList(ebay, testLive);               

            var freeads = new Site
            {
                Name = "Freeads",
                URL = "http://www.freeads.co.uk",
                PluginName = Constants.PLUGIN_FREEADS,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            freeads.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.freeads.co.uk/search?for={0}"
                //CountNode = "//div[@id='top-box']//h2"
            });

            freeads.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Motors,
                URL = "http://www.freeads.co.uk/uk/buy__sell/motors/search?for={0}"
            });

            AddToList(freeads, testLive);

            var fridayAd = new Site
            {
                Name = "Friday-Ad",
                URL = "http://www.friday-ad.co.uk",
                Categories = new List<SiteCategory>(),
                PluginName = Constants.PLUGIN_FRIDAYAD,
                Enabled = true
            };

            fridayAd.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.friday-ad.co.uk/uk/search/?keywords={0}",
                CountNode = "//div[@class='sortby-area']//h1"
            });

            fridayAd.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Motors,
                URL = "http://www.friday-ad.co.uk/uk/motors/?keywords={0}",
                CountNode = "//div[@class='clearfix']//h1"
            });

            AddToList(fridayAd, testLive);              

            var gumtree = new Site
            {
                Name = "Gumtree",
                URL = "http://www.gumtree.com",
                PluginName = Constants.PLUGIN_GUMTREE,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            gumtree.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.gumtree.com/search?q={0}&category=all&search_location=&current-distance=0.0&search_scope=title"
            });

            AddToList(gumtree, testLive);                            

            var admart = new Site
            {
                Name = "Ad-Mart",
                URL = "http://www.ad-mart.co.uk",
                PluginName = Constants.PLUGIN_ADMART,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            admart.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.ad-mart.co.uk/index.php?page=search&s_res=OR&cid=0&stype=all&q={0}"
            });

            AddToList(admart, testLive);

            var newsNow = new Site
            {
                Name = "NewsNow",
                URL = "http://www.newsnow.co.uk/classifieds",
                PluginName = Constants.PLUGIN_NEWSNOW,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            newsNow.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.newsnow.co.uk/classifieds/uk/{0}.html"
            });

            AddToList(newsNow, testLive);   

            var preLoved = new Site
            {
                Name = "Pre-Loved",
                URL = "http://www.preloved.co.uk",
                PluginName = Constants.PLUGIN_PRELOVED,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            preLoved.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.preloved.co.uk/search/all?keyword={0}&x=25&y=11"
            });

            AddToList(preLoved, testLive);            

            var vivaStreet = new Site
            {
                Name = "VivaStreet",
                URL = "http://www.vivastreet.co.uk",
                PluginName = Constants.PLUGIN_VIVASTREET,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            vivaStreet.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://search.vivastreet.co.uk/search?lb=new&search=1&start_field=1&keywords={0}&main_category=0&geosearch_text=&searchGeoId=-1&end_field=1"
            });

            AddToList(vivaStreet, testLive);              

            var loot = new Site
            {
                Name = "Loot",
                URL = "http://www.loot.com",
                PluginName = Constants.PLUGIN_LOOT,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            loot.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.loot.com/ad/search?CategoryText=All+categories&category=&keyword={0}&location=&doSearch="
            });

            AddToList(loot, testLive);              

            var ukClassifieds = new Site
            {
                Name = "UK Classifieds",
                URL = "http://www.ukclassifieds.co.uk",
                PluginName = Constants.PLUGIN_UKCLASSIFIEDS,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            ukClassifieds.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.ukclassifieds.co.uk/index.php?page=search&s_res=OR&cid=0&stype=exact&q={0}"
            });

            AddToList(ukClassifieds, testLive);              

            var locanto = new Site
            {
                Name = "Locanto",
                URL = "http://www.locanto.co.uk",
                PluginName = Constants.PLUGIN_LOCANTO,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            locanto.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.locanto.co.uk/q/?query={0}&area=&geoid="
            });

            AddToList(locanto, testLive);               

            var tradeIt = new Site
            {
                Name = "Trade-IT",
                URL = "http://www.trade-it.co.uk",
                PluginName = Constants.PLUGIN_TRADEIT,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            tradeIt.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Classifieds,
                URL = "http://www.trade-it.co.uk/bristol-south-west/search/?keywords={0}"
            });

            AddToList(tradeIt, testLive);     

            GetMotorSites(testLive);
            GetJobSites(testLive);

            return _activeSites;
        }

        public bool LoadSites()
        {
            try
            {
                var allSites = GetSitesList();

                // Cache live sites
                var liveSites = allSites.Where(o => o.Enabled.Equals(true)).ToList(); 

                _disabledSites = allSites.Where(o => o.Enabled.Equals(false)).ToList(); 

                // Write cache to file
                var json = JSON.Serialize(allSites);

                var path = Path.Combine(CacheHelpers.GetCachePathWithFilename());

                if (!Directory.Exists(CacheHelpers.GetCachePath()))
                    Directory.CreateDirectory(CacheHelpers.GetCachePath());

                using (var sw = new StreamWriter(path))
                {
                    sw.Write(json);
                }
                
                HttpContext.Current.Cache.Insert(Constants.CACHE_NAME, liveSites, null, DateTime.Now.AddHours(24), Cache.NoSlidingExpiration);

                return true;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.ToString());
                return false;
            }
        }

        private void AddToList(Site site, bool testSiteLive)
        {
            if (!site.Enabled)
            {
                _disabledSites.Add(site);
                return;
            }

            // If not just add anyway for testing
            if (!testSiteLive) _activeSites.Add(site);

            if (site.Status == SiteStatus.Active)
                _activeSites.Add(site);
            else
                _disabledSites.Add(site);
        }

        private void GetMotorSites(bool testLive = true)
        {
            var pistonheads = new Site
            {
                Name = "Pistonheads",
                URL = "http://www.pistonheads.com",
                Categories = new List<SiteCategory>(),
                PluginName = Constants.PLUGIN_PISTONHEADS,
                Enabled = true
            };

            pistonheads.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Motors,
                URL = "http://classifieds.pistonheads.com/classifieds?CategoryType=used-cars&Keyword={0}&KeywordCleanedValue={0}"
            });

            AddToList(pistonheads, testLive);

            var classicCarsForSale = new Site
            {
                Name = "ClassicCarsForSale",
                URL = "http://www.classiccarsforsale.co.uk/",
                Categories = new List<SiteCategory>(),
                PluginName = Constants.PLUGIN_CLASSICCARSFORSALE,
                Enabled = true
            };

            classicCarsForSale.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Motors,
                URL = "http://www.carandclassic.co.uk/classic_cars.php?category=&make=&region=&country=&era=&advert_type=&price=&keyword={0}&S.x=0&S.y=0&S=Search"
            });

            AddToList(classicCarsForSale, testLive);

            var autotrader = new Site
            {
                Name = "Autotrader",
                URL = "http://www.autotrader.co.uk/",
                Categories = new List<SiteCategory>(),
                PluginName = Constants.PLUGIN_AUTOTRADER,
                Enabled = true
            };

            autotrader.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Motors,
                URL = "http://www.autotrader.co.uk/search/used/cars/postcode/sw49rl/radius/1500/keywords/{0}/onesearchad/used%2Cnearlynew%2Cnew/quicksearch/true"
                       
            });

            AddToList(autotrader, testLive);

            var exchangeAndMart = new Site
            {
                Name = "Exchange and Mart",
                URL = "http://www.exchangeandmart.co.uk/",
                PluginName = Constants.PLUGIN_EXCHANGEANDMART,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            exchangeAndMart.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Motors,
                URL = "http://www.exchangeandmart.co.uk/used-cars-for-sale/any-distance-from-sw49rl?keyword={0}"                
            });

            AddToList(exchangeAndMart, testLive);
        }

        private void GetJobSites(bool testLive = true)
        {
            var jobSite = new Site
            {
                Name = "Jobsite",
                URL = "http://www.jobsite.co.uk/",
                PluginName = Constants.PLUGIN_JOBSITE,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            jobSite.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Jobs,
                URL = "http://www.jobsite.co.uk/cgi-bin/advsearch?search_type=quick&fp_skill_include={0}&location_include=&location_within=20&search_currency_code=GBP&search_salary_type=A&search_salary_low=ANY&search_salary_high=ANY&jobtype=E&daysback=7"
            });

            AddToList(jobSite, testLive);

            var cwJobs = new Site
            {
                Name = "CwJobs",
                URL = "http://www.cwjobs.co.uk/",
                PluginName = Constants.PLUGIN_CWJOBS,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            cwJobs.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Jobs,
                URL = "http://www.cwjobs.co.uk/JobSearch/Results.aspx?Keywords={0}"
            });

            AddToList(cwJobs, testLive);

            var monster = new Site
            {
                Name = "Monster",
                URL = "http://www.monster.co.uk/",
                PluginName = Constants.PLUGIN_MONSTER,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            monster.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Jobs,
                URL = "http://jobsearch.monster.co.uk/search/{0}_5"
            });

            AddToList(monster, testLive);

            var reed = new Site
            {
                Name = "Reed",
                URL = "http://www.reed.co.uk/",
                PluginName = Constants.PLUGIN_REED,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            reed.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Jobs,
                URL = "http://www.reed.co.uk/jobs?keywords={0}"
            });

            AddToList(reed, testLive);

            var totalJobs = new Site
            {
                Name = "TotalJobs",
                URL = "http://www.totaljobs.co.uk/",
                PluginName = Constants.PLUGIN_TOTALJOBS,
                Categories = new List<SiteCategory>(),
                Enabled = true
            };

            totalJobs.Categories.Add(new SiteCategory
            {
                CategoryType = CategoryType.Jobs,
                URL = "http://www.totaljobs.com/JobSearch/Results.aspx?Keywords={0}"
            });

            AddToList(totalJobs, testLive);
        }
    }           
}
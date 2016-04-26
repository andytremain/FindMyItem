namespace FindMyItem.Domain
{
    public enum ESite
    {
        Ebay,
        Freeads,
        FridayAd,
        Gumtree,
        AdMart,
        NewsNow,
        Preloved,
        VivaStreet,
        Loot,
        UkClassifieds,
        Locanto,
        TradeIt,

        Pistonheads,
        ClassicCarsForSale,
        Autotrader,
        ExchangeAndMart,

        JobSite,
        CwJobs,
        Monster,
        Reed,
        TotalJobs
    }

    public enum CategoryType
    {
        Classifieds = 1,
        Motors,
        Jobs
    }

    public enum SearchMode
    {
        Standard = 1,
        Advanced = 2
    }

    public enum SiteStatus
    {
        Active = 1,
        ActiveWithError = 2,
        Disabled = 3
    }
}

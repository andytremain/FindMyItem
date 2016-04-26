namespace FindMyItem.Domain
{
    public class CacheStatus
    {
        public bool InMemory { get; set; }
        public string CachePath { get; set; }
        public bool CacheFileExists { get; set; }
    }
}

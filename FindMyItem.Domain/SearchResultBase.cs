using System;

namespace FindMyItem.Domain
{
    public abstract class SearchResultBase
    {
        public Guid Id { get; set; }
        public string Item { get; set; }
        public TimeSpan? SearchTime { get; set; }

        protected SearchResultBase()
        {
            Id = Guid.NewGuid();
        }
    }
}

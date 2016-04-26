using System;
using System.Collections.Generic;

namespace FindMyItem.Domain
{
    public class SearchModelDto
    {
        public CategoryType CategoryId { get; set; }
        public String Item { get; set; }
        public SearchResult Result { get; set; }
        public HashSet<SearchModelDto> PrevSearches { get; set; }
    }
}

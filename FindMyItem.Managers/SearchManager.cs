using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FindMyItem.Domain;
using FindMyItem.REST;

namespace FindMyItem.Managers
{
    public class SearchManager : ISearchManager
    {
        private readonly IRestCommands _restCommands;
        private readonly HashSet<SearchModelDto> _searchHistoryList;
        
        public SearchManager(IRestCommands restCommands)
        {
            _restCommands = restCommands;
            _searchHistoryList = new HashSet<SearchModelDto>();
        }

        public void AddSearch(SearchModelDto searchDto)
        {
            var selectedCategory = searchDto.CategoryId;
            var searchHistory = GetSearch(selectedCategory, searchDto.Item);

            if (searchHistory != null) _searchHistoryList.Remove(searchHistory);

            _searchHistoryList.Add(searchDto);
        }

        public HashSet<SearchModelDto> GetAllSearchHistory()
        {
            return _searchHistoryList;
        }

        public SearchModelDto GetSearch(CategoryType categoryType, string item)
        {
            return _searchHistoryList.FirstOrDefault(o => o.CategoryId.Equals(categoryType) && o.Item.Equals(item));
        }

        public void RemoveSearch(CategoryType categoryType, string item)
        {
            var deleteSearch = GetSearch(categoryType, item);

            if (deleteSearch != null) _searchHistoryList.Remove(deleteSearch);
        }

        public async Task<SearchResult> Search(string cat, string item)
        {
            return _restCommands.Search(cat, item);
        }
    }
}

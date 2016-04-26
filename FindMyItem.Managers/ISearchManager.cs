using System.Collections.Generic;
using System.Threading.Tasks;

using FindMyItem.Domain;

namespace FindMyItem.Managers
{
    public interface ISearchManager
    {
        void AddSearch(SearchModelDto sedarModelDto);
        HashSet<SearchModelDto> GetAllSearchHistory();
        SearchModelDto GetSearch(CategoryType categoryType, string item);
        void RemoveSearch(CategoryType categoryType, string item);
        Task<SearchResult> Search(string cat, string item);
    }
}
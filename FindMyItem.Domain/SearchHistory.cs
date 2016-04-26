//namespace FindMyItem.Domain
//{
//    public class SearchHistory
//    {
//        private readonly CategoryType _categoryType;
//        private readonly string _item;
//        private readonly SearchResult _result;

//        public SearchHistory(SearchModelDto modelDto)
//        {
//            _categoryType = (CategoryType)modelDto.CategoryId;
//            _item = modelDto.Item;
//        }

//        public string Item
//        {
//            get { return _item; }
//        }

//        public CategoryType CategoryType
//        {
//            get { return _categoryType; }
//        }

//        public SearchResult Result 
//        {
//            get { return _result; }
//        }
//    }
//}
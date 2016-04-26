using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

using FindMyItem.Domain;

namespace FindMyItem.WebUI.Models
{
    public class SearchViewModel
    {
        private readonly HashSet<SearchModelDto> _searchHistory;

        public SearchViewModel()
        {
            SelectedCategoryId = 1;
        }

        public SearchViewModel(string category, string item)
        {
            SelectedCategoryTypeEnum = (CategoryType)Enum.Parse(typeof(CategoryType), category, true);
            SelectedCategoryId = (int)this.SelectedCategoryTypeEnum;
            Item = item;
        }

        [Required(ErrorMessage = "No item found to search!")]
        [Display(Name = "Item: ")]
        public String Item { get; set; }

        [Display(Name = "Category: ")]
        public int SelectedCategoryId { get; set; }

        public CategoryType SelectedCategoryTypeEnum { get; set; }

        public IEnumerable<SelectListItem> Categories
        {
            get
            {
                var categories = from CategoryType o in Enum.GetValues(typeof(CategoryType))
                                 select new { ID = (int)o, Name = o.ToString() };

                return new SelectList(categories, "ID", "Name");
            }
        }

        public SearchResult SearchResult { get; set; }
        public FeedSearchResult FeedResult { get; set; }

        public HashSet<SearchModelDto> SearchHistory { get; set; }

        public static explicit operator SearchViewModel(SearchModelDto searchModelDto)
        {
            var model = new SearchViewModel()
            {
                SelectedCategoryId = (int)searchModelDto.CategoryId,
                Item = searchModelDto.Item,
                SearchResult = searchModelDto.Result,
                SearchHistory = searchModelDto.PrevSearches
            };
          
            return model;
        }

        //public SearchEnquiry ToEnquiry()
        //{
        //    var returnValue = new SearchEnquiry
        //    {
        //        CategoryId = SelectedCategoryId,
        //        Item = Item,
        //        //AdvancedSearch = AdvancedSearch
        //    };

        //    return returnValue;
        //}
    }
}
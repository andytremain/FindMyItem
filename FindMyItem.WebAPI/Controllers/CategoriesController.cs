using System.Collections.Generic;
using System.Web.Http;
using FindMyItem.Domain;

using BLL = FindMyItem.BusinessLogicLayer;

namespace FindMyItem.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return BLL.Core.GetCategories();
        }
    }
}

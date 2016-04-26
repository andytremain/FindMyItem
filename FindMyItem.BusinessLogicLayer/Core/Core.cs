using FindMyItem.Domain;
using System;
using System.Collections.Generic;

namespace FindMyItem.BusinessLogicLayer
{
    public static class Core
    {
        public static IEnumerable<Category> GetCategories()
        {
            var returnValue = new List<Category>();

            var arrEnumList = Enum.GetValues(typeof(CategoryType));

            foreach (var v in arrEnumList)
            {
                var n = Enum.GetName(typeof(CategoryType), v);
                var val = ((int)v);

                returnValue.Add(new Category() { Id = val, Name = n });
            }

            return returnValue;
        }
    }
}

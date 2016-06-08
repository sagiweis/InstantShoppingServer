using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantShoppingDataAccess;
using InstantShoppingCommon;


namespace InstantShoppingBL
{
    public class CategoriesBL
    {
        public static List<Category> GetCategories()
        {
               return CategoriesDataAccess.GetInstance().GetCategories();
        }
    }
}

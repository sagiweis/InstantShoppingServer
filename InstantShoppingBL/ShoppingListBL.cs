using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantShoppingCommon;
using InstantShoppingDataAccess;

namespace InstantShoppingBL
{
    public class ShoppingListBL
    {
        public static void AddList(ShoppingList list)
        {
            ShoppingListDataAccess.GetInstance().AddList(list);
        }

        /* public static void UpdateListStatus(string id, bool wasBought)
         {
             return ShoppingListDataAccess.GetInstance().UpdateListStatus(id,wasBought);
         }*/

        public static List<string> GetCategoriesDependecies(string MarketName)
        {
            // Create the list for the topologic sort
            Dictionary<string, List<string>> CategoryDependecies = new Dictionary<string, List<string>>();

            // TODO: Get Data from DB
            List<ProductOrder> data = new List<ProductOrder>();

            // For each row in the table for the current market
            foreach (ProductOrder curr in data)
            {
                // Checks if oposite exists
                ProductOrder oposite = data.Find(o => o.Before == curr.CategoryName && o.CategoryName == curr.Before);

                // If there is no oposite or the oposite frequency is less
                if(oposite == null || oposite.Count < curr.Count)
                {
                    // Checks if the list contains current category already
                    // If exists add the before category to the list
                    if (CategoryDependecies.ContainsKey(curr.CategoryName))
                    {
                        CategoryDependecies[curr.CategoryName].Add(curr.Before);
                    }
                    // Else create new
                    else
                    {
                        CategoryDependecies.Add(curr.CategoryName, new List<string>());
                        CategoryDependecies[curr.CategoryName].Add(curr.Before);
                    }
                }
            }

            //TODO: send to topological sort.
            return new List<string>();
        }

    }
}

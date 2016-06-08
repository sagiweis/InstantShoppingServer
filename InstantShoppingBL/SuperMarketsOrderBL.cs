
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantShoppingDataAccess;
using InstantShoppingCommon;
using TopoSortDemo4;

namespace InstantShoppingBL
{
    public class SuperMarketsOrderBL
    {
        public static void addNewProductOrder(string id, string after, List<string> before)
        {
            for (int i = 0; i < before.Count; i++)
            {
                ProductOrder productOrder = new ProductOrder(id, before[i], after);
                SuperMarketsOrderDataAccess.GetInstance().addNewProductOrder(productOrder);
            }

        }

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
                ProductOrder oposite = data.Find(o => o.CategoryBefore == curr.CategoryAfter && o.CategoryAfter == curr.CategoryBefore);

                // If there is no oposite or the oposite frequency is less
                if (oposite == null || oposite.Count < curr.Count)
                {
                    // Checks if the list contains current category already
                    // If exists add the before category to the list
                    if (CategoryDependecies.ContainsKey(curr.CategoryAfter))
                    {
                        CategoryDependecies[curr.CategoryAfter].Add(curr.CategoryBefore);
                    }
                    // Else create new
                    else
                    {
                        CategoryDependecies.Add(curr.CategoryAfter, new List<string>());
                        CategoryDependecies[curr.CategoryAfter].Add(curr.CategoryBefore);
                    }
                }
            }

            //TODO: send to topological sort.
            var actual = CategoryDependecies.TopoSort(x => x.Key, x => x.Value).ToArray();

            return new List<string>();
        }

    }
}
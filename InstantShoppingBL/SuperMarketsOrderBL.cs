
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

        public static ShoppingList GetSortedList(string GroupID, string marketID)
        {
            Group group = GroupBL.GetGroupByID(GroupID);
            ShoppingList list = group.CurrentList;
            List<Category> order = GetCategoriesDependecies(marketID);
            ShoppingList ordered = new ShoppingList();

            // Adds all products by the category order
            order.ForEach(c => ordered.ProductsList.AddRange(list.ProductsList.Where(p => c.Products.Contains(p.Name))));
            
            // Adds the rest of the products
            list.ProductsList.Where(p => !ordered.ProductsList.Contains(p)).ToList()
                /*.OrderBy(p=>p.Category).ToList()*/
                .ForEach(p=> ordered.ProductsList.Add(p));

            group.CurrentList = ordered;
            return ordered;
        }

        private static List<Category> GetCategoriesDependecies(string marketID)
        {
            // Create the list for the topologic sort
            Dictionary<string, List<string>> CategoryDependecies = new Dictionary<string, List<string>>();

            // TODO: Get Data from DB
            List<ProductOrder> data = SuperMarketsOrderDataAccess.GetInstance().GetMarketOrderRecords(marketID);

            // For each row in the table for the current market
            foreach (ProductOrder curr in data)
            {
                if (!CategoryDependecies.ContainsKey(curr.CategoryBefore))
                {
                    CategoryDependecies.Add(curr.CategoryBefore, new List<string>());
                }
                
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

            // Getting order from topological sort algo.
            List<string> actual = CategoryDependecies.TopoSort(x => x.Key, x => x.Value).ToDictionary(x => x.Key, x => x.Value).Keys.ToList();
            List<Category> categories = CategoriesBL.GetCategories();
            List<Category> filteredCategories = new List<Category>();

            foreach(Category cat in categories)
            {
                if (actual.Contains(cat.Name))
                    filteredCategories.Add(cat);
            }

            filteredCategories.Sort((a, b) => actual.IndexOf(a.Name) - actual.IndexOf(b.Name));

            return filteredCategories;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantShoppingDataAccess;
using InstantShoppingCommon;

namespace InstantShoppingBL
{
    public class GroupBL
    {
        public static List<Group> GetMyGroups(string userId)
        {
            return GroupsDataAccess.GetInstance().GetMyGroups(userId);
        }
        public static string AddGroup(Group group)
        {
            return GroupsDataAccess.GetInstance().AddGroup(group);
        }
        public static void UpdateGroupParticipents(string propertyName, List<string> value, string objectId)
        {
            GroupsDataAccess.GetInstance().UpdateGroupParticipents(propertyName, value,  objectId);
        }
        public static Group MoveListToHistory(string groupObjectId)
        {
            // Move list to history and gets the group
            Group g = GroupsDataAccess.GetInstance().MoveListToHistory(groupObjectId);

            //// If there is at least 10 history lists
            //if (g.HistoryLists.Count >= 10)
            //{
            //    // Get all the lists from the last 3 monthes
            //    List<HistoryShoppingList> lists = g.HistoryLists.Where(p => p.ShopDate > (DateTime.Today.AddMonths(-3))).ToList();

            //    List<HistoryProduct> products = new List<HistoryProduct>();
            //    lists.ForEach(l => l.ProductsList.Distinct().ToList().ForEach(p => products.Add(new HistoryProduct(p, l.ShopDate))));

            //    while(products.Count > 0)
            //    {
            //        List<HistoryProduct> curProd = products.Where(p => p.ProductName == products[0].ProductName).ToList();

            //        if (curProd.Count > 2)
            //        {
            //            int span = 0;
            //            DateTime lastDate = curProd[0].ShopDate;
            //            for(int i = 1; i < curProd.Count; i++)
            //            {
            //                span = (span + (curProd[i-1].ShopDate - curProd[i].ShopDate).Days) / i;
            //                if (curProd[i].ShopDate > lastDate)
            //                {
            //                    lastDate = curProd[i].ShopDate;
            //                }
            //            }

            //            if(g.Rules.Where(r => r.ProductName == curProd[0].ProductName).Count() > 0)
            //            {
            //                g.Rules.Where(r => r.ProductName == curProd[0].ProductName).ToList()[0].Span = span;
            //                g.Rules.Where(r => r.ProductName == curProd[0].ProductName).ToList()[0].LastBought = lastDate;
            //            }
            //            else
            //            {
            //                g.Rules.Add(new ShoppingRule(span, lastDate, curProd[0].ProductName));
            //            }
            //        }

            //        products.RemoveAll(p => p.ProductName == products[0].ProductName);
            //    }
                
            //}

            return g;
        }
    }
}

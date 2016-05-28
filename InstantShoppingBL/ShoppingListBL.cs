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

    }
}

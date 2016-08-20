using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingCommon
{
    public class HistoryShoppingList : ShoppingList
    {
        public DateTime ShopDate { get; set; }
        public HistoryShoppingList() { }
        public HistoryShoppingList(List<Product> list)
        :base(list){
            this.ShopDate = DateTime.Now;
        }
    }
}

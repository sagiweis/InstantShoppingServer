using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingCommon
{
    public class ShoppingList
    {
        public List<Product> ProductsList { get; set; }

        public ShoppingList() {
            this.ProductsList = new List<Product>();
       }

        public ShoppingList(List<Product> productsList)
        {
            this.ProductsList = productsList;
        }

    }
}

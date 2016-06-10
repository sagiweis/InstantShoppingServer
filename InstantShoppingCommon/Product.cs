using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingCommon
{
    public class Product
    { 
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public bool wasBought { get; set; }

        public Product(Product pro)
        {
            this.ProductName = pro.ProductName;
            this.Category = pro.Category;
            this.Description = pro.Description;
            this.Amount = pro.Amount;
            this.wasBought = pro.wasBought;
        }
    }

   
}

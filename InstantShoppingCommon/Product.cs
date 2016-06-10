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

        public Product(){ }
        public Product(Product prd)
        {
            this.ProductName = prd.ProductName;
            this.Category = prd.Category;
            this.Description = prd.Description;
            this.Amount = prd.Amount;
            this.wasBought = prd.wasBought;
        }
    }
}

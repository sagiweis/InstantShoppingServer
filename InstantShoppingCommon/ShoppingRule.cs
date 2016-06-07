using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingCommon
{
    public class ShoppingRule
    {
        public int Span { get; set; }
        public DateTime LastBought { get; set; }
        public String ProductName { get; set; }

        public ShoppingRule(int time, DateTime date, string name)
        {
            this.Span = time;
            this.LastBought = date;
            this.ProductName = name;
        }

        public bool CheckRule()
        {
            return ((DateTime.Today - this.LastBought).TotalDays >= this.Span);
        }
    }
}

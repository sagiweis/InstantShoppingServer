using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingCommon
{
    public class HistoryProduct : Product
    {
        public DateTime ShopDate { get; set; }

        public HistoryProduct(Product prd, DateTime date)
            : base(prd)
        {
            this.ShopDate = date;
        }
    }
}
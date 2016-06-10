using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingCommon
{
    public class ProductOrderReport
    {
        public String MarketId { set; get; }
        public List<String> CategoryBefore { set; get; }
        public String CategoryAfter { set; get; }
    }
}

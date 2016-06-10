using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;


namespace InstantShoppingCommon
{
    public class ProductOrder
    {
        public ObjectId _id { get; set; }
        public ObjectId MarketId { get; set; }
        public string CategoryBefore { get; set; }
        public string CategoryAfter { get; set; }
        public int Count { get; set; }

        public ProductOrder(string marketId, string before, string after)
    {
            this.MarketId = new ObjectId(marketId);
            this.CategoryBefore = before;
            this.CategoryAfter = after;
            this.Count = 0;
        }
    }
}

using InstantShoppingCommon;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingDataAccess
{
    public class SuperMarketsOrderDataAccess
    {
        private const string COLLECTION_NAME = "SuperMarketsOrder";
        private static SuperMarketsOrderDataAccess _instance;
        private IMongoCollection<ProductOrder> _collection;

        public SuperMarketsOrderDataAccess()
        {
            _collection = DbContext.GetInstance().GetCollection<ProductOrder>(COLLECTION_NAME);
        }

        public static SuperMarketsOrderDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SuperMarketsOrderDataAccess();
                return _instance;
            }
            else
            {
                return _instance;
            }

        }

     
        public void addNewProductOrder(ProductOrder productOrder)
        {
            var filter = Builders<ProductOrder>.Filter.Eq("MarketId", productOrder.MarketId) &
                         Builders<ProductOrder>.Filter.Eq("CategoryBefore", productOrder.CategoryBefore) &
                         Builders<ProductOrder>.Filter.Eq("CategoryAfter", productOrder.CategoryAfter);
            var result = _collection.Find(filter).FirstOrDefault<ProductOrder>(); ;
            if(result!= null)
            {
                result.Count++;
                var filter2 = Builders<ProductOrder>.Filter.Eq("_id", new ObjectId((result._id).ToString()));
                _collection.ReplaceOne(filter2, result);
            }
            else
            {
                _collection.InsertOne(productOrder);
            }

        }

       
    }
}

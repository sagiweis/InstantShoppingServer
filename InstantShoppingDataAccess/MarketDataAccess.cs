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
    public class MarketsDataAccess
    {
        private const string COLLECTION_NAME = "Markets";
        private static MarketsDataAccess _instance;
        private IMongoCollection<Market> _collection;

        public MarketsDataAccess()
        {
            _collection = DbContext.GetInstance().GetCollection<Market>(COLLECTION_NAME);
        }

        public static MarketsDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MarketsDataAccess();
                return _instance;
            }
            else
            {
                return _instance;
            }

        }


        public List<Market> GetMarkets()
        {
            var result = _collection.Find(_ => true).ToList<Market>();
            return result;
        }
    }
}

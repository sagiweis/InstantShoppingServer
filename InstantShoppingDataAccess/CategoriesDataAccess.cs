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
    public class CategoriesDataAccess
    {
        private const string COLLECTION_NAME = "Categories";
        private static CategoriesDataAccess _instance;
        private IMongoCollection<Category> _collection;

        public CategoriesDataAccess()
        {
            _collection = DbContext.GetInstance().GetCollection<Category>(COLLECTION_NAME);
        }

        public static CategoriesDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CategoriesDataAccess();
                return _instance;
            }
            else
            {
                return _instance;
            }

        }

        public List<Category> GetCategories()
        {
            var result = _collection.Find(_ => true).ToList();
               return result;
        }
    }
      
}

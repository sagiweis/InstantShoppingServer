using InstantShoppingCommon;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingDataAccess
{
    public class ShoppingListDataAccess
    {
        private const string COLLECTION_NAME = "ShoopingLists";
        private static ShoppingListDataAccess _instance;
        private IMongoCollection<ShoppingList> _collection;

        public ShoppingListDataAccess()
        {
            _collection = DbContext.GetInstance().GetCollection<ShoppingList>(COLLECTION_NAME);
        }

        public static ShoppingListDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ShoppingListDataAccess();
                return _instance;
            }
            else
            {
                return _instance;
            }

        }

        public void AddList(ShoppingList list)
        {
            _collection.InsertOne(list);
        }

        public void UpdateListStatus(string propertyName, string value, string objectId)
        {
            var filter = Builders<ShoppingList>.Filter.Eq("ObjectId", objectId);
            var update = Builders<ShoppingList>.Update
                .Set(propertyName, value);
            _collection.UpdateOneAsync(filter, update);
        }

    }

}


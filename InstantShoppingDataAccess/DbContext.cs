using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingDataAccess
{
    public class DbContext
    {
        private static DbContext _instance;
        private MongoClient _client;
        private IMongoDatabase _database;

        private DbContext(string ip, string port, string dbName)
        {
            _client = new MongoClient("mongodb://" + ip + ":" + port);
            _database = _client.GetDatabase(dbName);
        }

        public static DbContext GetInstance()
        {
            string ip = "localhost";
            string port = "27015";
            string dbName = "InstantShopping";

            if (_instance == null)
            {
                _instance = new DbContext(ip, port, dbName);
                return _instance;
            }
            else
            {
                return _instance;
            }
            
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}

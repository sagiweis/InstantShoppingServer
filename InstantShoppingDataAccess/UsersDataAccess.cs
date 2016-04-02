using InstantShoppingCommon;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingDataAccess
{
    public class UsersDataAccess
    {
        private const string COLLECTION_NAME = "Users";
        private static UsersDataAccess _instance;
        private IMongoCollection<User> _collection;

        public UsersDataAccess(){
            _collection = DbContext.GetInstance().GetCollection<User>(COLLECTION_NAME);
        }

        public static UsersDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UsersDataAccess();
                return _instance;
            }
            else
            {
                return _instance;
            }

        }

        public User GetByPhoneNumber(string phoneNumber)
        {
            return _collection.Find<User>(x => x.PhoneNumber.Equals(phoneNumber)).FirstOrDefault<User>();
        }

        public void Add(User user)
        {
            _collection.InsertOne(user);
        }

        public List<User> GetAll()
        {
            return _collection.Find<User>(Builders<User>.Filter.Empty).ToList<User>();
        }
    }
}

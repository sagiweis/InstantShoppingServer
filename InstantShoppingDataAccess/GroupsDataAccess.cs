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
    public class GroupsDataAccess
    {
        private const string COLLECTION_NAME = "Groups";
        private static GroupsDataAccess _instance;
        private IMongoCollection<Group> _collection;

        public GroupsDataAccess()
        {
            _collection = DbContext.GetInstance().GetCollection<Group>(COLLECTION_NAME);
        }

        public static GroupsDataAccess GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GroupsDataAccess();
                return _instance;
            }
            else
            {
                return _instance;
            }

        }

        public Group AddGroup(Group group)
        {
            group._id = new ObjectId();
            _collection.InsertOne(group);
            return group;
        }


        public List<Group> GetMyGroups(string userId)
        {
            var filter = Builders<Group>.Filter.AnyEq(x => x.Participents, userId);
            var result = _collection.Find(filter).ToList<Group>();
            return result;
        }

        public void UpdateGroupParticipents(string propertyName, List<string> value, string objectId)
        {
            var filter = Builders<Group>.Filter.Eq("_id", new ObjectId(objectId));
            var update = Builders<Group>.Update
                .Set(propertyName, value);
            _collection.UpdateOne(filter, update);

        }

        public Group MoveListToHistory(string groupObjectId)
        {
            Group myGroup = GetGroup(groupObjectId);
            List<HistoryShoppingList> currHistoryList = myGroup.HistoryLists;
            currHistoryList.Add(new HistoryShoppingList(myGroup.CurrentList.ProductsList));
            myGroup.CurrentList = new ShoppingList();
            myGroup.HistoryLists = currHistoryList;
            SaveGroup(groupObjectId, myGroup);
            return myGroup;
        }

        public void AddProduct(string groupObjectId, Product product)
        {
            Group myGroup = GetGroup(groupObjectId);
            myGroup.CurrentList.ProductsList.Add(product);
            SaveGroup(groupObjectId, myGroup);

        }
        public void UpdateProduct(string groupObjectId, Product product)
        {
            Group myGroup = GetGroup(groupObjectId);
            for(int i=0; i<myGroup.CurrentList.ProductsList.Count; i++)
            {
                if (myGroup.CurrentList.ProductsList[i].ProductName == product.ProductName)
                {
                    myGroup.CurrentList.ProductsList[i].Amount = product.Amount;
                    myGroup.CurrentList.ProductsList[i].Description = product.Description;
                    break;
                }
            }
            SaveGroup(groupObjectId, myGroup);

        }

        public Group GetGroup(string groupObjectId)
        {
            var filter = Builders<Group>.Filter.Eq("_id", new ObjectId(groupObjectId));
            return _collection.Find<Group>(filter).FirstOrDefault<Group>();
        }
        public void SaveGroup(string groupObjectId, Group group)
        {
            var filter = Builders<Group>.Filter.Eq("_id", new ObjectId(groupObjectId));
            _collection.ReplaceOne(filter, group);
        }
    }
}

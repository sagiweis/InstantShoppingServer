using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace InstantShoppingCommon
{
    public class Group
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public List<string> Participents { get; set; }
        public ShoppingList CurrentList { get; set; }
        public List<HistoryShoppingList> HistoryLists { get; set; }



        public Group(string name, string imageURL, List<string> participents)
        {
            this.Name = name;
            this.ImageURL = imageURL;
            this.Participents = participents;
            this.CurrentList = new ShoppingList();
            this.HistoryLists = new List<HistoryShoppingList>();
        }

    }
}

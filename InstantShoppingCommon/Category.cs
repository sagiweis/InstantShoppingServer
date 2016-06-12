using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using InstantShoppingCommon.Converters;

namespace InstantShoppingCommon
{
    public class Category
    {
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public List<string> Products { get; set; }
    }
}

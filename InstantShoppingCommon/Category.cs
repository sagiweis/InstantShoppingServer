﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace InstantShoppingCommon
{
    public class Category
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public List<string> Products { get; set; }
    }
}

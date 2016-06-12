using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstantShoppingCommon;
using InstantShoppingBL;
using Newtonsoft.Json;

namespace InstantShoppingWebAPI
{
    public class CategoriesController : ApiController
    {
        [HttpGet]
        public List<Category> GetCategories()
        {
            return CategoriesBL.GetCategories();
        }


    }
}
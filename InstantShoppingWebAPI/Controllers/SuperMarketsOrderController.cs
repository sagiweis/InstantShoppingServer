using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstantShoppingCommon;
using InstantShoppingBL;
using Newtonsoft.Json;




namespace InstantShoppingWebAPI.Controllers
{
    public class SuperMarketsOrderController : ApiController
    {
        [HttpGet]
        public void AddNewProductOrder(string id,string after, string before)
        {
            SuperMarketsOrderBL.addNewProductOrder(id, after, JsonConvert.DeserializeObject<List<string>>(before));
        }

        [HttpGet]
        public List<string> GetProductsOrder(string marketID)
        {
            return SuperMarketsOrderBL.GetCategoriesDependecies(marketID);
        }
    }
}
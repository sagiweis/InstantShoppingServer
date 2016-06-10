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
        [HttpPost]
        public void AddNewProductOrder([FromBody]ProductOrderReport report)
        {
            SuperMarketsOrderBL.addNewProductOrder(report.MarketId, report.CategoryAfter, report.CategoryBefore);
        }

        [HttpGet]
        public ShoppingList GetOrderedList (string groupID, string marketID)
        {
            return SuperMarketsOrderBL.GetSortedList(groupID, marketID);
        }
    }
}
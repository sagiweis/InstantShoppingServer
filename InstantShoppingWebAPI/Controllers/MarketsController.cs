using InstantShoppingCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstantShoppingBL;

namespace InstantShoppingWebAPI.Controllers
{
    public class MarketsController : ApiController
    {
        [HttpGet]
        public List<Market> GetMarkets()
        {
            return MarketBL.GetMarkets();
        }
    }
}

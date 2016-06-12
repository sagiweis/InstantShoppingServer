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
    public class RecommendationsController : ApiController
    {
        [HttpGet]
        public Dictionary<string, double> GetRecommendations(string groupId)
        {
            return RecommendationsBL.GetRecommendations(groupId);
            
        }

    }
}
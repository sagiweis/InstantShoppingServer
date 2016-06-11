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
    public class GroupController : ApiController
    {
        [HttpGet]
        public static string AddGroup(string name,string imageUrl, string participents)
        {
            Group newGroup = new Group(name, imageUrl, JsonConvert.DeserializeObject<List<string>>(participents));
            return GroupBL.AddGroup(newGroup);
        }

        [HttpGet]
        public List<Group> GetMyGroups(string userId)
        {
           return GroupBL.GetMyGroups(userId);
            
        }

        [HttpGet]
        public void UpdateParticipents(string newParticpents, string objectId)
        {
            GroupBL.UpdateGroupParticipents("Participents", JsonConvert.DeserializeObject<List<string>>(newParticpents), objectId);

        }

        [HttpGet]
        public Group MoveListToHistory(string objectId)
        {
            return GroupBL.MoveListToHistory(objectId);

        }
        [HttpGet]
        public void AddProduct(string objectIdGroup,string name,string category,string desc,string amount)
        {
             GroupBL.AddProduct(objectIdGroup,new Product(name,category,desc,Convert.ToDouble(amount)));

        }

    }
}
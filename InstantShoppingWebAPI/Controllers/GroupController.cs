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
        [HttpPost]
        public void UpdateGroup([FromBody]Group group)
        {
            GroupBL.UpdateGroup(group);
        }

        [HttpGet]
        public Group GetGroupById(string groupId)
        {
            return GroupBL.GetGroupByID(groupId);
        }

        [HttpPost]
        public Group AddGroup([FromBody]Group group)
        {
            return GroupBL.AddGroup(group);
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

        /*[HttpGet]
        public Group MoveListToHistory(string objectId)
        {
            return GroupBL.MoveListToHistory(objectId);
        }
        [HttpGet]
        public void AddProduct(string objectIdGroup,string name,string category,string desc,string amount)
        {
             GroupBL.AddProduct(objectIdGroup,new Product(name,category,desc,Convert.ToDouble(amount)));

        }*/

    }
}
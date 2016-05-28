﻿using System;
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
        public void AddGroup(string name,string imageUrl, string participents)
        {
            Group newGroup = new Group(name, imageUrl, JsonConvert.DeserializeObject<List<string>>(participents));
            GroupBL.AddGroup(newGroup);
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
        public void MoveListToHistory(string objectId)
        {
            GroupBL.MoveListToHistory(objectId);

        }

    }
}
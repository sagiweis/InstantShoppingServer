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
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IEnumerable<string> Get()
        {
            List<User> users = UsersBL.GetAll();
            List<string> usersAsStrings = new List<string>();
            users.ForEach(x => usersAsStrings.Add(JsonConvert.SerializeObject(x)));
            return usersAsStrings;
        }

        // GET: api/Users/5
        public string Get(string phoneNumber)
        {
            User currUser = UsersBL.GetByPhoneNumber(phoneNumber);
            return JsonConvert.SerializeObject(currUser);
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}

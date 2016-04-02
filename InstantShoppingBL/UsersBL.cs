using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantShoppingDataAccess;
using InstantShoppingCommon;

namespace InstantShoppingBL
{
    public class UsersBL
    {
        public static void Add(User usr)
        {
            UsersDataAccess.GetInstance().Add(usr);
        }

        public static List<User> GetAll()
        {
            return UsersDataAccess.GetInstance().GetAll();
        }

        public static User GetByPhoneNumber(string phoneNumber)
        {
            return UsersDataAccess.GetInstance().GetByPhoneNumber(phoneNumber);
        }
    }
}

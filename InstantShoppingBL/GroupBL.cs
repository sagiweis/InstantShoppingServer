using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantShoppingDataAccess;
using InstantShoppingCommon;

namespace InstantShoppingBL
{
    public class GroupBL
    {
        public static List<Group> GetMyGroups(string userId)
        {
            return GroupsDataAccess.GetInstance().GetMyGroups(userId);
        }
        public static Group AddGroup(Group group)
        {
            return GroupsDataAccess.GetInstance().AddGroup(group);
        }
        public static void UpdateGroupParticipents(string propertyName, List<string> value, string objectId)
        {
            GroupsDataAccess.GetInstance().UpdateGroupParticipents(propertyName, value,  objectId);
        }
        public static Group MoveListToHistory(string groupObjectId)
        {
            // Move list to history and gets the group
            Group g = GroupsDataAccess.GetInstance().MoveListToHistory(groupObjectId);
            return g;
        }

        public static Group GetGroupByID (string groupObjectId)
        {
            return GroupsDataAccess.GetInstance().GetGroup(groupObjectId);
        }

        public static void AddProduct(string groupObjectId,Product product)
        {
             GroupsDataAccess.GetInstance().AddProduct(groupObjectId,product);
        }

        public static void UpdateGroup(Group group)
        {
            GroupsDataAccess.GetInstance().UpdateGroup(group);
        }
    }
}

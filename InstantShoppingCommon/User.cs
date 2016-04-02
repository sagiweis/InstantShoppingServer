using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantShoppingCommon
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageURI { get; set; }

        public User(string firstName, string lastName, string phoneNumber, string imageURI)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = phoneNumber;
            this.ImageURI = imageURI;
        }
    }
}

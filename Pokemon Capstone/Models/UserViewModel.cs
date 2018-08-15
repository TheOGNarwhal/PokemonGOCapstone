using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon_Capstone.Models
{
    public class UserViewModel
    {
        public UserPO SingleUser { get; set; }
        public List<UserPO> UserList { get; set; }

        public UserViewModel()
        {
            SingleUser = new UserPO();
            UserList = new List<UserPO>();
        }
    }
}
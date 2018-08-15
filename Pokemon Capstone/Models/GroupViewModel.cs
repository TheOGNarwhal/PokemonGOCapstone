using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon_Capstone.Models
{
    public class GroupViewModel
    {
        public GroupPO SingleGroup { get; set; }
        public List<GroupPO> GroupList { get; set; }

        public GroupViewModel()
        {
            SingleGroup = new GroupPO();
            GroupList = new List<GroupPO>();
        }
    }
}
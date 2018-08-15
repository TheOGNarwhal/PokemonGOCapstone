using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessObjects
{
    public class GroupDAO
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupLeader { get; set; }
        public int GroupLeaderID { get; set; }
        public string Description { get; set; }
    }
}

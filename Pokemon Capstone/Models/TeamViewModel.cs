using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon_Capstone.Models
{
    public class TeamViewModel
    {
        public TeamPO SingleTeam { get; set; }
        public List<TeamPO> TeamList { get; set; }

        public TeamViewModel()
        {
            SingleTeam = new TeamPO();
            TeamList = new List<TeamPO>();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon_Capstone.Models
{
    public class GroupPO
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupLeader { get; set; }
        public int GroupLeaderID { get; set; }
        public string Description { get; set; }
    }
}
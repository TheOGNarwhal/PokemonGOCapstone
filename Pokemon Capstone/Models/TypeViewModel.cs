using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokemon_Capstone.Models
{
    public class TypeViewModel
    {
        public TypePO SingleType { get; set; }
        public List<TypePO> TypeList { get; set; }

        public TypeViewModel()
        {
            SingleType = new TypePO();
            TypeList = new List<TypePO>();
        }
        
    }
}
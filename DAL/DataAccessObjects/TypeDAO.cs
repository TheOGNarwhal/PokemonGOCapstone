using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessObjects
{
    public class TypeDAO
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public decimal xNormal { get; set; }
        public decimal xFire { get; set; }
        public decimal xWater { get; set; }
        public decimal xGrass { get; set; }
        public decimal xElectric { get; set; }
        public decimal xIce { get; set; }
        public decimal xFighting { get; set; }
        public decimal xPoision { get; set; }
        public decimal xGround { get; set; }
        public decimal xFlying { get; set; }
        public decimal xPsychic { get; set; }
        public decimal xBug { get; set; }
        public decimal xRock { get; set; }
        public decimal xGhost { get; set; }
        public decimal xDragon { get; set; }
        public decimal xDark { get; set; }
        public decimal xSteel { get; set; }
        public decimal xFairy { get; set; }
        public int Max { get; set; }
        public string MaxName { get; set; }
        public int Max2 { get; set; }
        public string Max2Name { get; set; }
        public int Min { get; set; }
        public string MinName { get; set; }
        public int Min2 { get; set; }
        public string Min2Name { get; set; }
    }
}

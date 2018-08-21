using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TypeCalculator
    {
        public TypeBO Calculate(List<TypeBO> TypesToCalculate)
        {
            TypeBO BWTypes = new TypeBO();
            BWTypes.xNormal =  (decimal)1.00;
            BWTypes.xFire = (decimal)1.00;
            BWTypes.xWater = (decimal)1.00;
            BWTypes.xGrass = (decimal)1.00;
            BWTypes.xElectric = (decimal)1.00;
            BWTypes.xIce = (decimal)1.00;
            BWTypes.xFighting = (decimal)1.00;
            BWTypes.xPoision = (decimal)1.00;
            BWTypes.xGround = (decimal)1.00;
            BWTypes.xFlying = (decimal)1.00;
            BWTypes.xPsychic = (decimal)1.00;
            BWTypes.xBug = (decimal)1.00;
            BWTypes.xRock = (decimal)1.00;
            BWTypes.xGhost = (decimal)1.00;
            BWTypes.xDragon = (decimal)1.00;
            BWTypes.xDark = (decimal)1.00;
            BWTypes.xSteel = (decimal)1.00;
            BWTypes.xFairy = (decimal)1.00;
            foreach (TypeBO Types in TypesToCalculate)
            {
                if (Types.TypeID != 19)
                {
                    if (Types.xNormal != 0)
                    {
                        BWTypes.xNormal = Types.xNormal * BWTypes.xNormal;
                    }
                    if (Types.xFire != 0)
                    {
                        BWTypes.xFire = Types.xFire * BWTypes.xFire;
                    }
                    if (Types.xWater != 0)
                    {
                        BWTypes.xWater = Types.xWater * BWTypes.xWater;
                    }
                    if (Types.xGrass != 0)
                    {
                        BWTypes.xGrass = Types.xGrass * BWTypes.xGrass;
                    }
                    if (Types.xElectric != 0)
                    {
                        BWTypes.xElectric = Types.xElectric * BWTypes.xElectric;
                    }
                    if (Types.xIce != 0)
                    {
                        BWTypes.xIce = Types.xIce * BWTypes.xIce;
                    }
                    if (Types.xFighting != 0)
                    {
                        BWTypes.xFighting = Types.xFighting * BWTypes.xFighting;
                    }
                    if (Types.xPoision != 0)
                    {
                        BWTypes.xPoision = Types.xPoision * BWTypes.xPoision;
                    }
                    if (Types.xGround != 0)
                    {
                        BWTypes.xGround = Types.xGround * BWTypes.xGround;
                    }
                    if (Types.xFlying != 0)
                    {
                        BWTypes.xFlying = Types.xFlying * BWTypes.xFlying;
                    }
                    if (Types.xPsychic != 0)
                    {
                        BWTypes.xPsychic = Types.xPsychic * BWTypes.xPsychic;
                    }
                    if (Types.xBug != 0)
                    {
                        BWTypes.xBug = Types.xBug * BWTypes.xBug;
                    }
                    if (Types.xRock != 0)
                    {
                        BWTypes.xRock = Types.xRock * BWTypes.xRock;
                    }
                    if (Types.xGhost != 0)
                    {
                        BWTypes.xGhost = Types.xGhost * BWTypes.xGhost;
                    }
                    if (Types.xDragon != 0)
                    {
                        BWTypes.xDragon = Types.xDragon * BWTypes.xDragon;
                    }
                    if (Types.xDark != 0)
                    {
                        BWTypes.xDark = Types.xDark * BWTypes.xDark;
                    }
                    if (Types.xSteel != 0)
                    {
                        BWTypes.xSteel = Types.xSteel * BWTypes.xSteel;
                    }
                    if (Types.xFairy != 0)
                    {
                        BWTypes.xFairy = Types.xFairy * BWTypes.xFairy;
                    }
                }
                else
                {
                    //Nothing Should Happen as 19 is Assigned to NONE My placeholder Type
                }
            }
            return BWTypes;
        }
    }
}

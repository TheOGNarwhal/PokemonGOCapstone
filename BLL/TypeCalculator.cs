using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TypeCalculator
    {
        //Create a new method to Calculate the best and worst Type Match-up
        public TypeBO Calculate(List<TypeBO> TypesToCalculate)
        {
            //Create a new instance of the TypeBO Object
            TypeBO BWTypes = new TypeBO();
            //Set the default values for the damage multipliers for the types
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
            //Loop through the list of Types passed as a parameter and multiply the multiplier for each type to the current value in the BWTypes object
            foreach (TypeBO Types in TypesToCalculate)
            {
                //Check to see if the given type is the place holder type that has no value
                if (Types.TypeID != 19)
                {
                    //The != 0 are to check for null values as they would ruin the multiplication process
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
            //Create a new Decimal List to Store the Newly calculated values
            List<Decimal> BestWorst = new List<Decimal>();
            //Create a new object for the decimal list and assign it value for each type in the type list, than add it to overall list
            decimal Normal = BWTypes.xNormal;
            BestWorst.Add(Normal);
            decimal Fire = BWTypes.xFire;
            BestWorst.Add(Fire);
            decimal Water = BWTypes.xWater;
            BestWorst.Add(Water);
            decimal Grass = BWTypes.xGrass;
            BestWorst.Add(Grass);
            decimal Electric = BWTypes.xElectric;
            BestWorst.Add(Electric);
            decimal Ice = BWTypes.xIce;
            BestWorst.Add(Ice);
            decimal Fighting = BWTypes.xFighting;
            BestWorst.Add(Fighting);
            decimal Poision = BWTypes.xPoision;
            BestWorst.Add(Poision);
            decimal Ground = BWTypes.xGround;
            BestWorst.Add(Ground);
            decimal Flying = BWTypes.xFlying;
            BestWorst.Add(Flying);
            decimal Psychic = BWTypes.xPsychic;
            BestWorst.Add(Psychic);
            decimal Bug = BWTypes.xBug;
            BestWorst.Add(Bug);
            decimal Rock = BWTypes.xRock;
            BestWorst.Add(Rock);
            decimal Ghost = BWTypes.xGhost;
            BestWorst.Add(Ghost);
            decimal Dragon = BWTypes.xDragon;
            BestWorst.Add(Dragon);
            decimal Dark = BWTypes.xDark;
            BestWorst.Add(Dark);
            decimal Steel = BWTypes.xSteel;
            BestWorst.Add(Steel);
            decimal Fairy = BWTypes.xFairy;
            BestWorst.Add(Fairy);
            //Create a new instance of the TypeBO Object
            TypeBO ChosenTypes = new TypeBO();
            //Check to see what the highest and lowest values are in the Decimal list, than assign the value of the highest and lowest value
            //If two values are the same, the second will be caught and will be added to the secondary value slot via the else if statements
            if (BestWorst.Max() == Normal)
            {
                ChosenTypes.Max = 1;
                ChosenTypes.MaxName = "Normal";
            }
            if (BestWorst.Max() == Fire & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 2;
                ChosenTypes.MaxName = "Fire";
            }
            else if (BestWorst.Max() == Fire)
            {
                ChosenTypes.Max2 = 2;
                ChosenTypes.Max2Name = "Fire";
            }
            if (BestWorst.Max() == Water & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 3;
                ChosenTypes.MaxName = "Water";
            }
            else if (BestWorst.Max() == Water)
            {
                ChosenTypes.Max2 = 3;
                ChosenTypes.Max2Name = "Water";
            }
            if (BestWorst.Max() == Grass & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 4;
                ChosenTypes.MaxName = "Grass";
            }
            else if (BestWorst.Max() == Grass)
            {
                ChosenTypes.Max2 = 4;
                ChosenTypes.Max2Name = "Grass";
            }
            if (BestWorst.Max() == Electric & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 5;
                ChosenTypes.MaxName = "Electric";
            }
            else if (BestWorst.Max() == Electric)
            {
                ChosenTypes.Max2 = 5;
                ChosenTypes.Max2Name = "Electric";
            }
            if (BestWorst.Max() == Ice & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 6;
                ChosenTypes.MaxName = "Ice";
            }
            else if (BestWorst.Max() == Ice)
            {
                ChosenTypes.Max2 = 6;
                ChosenTypes.Max2Name = "Ice";
            }
            if (BestWorst.Max() == Fighting & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 7;
                ChosenTypes.MaxName = "Fighting";
            }
            else if (BestWorst.Max() == Fighting)
            {
                ChosenTypes.Max2 = 7;
                ChosenTypes.Max2Name = "Fighting";
            }
            if (BestWorst.Max() == Poision & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 8;
                ChosenTypes.MaxName = "Poision";
            }
            else if (BestWorst.Max() == Poision)
            {
                ChosenTypes.Max2 = 8;
                ChosenTypes.Max2Name = "Poision";
            }
            if (BestWorst.Max() == Ground & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 9;
                ChosenTypes.MaxName = "Ground";
            }
            else if (BestWorst.Max() == Ground)
            {
                ChosenTypes.Max2 = 9;
                ChosenTypes.Max2Name = "Ground";
            }
            if (BestWorst.Max() == Flying & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 10;
                ChosenTypes.MaxName = "Flying";
            }
            else if (BestWorst.Max() == Flying)
            {
                ChosenTypes.Max2 = 10;
                ChosenTypes.Max2Name = "Flying";
            }
            if (BestWorst.Max() == Psychic & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 11;
                ChosenTypes.MaxName = "Psychic";
            }
            else if (BestWorst.Max() == Psychic)
            {
                ChosenTypes.Max2 = 11;
                ChosenTypes.Max2Name = "Psychic";
            }
            if (BestWorst.Max() == Bug & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 12;
                ChosenTypes.MaxName = "Bug";
            }
            else if (BestWorst.Max() == Bug)
            {
                ChosenTypes.Max2 = 12;
                ChosenTypes.Max2Name = "Bug";
            }
            if (BestWorst.Max() == Rock & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 13;
                ChosenTypes.MaxName = "Rock";
            }
            else if (BestWorst.Max() == Rock)
            {
                ChosenTypes.Max2 = 13;
                ChosenTypes.Max2Name = "Rock";
            }
            if (BestWorst.Max() == Ghost & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 14;
                ChosenTypes.MaxName = "Ghost";
            }
            else if (BestWorst.Max() == Ghost)
            {
                ChosenTypes.Max2 = 14;
                ChosenTypes.Max2Name = "Ghost";
            }
            if (BestWorst.Max() == Dragon & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 15;
                ChosenTypes.MaxName = "Dragon";
            }
            else if (BestWorst.Max() == Dragon)
            {
                ChosenTypes.Max2 = 15;
                ChosenTypes.Max2Name = "Dragon";
            }
            if (BestWorst.Max() == Dark & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 16;
                ChosenTypes.MaxName = "Dark";
            }
            else if (BestWorst.Max() == Dark)
            {
                ChosenTypes.Max2 = 16;
                ChosenTypes.Max2Name = "Dark";
            }
            if (BestWorst.Max() == Steel & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 17;
                ChosenTypes.MaxName = "Steel";
            }
            else if (BestWorst.Max() == Steel)
            {
                ChosenTypes.Max2 = 17;
                ChosenTypes.Max2Name = "Steel";
            }
            if (BestWorst.Max() == Fairy & ChosenTypes.MaxName == null)
            {
                ChosenTypes.Max = 18;
                ChosenTypes.MaxName = "Fairy";
            }
            else if (BestWorst.Max() == Fairy)
            {
                ChosenTypes.Max2 = 18;
                ChosenTypes.Max2Name = "Fairy";
            }
            if (BestWorst.Min() == Normal)
            {
                ChosenTypes.Min = 1;
                ChosenTypes.MinName = "Normal";
            }
            if (BestWorst.Min() == Fire & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 2;
                ChosenTypes.MinName = "Fire";
            }
            else if (BestWorst.Min() == Fire)
            {
                ChosenTypes.Min2 = 2;
                ChosenTypes.Min2Name = "Fire";
            }
            if (BestWorst.Min() == Water & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 3;
                ChosenTypes.MinName = "Water";
            }
            else if (BestWorst.Min() == Water)
            {
                ChosenTypes.Min2 = 3;
                ChosenTypes.Min2Name = "Water";
            }
            if (BestWorst.Min() == Grass & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 4;
                ChosenTypes.MinName = "Grass";
            }
            else if (BestWorst.Min() == Grass)
            {
                ChosenTypes.Min2 = 4;
                ChosenTypes.Min2Name = "Grass";
            }
            if (BestWorst.Min() == Electric & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 5;
                ChosenTypes.MinName = "Electric";
            }
            else if (BestWorst.Min() == Electric)
            {
                ChosenTypes.Min2 = 5;
                ChosenTypes.Min2Name = "Electric";
            }
            if (BestWorst.Min() == Ice & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 6;
                ChosenTypes.MinName = "Ice";
            }
            else if (BestWorst.Min() == Ice)
            {
                ChosenTypes.Min2 = 6;
                ChosenTypes.Min2Name = "Ice";
            }
            if (BestWorst.Min() == Fighting & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 7;
                ChosenTypes.MinName = "Fighting";
            }
            else if (BestWorst.Min() == Fighting)
            {
                ChosenTypes.Min2 = 7;
                ChosenTypes.Min2Name = "Fighting";
            }
            if (BestWorst.Min() == Poision & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 8;
                ChosenTypes.MinName = "Poision";
            }
            else if (BestWorst.Min() == Poision)
            {
                ChosenTypes.Min2 = 8;
                ChosenTypes.Min2Name = "Poision";
            }
            if (BestWorst.Min() == Ground & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 9;
                ChosenTypes.MinName = "Ground";
            }
            else if (BestWorst.Min() == Ground)
            {
                ChosenTypes.Min2 = 9;
                ChosenTypes.Min2Name = "Ground";
            }
            if (BestWorst.Min() == Flying & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 10;
                ChosenTypes.MinName = "Flying";
            }
            else if (BestWorst.Min() == Flying)
            {
                ChosenTypes.Min2 = 10;
                ChosenTypes.Min2Name = "Flying";
            }
            if (BestWorst.Min() == Psychic & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 11;
                ChosenTypes.MinName = "Psychic";
            }
            else if (BestWorst.Min() == Psychic)
            {
                ChosenTypes.Min2 = 11;
                ChosenTypes.Min2Name = "Psychic";
            }
            if (BestWorst.Min() == Bug & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 12;
                ChosenTypes.MinName = "Bug";
            }
            else if (BestWorst.Min() == Bug)
            {
                ChosenTypes.Min2 = 12;
                ChosenTypes.Min2Name = "Bug";
            }
            if (BestWorst.Min() == Rock & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 13;
                ChosenTypes.MinName = "Rock";
            }
            else if (BestWorst.Min() == Rock)
            {
                ChosenTypes.Min2 = 13;
                ChosenTypes.Min2Name = "Rock";
            }
            if (BestWorst.Min() == Ghost & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 14;
                ChosenTypes.MinName = "Ghost";
            }
            else if (BestWorst.Min() == Ghost)
            {
                ChosenTypes.Min2 = 14;
                ChosenTypes.Min2Name = "Ghost";
            }
            if (BestWorst.Min() == Dragon & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 15;
                ChosenTypes.MinName = "Dragon";
            }
            else if (BestWorst.Min() == Dragon)
            {
                ChosenTypes.Min2 = 15;
                ChosenTypes.Min2Name = "Dragon";
            }
            if (BestWorst.Min() == Dark & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 16;
                ChosenTypes.MinName = "Dark";
            }
            else if (BestWorst.Min() == Dark)
            {
                ChosenTypes.Min2 = 16;
                ChosenTypes.Min2Name = "Dark";
            }
            if (BestWorst.Min() == Steel & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 17;
                ChosenTypes.MinName = "Steel";
            }
            else if (BestWorst.Min() == Steel)
            {
                ChosenTypes.Min2 = 17;
                ChosenTypes.Min2Name = "Steel";
            }
            if (BestWorst.Min() == Fairy & ChosenTypes.MinName == null)
            {
                ChosenTypes.Min = 18;
                ChosenTypes.MinName = "Fairy";
            }
            else if (BestWorst.Min() == Fairy)
            {
                ChosenTypes.Min2 = 18;
                ChosenTypes.Min2Name = "Fairy";
            }
            //Assign the newly found values to the BWTypes object for all maxs and mins
            BWTypes.Max = ChosenTypes.Max;
            BWTypes.Max2 = ChosenTypes.Max2;
            BWTypes.MaxName = ChosenTypes.MaxName;
            BWTypes.Max2Name = ChosenTypes.Max2Name;
            BWTypes.Min = ChosenTypes.Min;
            BWTypes.Min2 = ChosenTypes.Min2;
            BWTypes.MinName = ChosenTypes.MinName;
            BWTypes.Min2Name = ChosenTypes.Min2Name;
            //Send back the newly calculated Values
            return BWTypes;
        }
    }
}

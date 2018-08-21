using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pokemon_Capstone.Models;
using DAL;
using DAL.DataAccessObjects;

namespace Pokemon_Capstone.Controllers
{
    public class TeamController : Controller
    {
        //Create a new instance of the mapper calss 
        Mapper mapper = new Mapper();
        //Create a new instance of the TeamDataAccess model
        TeamDataAccess teamData = new TeamDataAccess();
        //create a new instance of the PokemonDataAccess model
        PokemonDataAccess PokemonData = new PokemonDataAccess();
        //Create a new instance of the UserDataAccess model
        UserDataAccess UserData = new UserDataAccess();
        // GET: Team
        [HttpGet]
        public ActionResult UserTeams()
        {
            TeamDAO UserToGet = new TeamDAO();
            UserToGet.CreatorID = (int)Session["UserID"];
            TeamViewModel TeamModel = new TeamViewModel();
            TeamModel.TeamList = mapper.TeamsMap(teamData.SelectUserTeams(UserToGet));
            return View(TeamModel);
        }
        [HttpGet]
        public ActionResult DeleteTeam(int deleteID)
        {
            TeamDAO ChosenTeam = new TeamDAO();
            ChosenTeam.TeamID = deleteID;
            teamData.DeleteTeam(ChosenTeam);
            return RedirectToAction("UserTeams");
        }
        [HttpGet]
        public ActionResult CreateTeam()
        {
            PopulateDropDowns();
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeam(TeamPO Create)
        {
            PopulateDropDowns();
            Create.CreatorID = (int)Session["UserID"];
            teamData.CreateTeam(mapper.SingleTeamMap(Create));
            return RedirectToAction("UserTeams");
        }
        [HttpGet]
        public ActionResult ViewTeam(int ViewID)
        {
            PopulateDropDowns();
            TeamDAO ChosenTeam = new TeamDAO();
            ChosenTeam.TeamID = ViewID;
            TeamPO MappedTeam = mapper.SelectTeamMap(teamData.SelectTeam(ChosenTeam));
            List<int> chosenTypes = mapper.TypeIDMap(MappedTeam);
            TypeDAO FinalValues = teamData.CalculateTypes(chosenTypes);
            TypePO Final = Calculate(FinalValues);
            MappedTeam.Max = Final.Max;
            MappedTeam.MaxName = Final.MaxName;
            MappedTeam.Max2Name = Final.Max2Name;
            MappedTeam.Min = Final.Min;
            MappedTeam.MinName = Final.MinName;
            MappedTeam.Min2Name = Final.Min2Name;
            return View(MappedTeam);
        }
        [HttpPost]
        public ActionResult UpdateTeam(TeamPO Update)
        {
            teamData.UpdateTeam(mapper.SingleTeamMap(Update));
            return RedirectToAction("ViewTeam", new {ViewID = Update.TeamID});
        }
        [HttpGet]
        private void PopulateDropDowns()
        {
            ViewBag.Pokemon = new List<SelectListItem>();
            List<PokemonPO> Pokemon = mapper.PokemonMap(PokemonData.GetAllPokemon());
            foreach (PokemonPO PokemonList in Pokemon)
            {
                ViewBag.Pokemon.Add(new SelectListItem { Text = PokemonList.PokemonName, Value = PokemonList.PokemonID.ToString()});
            }
        }
        [HttpGet]
        private TypePO Calculate(TypeDAO FinalValues)
        {
            List<Decimal> BestWorst = new List<Decimal>();
            decimal Normal = FinalValues.xNormal;
            BestWorst.Add(Normal);
            decimal Fire = FinalValues.xFire;
            BestWorst.Add(Fire);
            decimal Water = FinalValues.xWater;
            BestWorst.Add(Water);
            decimal Grass = FinalValues.xGrass;
            BestWorst.Add(Grass);
            decimal Electric = FinalValues.xElectric;
            BestWorst.Add(Electric);
            decimal Ice = FinalValues.xIce;
            BestWorst.Add(Ice);
            decimal Fighting = FinalValues.xFighting;
            BestWorst.Add(Fighting);
            decimal Poision = FinalValues.xPoision;
            BestWorst.Add(Poision);
            decimal Ground = FinalValues.xGround;
            BestWorst.Add(Ground);
            decimal Flying = FinalValues.xFlying;
            BestWorst.Add(Flying);
            decimal Psychic = FinalValues.xPsychic;
            BestWorst.Add(Psychic);
            decimal Bug = FinalValues.xBug;
            BestWorst.Add(Bug);
            decimal Rock = FinalValues.xRock;
            BestWorst.Add(Rock);
            decimal Ghost = FinalValues.xGhost;
            BestWorst.Add(Ghost);
            decimal Dragon = FinalValues.xDragon;
            BestWorst.Add(Dragon);
            decimal Dark = FinalValues.xDark;
            BestWorst.Add(Dark);
            decimal Steel = FinalValues.xSteel;
            BestWorst.Add(Steel);
            decimal Fairy = FinalValues.xFairy;
            BestWorst.Add(Fairy);
            TypePO ChosenTypes = new TypePO();

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
            return ChosenTypes;
        }
    }
}
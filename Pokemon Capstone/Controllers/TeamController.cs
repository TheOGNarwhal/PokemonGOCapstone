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
        //Create an action result to view all teams created by a single user
        [HttpGet]
        public ActionResult UserTeams()
        {
            TeamDAO UserToGet = new TeamDAO();
            UserToGet.CreatorID = (int)Session["UserID"];
            TeamViewModel TeamModel = new TeamViewModel();
            TeamModel.TeamList = mapper.TeamsMap(teamData.SelectUserTeams(UserToGet));
            return View(TeamModel);
        }
        //Create a Actionresult to delete a team by ID
        [HttpGet]
        public ActionResult DeleteTeam(int deleteID)
        {
            TeamDAO ChosenTeam = new TeamDAO();
            ChosenTeam.TeamID = deleteID;
            teamData.DeleteTeam(ChosenTeam);
            return RedirectToAction("UserTeams");
        }
        [HttpGet]
        public ActionResult AdminDeleteTeam(int deleteID)
        {
            TeamDAO ChosenTeam = new TeamDAO();
            ChosenTeam.TeamID = deleteID;
            teamData.DeleteTeam(ChosenTeam);
            return RedirectToAction("ViewAllTeams");
        }
        //Create an action result to send to the Create Team View
        [HttpGet]
        public ActionResult CreateTeam()
        {
            PopulateDropDowns();
            return View();
        }
        //Create a Actionresult to Create a team in the database
        [HttpPost]
        public ActionResult CreateTeam(TeamPO Create)
        {
            PopulateDropDowns();
            Create.CreatorID = (int)Session["UserID"];
            teamData.CreateTeam(mapper.SingleTeamMap(Create));
            return RedirectToAction("UserTeams");
        }
        //Create a new Action Result to view a single team by ID
        [HttpGet]
        public ActionResult ViewTeam(int ViewID)
        {
            PopulateDropDowns();
            TeamDAO ChosenTeam = new TeamDAO();
            ChosenTeam.TeamID = ViewID;
            TeamPO MappedTeam = mapper.SelectTeamMap(teamData.SelectTeam(ChosenTeam));
            List<int> chosenTypes = mapper.TypeIDMap(MappedTeam);
            TypeDAO FinalValues = teamData.CalculateTypes(chosenTypes);
            MappedTeam.MaxName = FinalValues.MaxName;
            MappedTeam.Max2Name = FinalValues.Max2Name;
            MappedTeam.MinName = FinalValues.MinName;
            MappedTeam.Min2Name = FinalValues.Min2Name;
            return View(MappedTeam);
        }
        [HttpGet]
        public ActionResult ViewAllTeams()
        {
            TeamViewModel TeamModel = new TeamViewModel();
            TeamModel.TeamList = mapper.TeamsMap(teamData.GetAllTeams());
            return View(TeamModel);
        }
        //Create a new Action result to update a team by ID
        [HttpPost]
        public ActionResult UpdateTeam(TeamPO Update)
        {
            teamData.UpdateTeam(mapper.SingleTeamMap(Update));
            return RedirectToAction("ViewTeam", new {ViewID = Update.TeamID});
        }
        //Create a new method to add values to dropdown lists
        private void PopulateDropDowns()
        {
            ViewBag.Pokemon = new List<SelectListItem>();
            List<PokemonPO> Pokemon = mapper.PokemonMap(PokemonData.GetAllPokemon());
            foreach (PokemonPO PokemonList in Pokemon)
            {
                ViewBag.Pokemon.Add(new SelectListItem { Text = PokemonList.PokemonName, Value = PokemonList.PokemonID.ToString()});
            }
        }
    }
}
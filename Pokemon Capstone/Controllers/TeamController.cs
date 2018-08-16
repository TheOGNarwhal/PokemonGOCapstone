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
            return View(MappedTeam);
        }
        [HttpPost]
        public ActionResult UpdateTeam(TeamPO Update)
        {
            teamData.UpdateTeam(mapper.SingleTeamMap(Update));
            return RedirectToAction("ViewTeam", new {ViewID = Update.TeamID});
        }
        //a change
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
    }
}
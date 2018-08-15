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
    public class PokemonController : Controller
    {
        //Create a new instance of the mapper model
        static Mapper mapper = new Mapper();
        //Create a new instance of pokemondataaccess
        static PokemonDataAccess PokemonData = new PokemonDataAccess();
        //Create a new instance of the TypeDataAccess
        static TypeDataAccess TypeData = new TypeDataAccess();
        // GET: Pokemon
        [HttpGet]
        public ActionResult ViewPokemon()
        {
            PokemonViewModel PokemonModel = new PokemonViewModel();
            PokemonModel.PokemonList = mapper.PokemonMap(PokemonData.GetAllPokemon());
            PopulateDropDowns();
            return View(PokemonModel);
        }
        [HttpGet]
        public ActionResult ReadPokemon()
        {
            PokemonViewModel PokemonModel = new PokemonViewModel();
            PokemonModel.PokemonList = mapper.PokemonMap(PokemonData.GetAllPokemon());
            return View(PokemonModel);
        }
        [HttpPost]
        public ActionResult CreatePokemon(PokemonPO newPokemon)
        {
            PokemonDAO PokemonToCreate = mapper.SinglePokemonMap(newPokemon);
            PokemonData.CreatePokemon(PokemonToCreate);
            return RedirectToAction("ViewPokemon");
        }
        [HttpPost]
        public ActionResult UpdatePokemon(PokemonPO pokemonInfo)
        {
            PokemonDAO PokemonToUpdate = mapper.SinglePokemonMap(pokemonInfo);
            PokemonData.UpdatePokemon(PokemonToUpdate);
            return RedirectToAction("ViewPokemon");
        }
        [HttpGet]
        public ActionResult DeletePokemon(int PokemonToDeleteID) 
        {
            //
            PokemonDAO pokemonOption = new PokemonDAO();
            pokemonOption.PokemonID = PokemonToDeleteID;
            PokemonData.DeletePokemon(pokemonOption);
            return RedirectToAction("ViewPokemon");
        }
        private void PopulateDropDowns()
        {
            ViewBag.Types = new List<SelectListItem>();
            List<TypePO> Types = mapper.TypeMap(TypeData.GetAllTypes());
            PokemonPO chosenpokemon = new PokemonPO();
            foreach (TypePO TypeList in Types)
            {
                    ViewBag.Types.Add(new SelectListItem { Text = TypeList.TypeName, Value = TypeList.TypeID.ToString()});
            }
        }
    }
}
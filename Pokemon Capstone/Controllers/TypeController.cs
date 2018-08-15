using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pokemon_Capstone.Models;
using DAL;

namespace Pokemon_Capstone.Controllers
{
    public class TypeController : Controller
    {
        //Create a new instance of the mapper model
        static Mapper mapper = new Mapper();
        //Create a new instance of TypeDataAccess
        static TypeDataAccess TypeData = new TypeDataAccess();
        // GET: Type
        public ActionResult ViewTypes()
        {
            TypeViewModel TypeModel = new TypeViewModel();
            TypeModel.TypeList = mapper.TypeMap(TypeData.GetAllTypes());
            return View(TypeModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pokemon_Capstone.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        [HttpGet]
        public ActionResult ViewGroups()
        {
            return View();
        }
    }
}
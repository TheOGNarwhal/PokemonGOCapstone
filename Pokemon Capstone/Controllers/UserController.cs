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
    public class UserController : Controller
    {
        //Create a new instance of the method model
        static Mapper mapper = new Mapper();
        //Create a new instance of the UserDataAccess model
        static UserDataAccess UserData = new UserDataAccess();
        //Create a new instance of the TypeDataAccess model
        static TypeDataAccess TypeData = new TypeDataAccess();
        //Create a new instance of the PokemonDataAccess model
        static PokemonDataAccess PokemonData = new PokemonDataAccess();
        //Create a new instance of the GroupDataAccess model
        static GroupDataAccess GroupData = new GroupDataAccess();
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ReLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserPO Login)
        {
            if (ModelState.IsValid)
            {
                UserDAO UserToLogin = mapper.SingleUserMap(Login);
                UserDAO ValidateUser = UserData.UserLogin(UserToLogin);
                //Put the Users value into the session variables
                Session["UserID"] = ValidateUser.UserID;
                Session["Username"] = ValidateUser.Username;
                Session["RoleName"] = ValidateUser.RoleName;
                Session["RoleID"] = ValidateUser.RoleID;
                if ((string)Session["Username"] == null)
                {
                    return RedirectToAction("ReLogin", "User");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserPO Create)
        {
            UserDAO UserToCreate = mapper.SingleUserMap(Create);
            UserData.CreateUser(UserToCreate);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult UserProfile()
        {
            UserPO UserToMap = new UserPO();
            UserToMap.UserID = (int)Session["UserID"];
            UserDAO mappedUser = UserData.SelectUser(mapper.SingleUserMap(UserToMap));
            UserPO SelectedUser = mapper.SelectUserMap(mappedUser);
            return View(SelectedUser);
        }
        [HttpGet]
        public ActionResult Alter()
        {
            PopulateDropDowns();
            UserPO UserToMap = new UserPO();
            UserToMap.UserID = (int)Session["UserID"];
            UserDAO mappedUser = UserData.SelectUser(mapper.SingleUserMap(UserToMap));
            UserPO SelectedUser = mapper.SelectUserMap(mappedUser);
            return View(SelectedUser);
        }
        [HttpPost]
        public ActionResult Alter(UserPO Update)
        {
            UserDAO UserToUpdate = mapper.SingleUserMap(Update);
            UserData.UpdateUser(UserToUpdate);
            return RedirectToAction("UserProfile");
        }
        [HttpGet]
        private void PopulateDropDowns()
        {
            ViewBag.Types = new List<SelectListItem>();
            ViewBag.Pokemon = new List<SelectListItem>();
            ViewBag.Groups = new List<SelectListItem>();
            ViewBag.Roles = new List<SelectListItem>();
            List<TypePO> Types = mapper.TypeMap(TypeData.GetAllTypes());
            List<PokemonPO> Pokemon = mapper.PokemonMap(PokemonData.GetAllPokemon());
            List<GroupPO> Groups = mapper.GroupMap(GroupData.GetAllGroups());
            foreach (TypePO TypeList in Types)
            {
                ViewBag.Types.Add(new SelectListItem { Text = TypeList.TypeName, Value = TypeList.TypeID.ToString() });
            }
            foreach (PokemonPO PokemonList in Pokemon)
            {
                ViewBag.Pokemon.Add(new SelectListItem { Text = PokemonList.PokemonName, Value = PokemonList.PokemonID.ToString() });
            }
            foreach (GroupPO GroupList in Groups)
            {
                ViewBag.Groups.Add(new SelectListItem { Text = GroupList.GroupName, Value = GroupList.GroupID.ToString() });
            }
            ViewBag.Roles.Add(new SelectListItem { Text = "Admin", Value = "3" });
            ViewBag.Roles.Add(new SelectListItem { Text = "Moderator", Value = "2" });
            ViewBag.Roles.Add(new SelectListItem { Text = "User", Value = "1" });
        }
        [HttpGet]
        public ActionResult ViewUsers()
        {
            PopulateDropDowns();
            UserViewModel UserModel = new UserViewModel();
            UserModel.UserList = mapper.UserMap(UserData.GetAllUsers());
            return View(UserModel);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserPO userInfo)
        {
            PopulateDropDowns();
            UserDAO oldUserToUpdate = mapper.SingleUserMap(userInfo);
            UserData.UpdateUser(oldUserToUpdate);
            return RedirectToAction("ViewUsers");
        }
        [HttpGet]
        public ActionResult Reset(int Reset)
        {
            UserDAO resetUser = new UserDAO();
            resetUser.UserID = Reset;
            UserData.ResetPassword(resetUser);
            return RedirectToAction("ViewUsers");
        }
        [HttpGet]
        public ActionResult DeleteUser(int UserToDeleteID)
        {
            UserDAO UserToDelete = new UserDAO();
            UserToDelete.UserID = UserToDeleteID;
            UserData.DeleteUser(UserToDelete);
            return RedirectToAction("ViewUsers");
        }
    }
}
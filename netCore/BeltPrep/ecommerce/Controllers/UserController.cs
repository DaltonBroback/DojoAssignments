using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecommerce.Models;
using ecommerce.Factory;
using Microsoft.AspNetCore.Identity;

namespace ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly UserFactory userFactory;

        public UserController(DbConnector connect)
        {
            // _dbConector = connect;
            userFactory = new UserFactory();

        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            // List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            return View("Index");
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstname, string lastname, string email, string password, string pwconfirm)
        {
            User newUser = new User{
                firstname = firstname,
                lastname = lastname,
                email = email,
                password = password,
                pwconfirm = pwconfirm
            };
            TryValidateModel(newUser);
            ViewBag.errors.Clear();
            ViewBag.errors = ModelState.Values;
            if(ModelState.IsValid){
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.password = Hasher.HashPassword(newUser,newUser.password);
                userFactory.Add(newUser);
                int userId = userFactory.GetLastId();
                HttpContext.Session.SetInt32("userId", userId);
                return RedirectToAction("Success");
            }
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LogIn(string email, string password)
        {
            @ViewBag.loginerror = "";
            User UserToCheck = userFactory.GetUserByEmail(email);
            if(UserToCheck != null && password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(UserToCheck, UserToCheck.password, password))
                {
                    int userId = userFactory.GetIdByEmail(email);
                    HttpContext.Session.SetInt32("userId", userId);
                    return RedirectToAction("Success");
                }
                @ViewBag.loginerror = "Incorrect password";
            }
                @ViewBag.loginerror = "Incorrect email address";
             ViewBag.errors = ModelState.Values;
            return RedirectToAction("Failure");
        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success(){
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("userId"));
            ViewBag.user = userFactory.GetUserById(userId);
            return RedirectToAction("Index","Store");
        }
        [HttpGet]
        [Route("failure")]
        public IActionResult Failure(){
            return View("Failure");
        }
    }
}

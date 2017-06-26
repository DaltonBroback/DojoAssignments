using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using netCoreBeltExam.Models;
using netCoreBeltExam.Factory;
using Microsoft.AspNetCore.Identity;

namespace netCoreBeltExam.Controllers
{
    public class UserController : Controller
    {
        private readonly UserFactory userFactory;

        public UserController(DbConnector connect)
        {
            userFactory = new UserFactory();

        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            ViewBag.errors = new List<string>();
            ViewBag.loginerror = new List<string>();
            return View("Index");
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(string firstname, string lastname, string email, string password, string pwconfirm, string description)
        {
            User newUser = new User
                {
                    firstname = firstname,
                    lastname = lastname,
                    email = email,
                    password = password,
                    pwconfirm = pwconfirm,
                    description = description
                };
                TryValidateModel(newUser);
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
        [HttpGet]
        [Route("login")]
        public IActionResult LoginPage()
        {
            ViewBag.errors = new List<string>();
            return View();
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
            @ViewBag.loginerror = new List<string>();
            try{
                userFactory.GetUserByEmail(email);
            }
            catch(NullReferenceException){
                ViewBag.loginerror.Add("Invalid email address");
                return View("Index");
            }
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
                return RedirectToAction("Failure");
            }
            ViewBag.loginerror.Add("Invalid email address");
            return View("Failure");
        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success(){
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("userId"));
            ViewBag.user = userFactory.GetUserById(userId);
            return RedirectToAction("Index","Exam");
        }
        [HttpGet]
        [Route("failure")]
        public IActionResult Failure(){
            return View("Failure");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using logreg.Models;
using Microsoft.AspNetCore.Http;

using System.Linq;
using System.Security.Cryptography;

namespace logreg.Controllers
{
    public class UsersController : Controller
    {
        private readonly DbConnector _dbConnector;

        public UsersController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            ViewBag.Errors = new List<string>();
            List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            return View("Index");
        }
        [HttpPost]
        [Route("register")]
        // public IActionResult Register(User model)
        // {
        public IActionResult Register(string firstname, string lastname, string email, string password, string passwordcon)
        {

            User newUser = new User{
                firstname = firstname,
                lastname = lastname,
                email = email,
                password = password,
                passwordcon = passwordcon
            };
            TryValidateModel(newUser);
            if(ModelState.IsValid){
                
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string savedPasswordHash = Convert.ToBase64String(hashBytes);

                _dbConnector.Add(firstname, lastname, email, password);
                int CurrentUserId = _dbConnector.LastUserId();
                HttpContext.Session.SetInt32("CurrentUserId", CurrentUserId);
                return RedirectToAction("Success");
            }
            ViewBag.Errors = ModelState.Values;
            return View("Index");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
            if(email != null){
            Dictionary<string,object> CurrentUser = _dbConnector.Query($"SELECT * FROM users WHERE email = '{email}' LIMIT 1;").SingleOrDefault();
  
                if ((CurrentUser["password"]).ToString() == password)
                {
                    int CurrentUserId = Convert.ToInt32(CurrentUser["id"]);
                    HttpContext.Session.SetInt32("CurrentUserId", CurrentUserId);
                    ViewBag.Name = CurrentUser["firstname"];
                    return View("Success");
                }
                System.Console.WriteLine("GOOOoooooo");
                return View("Index");
            }
            return View("Index");

        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            int? CurrentUserIdMaybe  = HttpContext.Session.GetInt32("CurrentUserId");
            int CurrentUserId = Convert.ToInt32(CurrentUserIdMaybe);
            Dictionary<string,object> CurrentUser = _dbConnector.Query($"SELECT * FROM users WHERE id = {CurrentUserId};").SingleOrDefault();
            ViewBag.Name = CurrentUser["firstname"];
            return View("Success");
        }
    }
}
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
    public class ExamController : Controller
    {
        private readonly UserFactory userFactory;
        private readonly FriendshipFactory friendshipFactory;

        public ExamController(DbConnector connect)
        {
            userFactory = new UserFactory();
            friendshipFactory = new FriendshipFactory();
        }

        [HttpGet]
        [Route("professional_profile")]
        public IActionResult Index()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("userId"));
            ViewBag.user = userFactory.GetUserById(userId);
            ViewBag.errors = new List<string>();
            ViewBag.friendids1 = friendshipFactory.GetFriendIds1(userId);
            ViewBag.friends1 = new List<User>();
            foreach(int id1 in ViewBag.friendids1){
                ViewBag.friends1.Add(userFactory.GetUserById(id1));
            }
            ViewBag.friendids2 = friendshipFactory.GetFriendIds2(userId);
            ViewBag.friends2 = new List<User>();
            foreach(int id2 in ViewBag.friendids2){
                ViewBag.friends1.Add(userFactory.GetUserById(id2));
            }
            ViewBag.requestids = friendshipFactory.GetFriendRequestsIds(userId);
            ViewBag.requests = new List<User>();
            foreach(int id in ViewBag.requestids){
                ViewBag.requests.Add(userFactory.GetUserById(id));
            }
            return View("Index");
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","User");
        }
        [HttpGet]
        [Route("users")]
        public IActionResult AllUsers()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("userId"));
            ViewBag.NoRelationship = new List<User>();
            ViewBag.NoRelationshipIds = friendshipFactory.FindNoRelationship(userId);
            foreach(int id in ViewBag.NoRelationshipIds){
                ViewBag.NoRelationship.Add(userFactory.GetUserById(id));
            }
            return View("AllUsers");
        }

        [HttpGet]
        [Route("adduser/{passed_id}")]
        public IActionResult AddUser()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("userId"));
            int passed_id = Convert.ToInt32(RouteData.Values["passed_id"]);
            System.Console.WriteLine();
            friendshipFactory.SendRequest(userId, passed_id);
            return RedirectToAction("Index");
        }       
        [HttpGet]
        [Route("users/{passed_id}")]
        public IActionResult Userpage()
        {
            int passed_id = Convert.ToInt32(RouteData.Values["passed_id"]);
            ViewBag.user = userFactory.GetUserById(passed_id);
            return View("Userpage");
        }       
        [HttpGet]
        [Route("accept/{passed_id}")]
        public IActionResult AcceptRequest()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("userId"));
            int passed_id = Convert.ToInt32(RouteData.Values["passed_id"]);
            friendshipFactory.AcceptRequest(userId,passed_id);
            return RedirectToAction("Index");
        }       
        [HttpGet]
        [Route("ignore/{passed_id}")]
        public IActionResult IgnoreRequest()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetInt32("userId"));
            int passed_id = Convert.ToInt32(RouteData.Values["passed_id"]);
            friendshipFactory.IgnoreRequest(userId,passed_id);
            return RedirectToAction("Index");
        }       
    }
}

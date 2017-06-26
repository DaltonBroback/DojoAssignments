using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;
using System.Linq;
using RESTauranter.Factory;

namespace RESTauranter.Controllers
{   
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
        private readonly UsersFactory userFactory;
        private readonly RestaurantsFactory restaurantFactory;
        private readonly ReviewsFactory reviewFactory;

 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
            userFactory = new UsersFactory();
            restaurantFactory = new RestaurantsFactory();
            reviewFactory = new ReviewsFactory();
        }
        // public HomeController(HomeContext connect)
        // {
        //     _context = context;
        // }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            return View();
        }
        [HttpGet]
        [Route("addreview")]
        public IActionResult AddReview(string reviewer, string restaurant, string content, string date, int rating)
        {
            // IEnumerable<Users> testUser = userFactory.FindByName(reviewer);
            // string testName = testUser.Name;
            bool nameconfirm = userFactory.SearchForName(reviewer);
            Users newUser = new Users{};
            int userid = -100;
            if (nameconfirm == true)
            {
                userid = userFactory.FindIdByName(reviewer);
                newUser = userFactory.FindById(userid) as Users;
            }
            else{
                newUser = new Users{
                    Name = reviewer
                };
                userFactory.Add(newUser);
            }
            Restaurants newRestaurant = new Restaurants{
                Name = restaurant
            };
            restaurantFactory.Add(newRestaurant);
            if (userid < 0){
                 userid = userFactory.FindLastId();
            }
            int restid = restaurantFactory.FindLastId();
            Reviews newReview = new Reviews{
                Content = content,
                Date = date,
                Rating = rating,
                user = newUser,
                restaurant = newRestaurant
            };
            reviewFactory.Add(newReview, userid, restid);
            return RedirectToAction("Index");
        }
    }
}

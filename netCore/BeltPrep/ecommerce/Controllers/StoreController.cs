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
    public class StoreController : Controller
    {
        private readonly UserFactory userFactory;

        public StoreController(DbConnector connect)
        {
            // _dbConector = connect;
            userFactory = new UserFactory();

        }
        // GET: /Home/
        [HttpGet]
        [Route("store")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View("Index");
        }
    }
}

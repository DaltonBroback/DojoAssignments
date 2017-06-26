using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using lostinthewoods.Factory;
using lostinthewoods.Models;
using Microsoft.AspNetCore.Mvc;

namespace lostinthewoods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
 
        public TrailController(DbConnector connect)
        {
            trailFactory = new TrailFactory();
        }
 
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View("Index");
            // Other code
        }
        [HttpGet]
        [Route("newtrail")]
        public IActionResult NewTrail()
        {
            ViewBag.Trails = trailFactory.FindAll();
            return View("NewTrail");
            // Other code
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(string name, string desc, double length, int elchange, double longitude, string NorS, double latitude, string EorW)
        {
            Trail newTrail = new Trail{
                Name = name,
                Description = desc,
                Length = length,
                ElevationChange = elchange,
                Longitude = longitude,
                NorS = NorS,
                Latitude = latitude,
                EorW = EorW,
            };
            trailFactory.Add(newTrail);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("trails/{Passed_id}")]
        public IActionResult Trails()
        {
            int id = Convert.ToInt32(RouteData.Values["Passed_id"]);
            ViewBag.trail = trailFactory.GetById(id);
            return View("Trails");
        }
    }
}

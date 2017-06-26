using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi") == null)
            {
                HttpContext.Session.SetObjectAsJson("Dojodachi", new Dojodachi());
            }
            Dojodachi Dojodachi = new Dojodachi();
            int happiness = Dojodachi.happiness;
            ViewBag.happiness = happiness;
            int fullness = Dojodachi.fullness;
            ViewBag.fullness = fullness;
            int energy = Dojodachi.energy;
            ViewBag.energy = energy;
            int meals = Dojodachi.meals;
            ViewBag.meals = meals;
            return View();
        }
        [HttpPost]
        [RouteAttribute("feed")]
        public IActionResult Feed()
        {
            return RedirectToAction("Index");
        }
    }
}

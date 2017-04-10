using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // return View();
            //OR
            return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }
        [HttpGet]
        [Route("/home")]
        public IActionResult Home()
        {
            // return View();
            //OR
            return View("Home");
            //Both of these returns will render the same view (You only need one!)
        }
        [HttpGet]
        [Route("/projects")]
        public IActionResult Projects()
        {
            // return View();
            //OR
            return View("Projects");
            //Both of these returns will render the same view (You only need one!)
        }
        [HttpGet]
        [Route("/contact")]
        public IActionResult Contact()
        {
            // return View();
            //OR
            return View("Contact");
            //Both of these returns will render the same view (You only need one!)
        }
    }
}

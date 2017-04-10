using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.controllers
{
    public class YourController : Controller
    {
        [HttpGet]
        [Route("")]
        public JsonResult Example()
        {
            // The Json method convert the object passed to it into JSON
            return Json(SomeC#Object);
            [HttpGet]
            [Route("displayint")]
            public JsonResult DisplayInt()
            {
                return Json(34);
            }
            
            // Suppose we're working with the Human class we wrote in the previous chapter
            [HttpGet]
            [Route("displayhuman")]
            public JsonResult DisplayHuman()
            {
                return Json(new Human());
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        [Route("card/{FirstName}/{LastName}/{Age}/{FavoriteColor}")]
        public JsonResult CallCard(string FirstName, string LastName, string Age, string FavoriteColor)
        {
            return Json(new {FirstName = FirstName, LastName = LastName, Age = Age, FavoriteColor = FavoriteColor});
        }
        public string Index()
        {
            return "Hello World!";
        }
    }
}

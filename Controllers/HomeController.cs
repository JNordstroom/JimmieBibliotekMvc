using Microsoft.AspNetCore.Mvc;

namespace MyLibrary.mvc.Controllers
{
   
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        
    }
}
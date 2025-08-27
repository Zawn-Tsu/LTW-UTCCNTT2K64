using Microsoft.AspNetCore.Mvc;

namespace BTTH_Day02.Controllers
{
    public class MyNewController : Controller
    {
        public IActionResult Index()
        {
            return View("Sample");
        }
        public IActionResult Sample()
        {
            return RedirectToAction("Index");
        }
    }
}

using System.Diagnostics;
using BTTLDay03.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTTLDay03.Controllers
{
    public class HomeController : Controller
    {
        protected Product product = new Product();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = product.GetProductsList();
            return View(products);
        }

     
    }
}

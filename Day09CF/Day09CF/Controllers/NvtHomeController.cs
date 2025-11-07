using System.Diagnostics;
using Day09CF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day09CF.Controllers
{
    public class NvtHomeController : Controller
    {
        private readonly ILogger<NvtHomeController> _logger;

        public NvtHomeController(ILogger<NvtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("NvtHome");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

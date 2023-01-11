using Agicultural.Context;
using Agicultural.DAO;
using Agicultural.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agicultural.Controllers
{
    public class HomeController : Controller
    {


        private readonly dao DataAccess;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(Cont con) {
            DataAccess = new dao(con);
        }

        public IActionResult Index()
        {
            return View("Login");
        }
        [HttpPost("[action]"), Route("/Login")]
        public IActionResult Login([FromForm] LoginModel login) {   //test only do not overthink
            var data = DataAccess.login(login);
            //Login Code here
            return RedirectToAction("sampleIfLoginSuccess");
        }

        [HttpPost("[action]"), Route("/Dashboard")]
        public IActionResult Dashboard() {
            return View();
        }

        //============================================================== Do not edit below
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
using Agicultural.Context;
using Agicultural.DAO;
using Agicultural.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            return View("LoginType");
        }
        [HttpPost("[action]"), Route("/LoginType")]
        public IActionResult LoginType([FromForm]LoginTypeModel logintype) {

            string logins = string.Empty;

            if (logintype.employee is "employee") logins = "EmpLogin";
            else if (logintype.admin is "admin") logins = "AdminLogin";
            else if (logintype.timein is "timein") logins = "Login";

            return View(logins);
        }

        [HttpPost("[action]"), Route("/Login")]
        public IActionResult Login([FromForm] LoginModel login ) {

            var data = DataAccess.login(login);

            return RedirectToAction("Login");
        }

        [HttpPost("[action]"), Route("/Dashboard")]
        public IActionResult Dashboard() {
            return View();
        }

        [HttpPost("[action]"), Route("/UserPage")]
        public IActionResult UserPage()
        {

            return View();
        }

        [HttpPost("[action]"), Route("/MemberPage")]
        public IActionResult MemberPage()
        {

            return View();
        }

        [HttpPost("[action]"), Route("/Event")]
        public IActionResult EventPage()
        {

            return View();
        }

        [HttpPost("[action]"), Route("/ReportPage")]
        public IActionResult ReportPage()
        {

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
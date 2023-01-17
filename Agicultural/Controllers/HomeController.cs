using Agicultural.Context;
using Agicultural.DAO;
using Agicultural.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using QRCoder;
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

    public HomeController(Cont con)
    {
      DataAccess = new dao(con);
    }

    public IActionResult Index()
    {
            //return View("LoginType");
            return View("scan");
    }
    [HttpPost("[action]"), Route("/LoginType")]
    public IActionResult LoginType([FromForm] LoginTypeModel logintype)
    {

      string logins = string.Empty;

      if (logintype.employee is "emp") logins = "EmpLogin";
      else if (logintype.admin is "admin") logins = "AdminLogin";
      else if (logintype.timein is "timein") logins = "Login";

      return View(logins);
    }

    [HttpPost("[action]"), Route("/Login")]
    public IActionResult Login([FromForm] LoginModel login)
    {
      var data = DataAccess.login(login);

      //return RedirectToAction("Login");
      return View(data);
    }

    [HttpPost("[action]"), Route("/Dashboard")]
    public IActionResult Dashboard()
    {
      return View();
    }

    [HttpPost("[action]"), Route("/registration")]
    public IActionResult registration()
    {
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

    [HttpPost("[action]"), Route("/EmpLogin")]
    public IActionResult EmpLogin()
    {

      return View();
    }

    [HttpPost("[action]"), Route("/OTP")]
    public IActionResult OTP()
    {

      return View();
    }

    public string GenQr(string qr)
    {
      QRCodeGenerator generate = new QRCodeGenerator();
      var qrdata = generate.CreateQrCode(qr, QRCodeGenerator.ECCLevel.Q);
      var bit = new BitmapByteQRCode(qrdata);
      var img = bit.GetGraphic(20);
      return Convert.ToBase64String(img);
    }
    [HttpPost]
    public string Jav([FromBody] QrModel dd)
    {
      return GenQr(dd.qrmod);
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
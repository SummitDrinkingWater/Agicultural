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
            //ViewData["d"] = GenQr("fuckyouasdsadasdasdasomuch");
            
            List<LoginModel> ww = new List<LoginModel> {
                new LoginModel { empid = "111", username = "qqq", password="qwe"},
                new LoginModel { empid = "222", username = "www", password="qwe"},
                new LoginModel { empid = "333", username = "eee", password="qwe"},
                new LoginModel { empid = "444", username = "rrr", password="qwe"},
                new LoginModel { empid = "555", username = "ttt", password="qwe"},
            };
            //return View("viewQr");
            //return View("LoginType");
            //return View("MemberPage", qq);
            //return View("scan");
            //var data = EmployeeDataExample();
            //return View("EmpDashboardPage", data);
            //var data = TimeLogDataExample();
            return View("EmpDashboardPage");
        }
        [HttpPost("[action]"), Route("/LoginType")]
        public IActionResult LoginType([FromForm] LoginTypeModel logintype)
        {

            //string logins = string.Empty;         Do not delete
            //if (logintype.employee is "emp") logins = "EmpLogin";
            //else if (logintype.admin is "admin") logins = "LoginType";
            //else if (logintype.timein is "timein") logins = "Login";
            //return View(logins);

            return View();
        }

        [HttpPost("[action]"), Route("/Login")] //<<--- functional
        public IActionResult Login([FromForm] LoginModel login)
        {
            var data = DataAccess.login(login);
            if (data == "Dashboard")
            {
                return View(data, DataAccess.GetAllEmployee());
            }
            else if (data == "EmpDashboardPage")//<<<---- next
            {
                return View(data, DataAccess.GetTimeLog());
            }
            else
            return View("LoginType");
        }
        [HttpPost("[action]"), Route("/Create")] //<<--- functional
        public IActionResult Create([FromForm] EmployeeModel emp)
        {
           DataAccess.AddEmployee(emp);
           ViewData["d"] = GenQr(emp.empid);

            return View("viewQr");
        }
        [HttpPost("[action]"), Route("/viewQr")]
        public IActionResult viewQr()
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

        [HttpPost("[action]"), Route("/EmpDashboardPage")]
        public IActionResult EmpDashboardPage()
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
        public List<EmployeeModel> EmployeeDataExample()
        {
            List<EmployeeModel> qq = new List<EmployeeModel> {
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              },
                              new EmployeeModel {
                                  empid = "123123",
                                  fname = "John",
                                  mname = "D",
                                  lname = "Strong",
                                  age = 21,
                                  contact = "09090909",
                                  bdayy = "1999",
                                  bdaym = "June",
                                  bdayd = "1",
                                  address = "Tintay",
                                  civil_status = "Alone",
                                  dstartd = "1",
                                  dstartm = "January",
                                  dstarty = "1122",
                                  position = "Dogstyle",
                                  type = "emp"
                              }
                        };
            return qq;
        }
        public List<TimeInModel> TimeLogDataExample() {
            List<TimeInModel> time = new List<TimeInModel> {
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"},
                new TimeInModel { timein = "06:31", timeout = "07:21", date = "01/01/2022", empid = "629650"}
                 };
            return time;

        }
    }
}

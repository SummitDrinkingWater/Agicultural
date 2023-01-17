using Agicultural.Context;
using Agicultural.Models;
using Microsoft.EntityFrameworkCore;
using QRCoder;

namespace Agicultural.DAO
{
    public class dao
    {
        private readonly Cont cont;
        public dao(Cont con) { cont = con; }

        public string login(LoginModel login)
        {
            //test only do not overthink --> for getting login data from database

            string sql = string.Format(@"select * from employee where id = '" + login.empid + "' and fname = '" + login.password +"'");
            var count = cont.logins.FromSqlRaw(sql);
            if (count.Count() > 0)
                    return "Dashboard";


            if (login.empid == "emp") return "EmpDashboardPage";
            else if (login.empid == "admin") return "AdminLogin";
            else if (login.empid == "timein") return "Login";

            return login.empid is null ? "Login" : login.empid;
        }
    }
}
//QRCodeGenerator generator = new QRCodeGenerator();
//var qrdata = generator.CreateQrCode(qr, QRCodeGenerator.ECCLevel.Q);

//var bit = new BitmapByteQRCode(qrdata);
//var img = bit.GetGraphic(20);

//return Convert.ToBase64String(img);
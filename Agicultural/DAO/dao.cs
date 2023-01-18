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

            string sql = string.Format(@"select * from employee where lname = '" + login.username + "' and fname = '" + login.password +"'");
            var count = cont.logins.FromSqlRaw(sql);


            if (count.Count() > 0)
                return "Dashboard";
            else { return "failed"; }

            if (login.empid == "emp") return "EmpDashboardPage";
            else if (login.empid == "admin") return "AdminLogin";
            else if (login.empid == "timein") return "Login";

            return login.empid is null ? "Login" : login.empid;
        }

        public string AddEmployee(EmployeeModel emp)
        {
            string sql = string.Format(@"Insert into employee(fname, mname, lname, age, contact, birthdate, address, civil_status, date_start, position, type) 
                                        values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')", emp.fname, emp.mname, emp.lname, emp.age, emp.contact, emp.birthdate, emp.address, emp.civil_status, emp.date_start, emp.position, emp.type); //<<<< query for create
            int count = cont.Database.ExecuteSqlRaw(sql);
            if (count > 0)
                return "Added";
            else
                return "Failed";
        }

        public List<EmployeeModel> GetEmployee(EmployeeModel model)
        {
            var getdata = cont.employees.FromSqlRaw(@"select * from employee").ToList();
            return getdata;
        }

        public void UpdateEmployee(EmployeeModel employee) {
            string updatedata = $"update query here";
            cont.Database.ExecuteSqlRaw(updatedata);
        }

    }
}
//QRCodeGenerator generator = new QRCodeGenerator();
//var qrdata = generator.CreateQrCode(qr, QRCodeGenerator.ECCLevel.Q);

//var bit = new BitmapByteQRCode(qrdata);
//var img = bit.GetGraphic(20);

//return Convert.ToBase64String(img);
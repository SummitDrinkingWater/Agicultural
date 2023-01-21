using Agicultural.Context;
using Agicultural.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using QRCoder;
using System.Runtime.CompilerServices;

namespace Agicultural.DAO
{
    public class dao
    {
        private readonly Cont cont;
        public dao(Cont con) { cont = con; }

        public string login(LoginModel login)
        {
            string sql = string.Format(@"select empid, password from login where empid = '"+login.empid+"' and password = '"+login.password+"'");
            var count = cont.logins.FromSqlRaw(sql);
            int c = count.Count();
            if (count.Count() > 0)
                if (login.empid == "admin") 
                    return "MemberPage";
                else return "EmpDashboardPage";
            else return "LoginType"; 
        }

        public string AddEmployee(EmployeeModel emp)
        {
            string qrcode = vGenQr(emp.empid.ToString());
            string bday = $"{emp.bdaym}-{emp.bdayd}-{emp.bdayy}";
            string dstart = $"{emp.dstartm}-{emp.dstartm}-{emp.dstarty}";
            AddQr(qrcode, emp.empid.ToString());
            string sql = string.Format(@"Insert into employee(fname, mname, lname, age, contact, birthdate, address, civil_status, date_start, position, type, empid) 
                                        values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", emp.fname, emp.mname, emp.lname, emp.age, emp.contact, bday, emp.address, emp.civil_status, dstart, emp.position, emp.type, emp.empid); //<<<< query for create
            int count = cont.Database.ExecuteSqlRaw(sql);

            if (count > 0)
                return qrcode;
            else
                return "Failed";
        }
        public List<EmployeeModel> GetEmployee(string emp)
        {
            var data = cont.employees.FromSqlRaw($"select * from employee where empid = '"+emp+"'").ToList();
            return  data;
        }
        public string AddQr(string qr, string fid) {
            string qrsql = string.Format(@"Insert into qrdb(qrv, f_id) values ('{0}', '{1}')", qr, fid);
            int count = cont.Database.ExecuteSqlRaw(qrsql);
            if (count > 0) return "Added"; else return "";
        }
        public string vGenQr(string qr)
        {
            QRCodeGenerator generate = new QRCodeGenerator();
            var qrdata = generate.CreateQrCode(qr, QRCodeGenerator.ECCLevel.Q);
            var bit = new BitmapByteQRCode(qrdata);
            var img = bit.GetGraphic(20);
            return Convert.ToBase64String(img);
        }
        public List<EmployeeModel> GetAllEmployee()
        {
            var getdata = cont.employees.FromSqlRaw(@"select * from employee").ToList();
            return getdata;
        }

        public void UpdateEmployee(EmployeeModel employee) {
            string updatedata = $"Update employee set fname = '{employee.fname}', mname = '{employee.mname}', lname = '{employee.lname}', contact = '{employee.contact}', address = '{employee.address}', civil_status = '{employee.civil_status}', position = '{employee.position}', type = '{employee.type}' where empid = '{employee.empid}'";
            cont.Database.ExecuteSqlRaw(updatedata);
        }
        public void DeleteEmployee(EmployeeModel employee) {
            string delete = $"Delete from employee where empid = {employee.empid}";
            cont.Database.ExecuteSqlRaw(delete);
        }
        public List<TimeInModel> GetTimeLogByEmp(string time)
        {
            var gettimelog = cont.timelog.FromSqlRaw(@"SELECT dbo.timedb.timein, dbo.timedb.timeout, dbo.timedb.empid, dbo.timedb.date
                                                        FROM dbo.login INNER JOIN dbo.timedb ON dbo.login.empid = dbo.timedb.empid where dbo.timedb.empid = '"+time+"'").ToList();
            return gettimelog;
        }
        //public List<TimeInModel> GetTimeLogByDate()
        //{ 
        
        //}
        //public List<TimeInModel> GetTimeLogByRange()
        //{ 
            
        //}
    }
}

using Agicultural.Context;
using Agicultural.Models;
using Microsoft.EntityFrameworkCore;

namespace Agicultural.DAO
{
    public class dao
    {
        private readonly Cont cont;
        public dao(Cont con) { cont = con; }

        public string login(LoginModel login) {
            //test only do not overthink --> for getting login data from database

            //string sql = string.Format(@"select * from student_info where StudentId = '" + xlog.Id + "' and pword = '" + xlog.password + "'");
            //var count = cont.logins.FromSqlRaw(sql);
            //if (count.Count() > 0)
            //    if (login.idnum == "Admin")
            //    {
            //        return "Dashboard";
            //    }
            //    else
            //    {
            //        return "Login";
            //    }
            //else
            return "failed";
        }

        public string AddEmployee(EmployeeModel employee) {

            //test only --> adding data to database

            //string sql = string.Format(@"Insert into student_info(StudentId, Firstname, Midname, Lastname, Birthdate, Sex, StudentAddress, pword, course) 
            //                         values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", student.idnum, student.fname, student.midname,
            //                         student.lname, student.bday, student.gender, student.address, student.pw, student.crs);
            //int count = cont.Database.ExecuteSqlRaw(sql);
            //if (count > 0)
            //    return "Added";
            //else
            //    return "Failed";

            return "something to return";
        }
    }
}

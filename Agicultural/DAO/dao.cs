﻿using Agicultural.Context;
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
            string sql = string.Format(@"select * from employee where empid = '" + login.empid + "' and password = '" + login.password +"'");
            var count = cont.logins.FromSqlRaw(sql);

            if (count.Count() > 0)
                if (login.empid == "admin") return "Dashboard";
                else return "EmpDashboardPage";
            else return "LoginType"; 
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
            string updatedata = $"Update employee set fname = '{employee.fname}', mname = '{employee.mname}', lname = '{employee.lname}', contact = '{employee.contact}', address = '{employee.address}', civil_status = '{employee.civil_status}', position = '{employee.position}', type = '{employee.type}' where empid = '{employee.empid}'";
            cont.Database.ExecuteSqlRaw(updatedata);
        }
        public void DeleteEmployee(EmployeeModel employee) {
            string delete = $"Delete from employee where empid = {employee.empid}";
            cont.Database.ExecuteSqlRaw(delete);
        }
    }
}
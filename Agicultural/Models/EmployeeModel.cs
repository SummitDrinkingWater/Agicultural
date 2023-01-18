using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agicultural.Models
{
    [Keyless]
    public class EmployeeModel
    {
        public string? bdayy { get; set; }
        public string? bdaym { get; set; }
        public string? bdayd { get; set; }
        public string? dstarty { get; set; }
        public string? dstartm { get; set; }
        public string? dstartd { get; set; }
        [Column("id")]
        public int id { get; set; }//primary key
        [Column("fname")]
        public string? fname { get; set; }
        [Column("mname")]
        public string? mname { get; set; }
        [Column("lname")]
        public string? lname { get; set; }
        [Column("age")]
        public int age { get; set; }
        [Column("contact")]
        public string? contact { get; set; }
        [Column("birthdate")]
        public string? birthdate { 
            get { 
                return bdayy + "-" + bdaym + "-" + bdayd;
            }
        }
        [Column("addres")]
        public string? address { get; set; }
        [Column("civil_status")]
        public string? civil_status { get; set; }
        [Column("date_start")]
        public string? date_start {
            get { 
                return dstarty + "-" + dstartm + "-" + dstartd;
            }
        }
        [Column("position")]
        public string? position { get; set; }
        [Column("type")]
        public string? type { get; set; }
        [Column("empid")]
        public string? empid { get; set; }
        

    }
}

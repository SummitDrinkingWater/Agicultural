using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agicultural.Models
{
    [Keyless]
    public class EmployeeModel
    {
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
        public string? birthdate { get; set; }
        [Column("addres")]
        public string? address { get; set; }
        [Column("civil_status")]
        public string? civil_status { get; set; }
        [Column("date_start")]
        public string? date_start { get; set; }
        [Column("position")]
        public string? position { get; set; }
        [Column("type")]
        public string? type { get; set; }

        //public string? role { get; set; }
        //public string? name { get; set; }

    }
}

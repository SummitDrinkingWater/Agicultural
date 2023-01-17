using Microsoft.EntityFrameworkCore;

namespace Agicultural.Models
{
    [Keyless]
    public class LoginModel
    {

        public string? empid { get; set; }// foreign key
        public string? username { get; set; }
        public string? password { get; set; }
        public string? logintype { get; set; }

    }
}

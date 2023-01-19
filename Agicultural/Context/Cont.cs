using Agicultural.Models;
using Microsoft.EntityFrameworkCore;

namespace Agicultural.Context
{
    public class Cont : DbContext
    {
        public Cont(DbContextOptions<Cont> contextOptions) : base(contextOptions) { }
        public DbSet<LoginModel> logins { get; set; }
        public DbSet<EmployeeModel> employees { get; set; }
        public DbSet<QrModel> qr { get; set; }
        public DbSet<TimeInModel> timelog { get; set; }
    }
}

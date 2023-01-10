using Agicultural.Models;
using Microsoft.EntityFrameworkCore;

namespace Agicultural.Context
{
    public class Cont : DbContext
    {
        public Cont(DbContextOptions<Cont> contextOptions) : base(contextOptions) { }
        public DbSet<LoginModel> logins { get; set; }
    }
}

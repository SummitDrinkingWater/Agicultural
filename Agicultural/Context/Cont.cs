using Agicultural.Models;
using Microsoft.EntityFrameworkCore;

namespace Agicultural.Context
{
    public class Cont : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<LoginModel>(
                    builder =>
                    {
                        builder.HasNoKey();
                    });

            modelBuilder
                 .Entity<EmployeeModel>(
                     builder =>
                     {
                         builder.HasNoKey();
                     });
            modelBuilder.Entity<QrModel>(builder => { builder.HasNoKey(); });
            modelBuilder.Entity<TimeInModel>(builder => { builder.HasNoKey(); });
           
        }
        public Cont(DbContextOptions<Cont> contextOptions) : base(contextOptions) { }
        public DbSet<LoginModel> logins { get; set; }
        public DbSet<EmployeeModel> employees { get; set; }
        public DbSet<QrModel> qr { get; set; }
        public DbSet<TimeInModel> timelog { get; set; }
    }
}

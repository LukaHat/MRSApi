using Microsoft.EntityFrameworkCore;
using Test_API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Test_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Razmjena> Razmjene { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Ime = "Tea",
                    Prezime = "Babić",
                    JMBAG = "0010232001"
                },
                new Student()
                {
                    Id = 2,
                    Ime = "Luka",
                    Prezime = "Hat",
                    JMBAG = "0010232901"
                },
                new Student()
                {
                    Id = 3,
                    Ime = "Tomislav",
                    Prezime = "Kvesić",
                    JMBAG = "0010232483"
                }
                );
        }
    }
}

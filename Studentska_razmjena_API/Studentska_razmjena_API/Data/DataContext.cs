using Microsoft.EntityFrameworkCore;
using Studentska_razmjena_API.Models;

namespace Studentska_razmjena_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<Razmjena> Razmjene { get; set; }
        public DbSet<Student> Studenti { get; set; }

    }
}

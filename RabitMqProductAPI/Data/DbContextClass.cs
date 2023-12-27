using Microsoft.EntityFrameworkCore;
using RabitMqProductAPI.Models;

namespace RabitMqProductAPI.Data
{
    public class DbContextClass : DbContext 
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Product> Products { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using TestRabbitmq.Models;

namespace TestRabbitmq.Data
{
    public class DbContextClass:DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
		
			Configuration = configuration;
			Database.EnsureCreated();
		}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
			options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnection"));
		}

        public DbSet<Product> Products { get; set; }
    }
}

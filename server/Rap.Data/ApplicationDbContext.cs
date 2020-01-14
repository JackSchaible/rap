using Microsoft.EntityFrameworkCore;

namespace Rap.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

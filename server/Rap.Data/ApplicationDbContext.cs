using Microsoft.EntityFrameworkCore;

namespace Rap.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=.;Database=rap;Trusted_Connection=True;",
                    opts => opts.EnableRetryOnFailure(3));
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<FinanceTracker> FinanceTrackers { get; set; }
    }
}

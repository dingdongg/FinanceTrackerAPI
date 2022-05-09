using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Transaction> FinanceTrackers { get; set; }
    }
}

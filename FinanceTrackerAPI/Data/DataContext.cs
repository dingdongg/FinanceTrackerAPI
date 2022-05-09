using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // nothing needed
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}

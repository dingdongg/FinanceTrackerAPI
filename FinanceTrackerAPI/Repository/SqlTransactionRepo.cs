namespace FinanceTrackerAPI.Repository
{
    public class SqlTransactionRepo : ITransactionRepo
    {
        private readonly DataContext _context;

        public SqlTransactionRepo(DataContext context)
        {
            _context = context;
        }
        public void CreateTransaction(Transaction trctn)
        {
            if (trctn == null)
            {
                throw new ArgumentNullException(nameof(trctn));
            }
            _context.Transactions.Add(trctn);
        }

        public void DeleteTransaction(Transaction trctn)
        {
            if (trctn == null)
            {
                throw new ArgumentException(nameof(trctn));
            }
            _context.Transactions.Remove(trctn);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }

        public Transaction GetTransactionById(int id)
        {
            return _context.Transactions.FirstOrDefault(t => t.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateTransaction(Transaction trctn)
        {
            // Nothing!
            // * since SQL Server DB Context automatically makes the updates,
            // this method doesn't have to do anything.
            // If the implementation of the repo interface were to change in the future
            // to use a DIFFERENT DB context, this method will likely have to be updated as well.
        }
    }
}

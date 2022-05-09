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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateTransaction(Transaction trctn)
        {
            throw new NotImplementedException();
        }
    }
}

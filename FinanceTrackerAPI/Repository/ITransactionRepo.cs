namespace FinanceTrackerAPI.Repository
{
    public interface ITransactionRepo
    {
        bool SaveChanges();
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
        void CreateTransaction(Transaction trctn);
        void UpdateTransaction(Transaction trctn);
        void DeleteTransaction(Transaction trctn);
    }
}

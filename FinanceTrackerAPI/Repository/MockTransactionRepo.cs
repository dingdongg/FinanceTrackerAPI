namespace FinanceTrackerAPI.Repository
{
    /**
     * mock implementation of the repository interface for testing purposes
     */
    public class MockTransactionRepo : ITransactionRepo
    {
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
            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    Id = 1,
                    Name = "water bottle",
                    Amount = 2.50,
                    Year = 2022,
                    Month = 5,
                    Day = 8,
                    Description = "bought water bottle from store"
                },
                new Transaction
                {
                    Id = 2,
                    Name = "noodles",
                    Amount = 10.99,
                    Year = 2019,
                    Month = 12,
                    Day = 25,
                    Description = "noodles were on sale, so I bought some"
                }, 
                new Transaction
                {
                    Id = 3,
                    Name = "eggs",
                    Amount = 12.50,
                    Year = 2001,
                    Month = 4,
                    Day = 1,
                    Description = "expired eggs lol"
                }
            };
            return transactions;
        }

        public Transaction GetTransactionById(int id)
        {
            return new Transaction
            {
                Id = 2,
                Name = "noodles",
                Amount = 10.99,
                Year = 2019,
                Month = 12,
                Day = 25,
                Description = "noodles were on sale, so I bought some"
            };
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

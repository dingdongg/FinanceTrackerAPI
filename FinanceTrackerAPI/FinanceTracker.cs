namespace FinanceTrackerAPI
{
    public class FinanceTracker
    {
        public int Id { get; set; }
        public string TransactionName { get; set; } = String.Empty;
        public float Amount { get; set; }
        public DateOnly TransactionDate { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}

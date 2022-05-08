namespace FinanceTrackerAPI
{
    public class FinanceTracker
    {
        public int Id { get; set; }
        public string TransactionName { get; set; } = String.Empty;
        public double Amount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Description { get; set; } = String.Empty;
    }
}

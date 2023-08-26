namespace ExpenseTracker.DTO
{
    public class ExpenseFetchDTO
    {
        public decimal Amount { get; set; }

        public DateTime ExpenseDate { get; set; }
        public string CategoryName { get; set; }
    }
}

namespace ExpenseTracker.Models
{
    public class EachCategoryModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public ExpenseCategory Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}

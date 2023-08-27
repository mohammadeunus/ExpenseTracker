namespace ExpenseTracker.DTO;

public class ExpenseUpdateDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
}

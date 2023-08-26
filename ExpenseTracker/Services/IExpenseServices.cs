namespace ExpenseTracker.Services;

public interface IExpenseServices
{
    string IsDateAndDateRangeValid(DateTime IstartDate, DateTime IendDate);
}

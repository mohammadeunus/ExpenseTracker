using ExpenseTracker.Repository;

namespace ExpenseTracker.Services;

public class ExpenseServices : IExpenseServices
{
    private readonly ILogger<ExpenseRepository> _logger;

    public ExpenseServices(ILogger<ExpenseRepository> logger)
    {
        _logger = logger;
    }

    public string IsDateAndDateRangeValid(DateTime startDate, DateTime endDate)
    {
        try
        {
            if (startDate > DateTime.UtcNow) return ("Date cannot be in the future.");
            if (endDate > DateTime.UtcNow) return ("Date cannot be in the future.");
            if (startDate > endDate) return ("The start date should be earlier than the end date.");
            return ("valid");
        }
        catch (Exception ex)
        {
            _logger.LogError($"ExpenseRepository > CheckDateAndDateRangeValidity > Error: {ex.Message}");
            return ("Unexpected error.");
        }

    }
}

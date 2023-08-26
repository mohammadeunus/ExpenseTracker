using ExpenseTracker.DTO;

namespace ExpenseTracker.Repository
{
    public interface IExpenseRepository
    {
        Task<bool> HasAddedExpenseInCategoryAsync(ExpenseEntryDTO responseEachCategory);
        Task<List<ExpenseFetchDTO>> GetExpensesBetweenDatesAsync(DateTime IstartDate, DateTime IendDate);
    }
}

using ExpenseTracker.Models;

namespace ExpenseTracker.Repository;
public interface ICategoriesRepository
{
    Task<List<CategoriesModel>> GetAllCategoriesAsync();
    Task<bool> AddCategoryAsync(string categoryName);
}

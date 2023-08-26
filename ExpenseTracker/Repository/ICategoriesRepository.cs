using ExpenseTracker.Models;

namespace ExpenseTracker.Repository;
public interface ICategoriesRepository
{
    Task<List<CategoriesModel>> GetAllCategoriesAsync(); 
    Task<bool> AddCategoryAsync(string categoryName);
    //for eachCategory
    Task<bool> IsCategoryNameUniqueAsync(string categoryName);
    Task<bool> IsCategoryIdUniqueAsync(int categoryId);
    Task<string> GetCategoryNameByIdAsync(int categoryId);
    Task<bool> IsCategoryIdDeleted(int id);
}

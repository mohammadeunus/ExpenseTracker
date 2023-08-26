using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;

namespace ExpenseTracker.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly ILogger<CategoriesRepository> _logger;
    private readonly ExpenseTrackerDbContext _context;

    public CategoriesRepository(ILogger<CategoriesRepository> logger, ExpenseTrackerDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<List<CategoriesModel>> GetAllCategoriesAsync()
    {
        try
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesRepository > GetAllCategoriesAsync > Error: {ex.Message}");
            throw; // Rethrow the exception or handle it appropriately
        }
    }

    public async Task<bool> AddCategoryAsync(string categoryName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(categoryName))
                return false;

            

            //save data in database.
            var newCategory = new CategoriesModel { Name = categoryName };
            await _context.Categories.AddAsync(newCategory);
            var isSaved = await _context.SaveChangesAsync();

            return isSaved > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesRepository > AddCategoryAsync > Error: {ex.Message}");
            throw; // Rethrow the exception or handle it appropriately
        }
    }
    public async Task<bool> IsCategoryNameUniqueAsync(string categoryName)
    {
        try
        {
            //check category duplicate or not.
            if (await _context.Categories.AnyAsync(x => x.Name == categoryName))
                return true;
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesRepository > IsCategoryNameUnique > Error: {ex.Message}");
            return false;
        } 
    }
    public async Task<bool> IsCategoryIdUniqueAsync(int categoryId)
    {
        try
        {
            //check category duplicate or not.
            if (await _context.Categories.AnyAsync(x => x.Id == categoryId))
                return true;
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesRepository > IsCategoryIdUnique > Error: {ex.Message}");
            return false; 
        }
    }
    public async Task<string> GetCategoryNameByIdAsync(int categoryId)
    {
        try
        {
            //check category duplicate or not.
            var fetched = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
            var fetchedCategoryName = fetched.Name;   
            return fetchedCategoryName;

        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesRepository > IsCategoryIdUnique > failed fetching input: {categoryId} : {ex.Message}");
            return null;
        }
    }

    public async Task<bool> IsCategoryIdDeleted(int id)
    {
        try
        {
            var result = await _context.Categories.FirstOrDefaultAsync(e => e.Id == id);

            //check category duplicate or not.
            _context.Categories.Remove(result);
            var confirm = await _context.SaveChangesAsync();
            return confirm>0;

        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesRepository > IsCategoryIdDeleted > failed delete id: {id} : {ex.Message}");
            return false;
        }

    }

    public async Task<bool> IsCategoryIdUpdated(CategoriesModel response)
    {
        try
        {
            // Retrieve the existing category based on ID from response.
            var existingCategory = await _context.Categories
                 .FirstOrDefaultAsync(e => e.Id == response.Id);

            if (existingCategory == null) return false;

            // Update the properties of the existing category with the data from the response.
            existingCategory.Name = response.Name;   
            var check = await _context.SaveChangesAsync();

            // Return true if changes were saved successfully, otherwise false. 
            return check > 0; 
        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesRepository > IsCategoryIdUpdated > failed update id: {response.Id} : {ex.Message}");
            return false;
        }
    }

}

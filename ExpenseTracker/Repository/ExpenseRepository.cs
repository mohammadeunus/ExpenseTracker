using ExpenseTracker.DTO;
using ExpenseTracker.Models;
using ExpenseTracker.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;

namespace ExpenseTracker.Repository;

public class ExpenseRepository  : IExpenseRepository
{
    private readonly ILogger<ExpenseRepository> _logger;
    private readonly ExpenseTrackerDbContext _context;
    private readonly ICategoriesRepository _categoriesRepository;

    public ExpenseRepository(ExpenseTrackerDbContext dbContext, ILogger<ExpenseRepository> logger, ICategoriesRepository categoriesRepository)
    {
        _context = dbContext;
        _logger = logger;
        _categoriesRepository = categoriesRepository;
    }

    public async Task<List<ExpenseRecordModel>> GetAllCategoriesAsync()
    {
        return await _context.ExpenseRecords.ToListAsync();
    }


    public async Task<bool> HasAddedExpenseInCategoryAsync(ExpenseEntryDTO response)
    {
        try
        {
            //save data in database.
            var newExpenseRecord = new ExpenseRecordModel
            {
                Amount = response.Amount,
                ExpenseDate = response.ExpenseDate,
                CategoryId = response.CategoryId,
            };
            await _context.ExpenseRecords.AddAsync(newExpenseRecord);
            var isSaved = await _context.SaveChangesAsync();

            return isSaved > 0;

        }
        catch (Exception ex)
        {
            _logger.LogError($"ExpenseRepository > HasAddedExpenseInCategoryAsync > Error: {ex.Message}");
            return false;
        }
    }
    public async Task<List<ExpenseFetchDTO>> GetExpensesBetweenDatesAsync(DateTime IstartDate, DateTime IendDate)
    {
        try
        {
            //Fetch all the ExpenseRecords within the date range
            var expenses = await _context.ExpenseRecords
                .Where(expense => expense.ExpenseDate >= IstartDate && expense.ExpenseDate <= IendDate)
                .ToListAsync();

            //Transform the expense into the return type of this method: ExpenseFetchDTO
            var expenseFetchDTOs = new List<ExpenseFetchDTO>();
            foreach (var expense in expenses)
            {
                var categoryName = await _categoriesRepository.GetCategoryNameByIdAsync(expense.CategoryId);

                var newExpenseFetchDTO = new ExpenseFetchDTO
                {
                    ExpenseDate = expense.ExpenseDate,
                    CategoryName = categoryName,
                    Amount = expense.Amount
                };

                expenseFetchDTOs.Add(newExpenseFetchDTO);
            }

            return expenseFetchDTOs;
        }
        catch (Exception ex)
        {
            _logger.LogError($"ExpenseRepository > HasAddedExpenseInCategoryAsync > Error: {ex.Message}");
            // return empty ExpenseFetchDTO
            return new List<ExpenseFetchDTO>();

        }

    } 

}
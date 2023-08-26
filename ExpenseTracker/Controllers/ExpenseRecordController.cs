using ExpenseTracker.DTO;
using ExpenseTracker.Repositories;
using ExpenseTracker.Repository;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpenseRecordController : ControllerBase
{
    private readonly ILogger<ExpenseRecordController> _logger;
    private readonly IExpenseRepository _expenseRepository;
    private readonly ICategoriesRepository _categoryRepository;
    private readonly IExpenseServices _expenseServices;

    public ExpenseRecordController(ILogger<ExpenseRecordController> logger, IExpenseRepository eachCategoryRepository, ICategoriesRepository categoryRepository, IExpenseServices expenseServices)
    {
        _expenseServices = expenseServices;
        _logger = logger;
        _expenseRepository = eachCategoryRepository;
        _categoryRepository = categoryRepository;
    }

    [HttpPost("AddExpense")]
    public async Task<IActionResult> AddExpenseToCategory([FromBody] ExpenseEntryDTO responseExpenseRecord)
    {
        try
        {
            //check category available or not
            if (!await _categoryRepository.IsCategoryIdUniqueAsync(responseExpenseRecord.CategoryId)) return BadRequest($"category id: {responseExpenseRecord.CategoryId} is invalid");

            // Check if ExpenseDate is in the future
            if (responseExpenseRecord.ExpenseDate > DateTime.UtcNow) return BadRequest("Expense date cannot be in the future.");

            //upload data to database.
            var isAdded = await _expenseRepository.HasAddedExpenseInCategoryAsync(responseExpenseRecord);
            if (isAdded)
            {
                _logger.LogInformation($"EachCategoriesController > AddEachCategoriesDetails > Category added successfully.");
                return Ok("Expense added to a Category successfully.");
            }
            else
            {
                return BadRequest("Data could not be saved, try again.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"ExpenseRecordController > AddExpenseToCategory > Error: {ex.Message}");
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }


    [HttpGet("GetExpensesBetweenDates")]
    public async Task<IActionResult> GetExpensesBetweenDates(DateTime startDate, DateTime endDate)
    {
        // Check if ExpenseDate is in the future
        var validationMessage = _expenseServices.IsDateAndDateRangeValid(startDate, endDate) ;
        if (validationMessage != "valid") return BadRequest(validationMessage);

        try
        {
            // fetch expenses 
            var output = await _expenseRepository.GetExpensesBetweenDatesAsync(startDate, endDate);
            return Ok(output);

        } 
        catch (Exception ex)
        {
            _logger.LogError($"ExpenseRecordController > GetExpensesBetweenDates > Error: {ex.Message}");
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }
}

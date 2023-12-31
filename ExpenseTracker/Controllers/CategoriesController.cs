using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExpenseTracker.Repositories;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;
using ExpenseTracker.DTO;

namespace ExpenseTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    readonly ILogger<CategoriesController> _logger;
    readonly ICategoriesRepository _categoriesRepository;

    public CategoriesController(ILogger<CategoriesController> logger, ICategoriesRepository categoriesRepository)
    {
        _logger = logger;
        _categoriesRepository = categoriesRepository;
    }

    [HttpGet("GetCategories")]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            var categories = await _categoriesRepository.GetAllCategoriesAsync();

            if (categories == null || categories.Count == 0)
            {
                return NotFound("No categories available.");
            }

            return Ok(categories);
        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesController > GetCategories > Error: {ex.Message}");
            return StatusCode(500, "Internal Server Error: An error occurred while processing the request.");
        }
    }

    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory(CategoryEntryDTO responseEntry)
    {
        // user inserted data or not.
        if (responseEntry == null) return BadRequest("No data inserted.");

        try
        {
            // check duplicate or not.
            if (await _categoriesRepository.IsCategoryNameUniqueAsync(responseEntry.CategoryName)) return BadRequest("Duplicate category.");

            //upload data to database.
            var isAdded = await _categoriesRepository.AddCategoryAsync(responseEntry.CategoryName.Trim());
            if (isAdded)
            {
                _logger.LogInformation($"CategoriesController > AddCategory > Category added successfully.");
                return Ok(new { message = "Category added successfully" });
            }
            else
            {
                return BadRequest(new { message = "Data could not be saved, try again" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesController > AddCategory > Error: {ex.Message}");
            return StatusCode(500, "Internal Server Error: An error occurred while processing the request.");
        }
    }

    [HttpDelete("DeleteCategory")]
    public async Task<IActionResult> DeleteCategoryById(int id)
    {
        // check id available or not.
        if (!await _categoriesRepository.IsCategoryIdUniqueAsync(id)) return BadRequest("Category not found.");
        try
        {
            var deleted = await _categoriesRepository.IsCategoryIdDeleted(id);
            if (deleted)
            {
                return Ok(new { message = "Category is deleted successfully" });
            }
            else {
                return BadRequest(new { message = "Internal Server Error: Try again" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesController > DeleteCategoryById > Error: {ex.Message}");
            return StatusCode(500, "Internal Server Error: An error occurred while processing the request.");
        }
    }
    [HttpPut("UpdateCategory")]
    public async Task<IActionResult> UpdateCategoryById(CategoriesModel response)
    {
        // check id available or not.
        if (!await _categoriesRepository.IsCategoryIdUniqueAsync(response.Id)) return BadRequest("Category not found.");
        try
        {
            var updated = await _categoriesRepository.IsCategoryIdUpdated(response);
            if (updated)
            {
                return Ok($"category id: {response.Id} updated successfully");
            }
            else
            {
                return BadRequest("Internal Server Error: try again");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"CategoriesController > UpdateCategoryById > Error: {ex.Message}");
            return StatusCode(500, "Internal Server Error: An error occurred while processing the request.");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

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

            if (await _context.Categories.AnyAsync(x => x.Name == categoryName))
                return false;

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
}
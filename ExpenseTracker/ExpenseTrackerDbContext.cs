using ExpenseTracker.Controllers;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker
{
    public class ExpenseTrackerDbContext : DbContext
    {
        public DbSet<CategoriesModel> Categories { get; set; }
        public DbSet<EachCategoryModel> EachCategory { get; set; }

        // Other configuration and constructor here
    }

}

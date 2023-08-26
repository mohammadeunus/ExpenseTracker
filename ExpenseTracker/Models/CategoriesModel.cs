using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class CategoriesModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

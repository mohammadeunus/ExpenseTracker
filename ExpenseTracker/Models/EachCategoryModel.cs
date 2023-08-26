using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Models
{
    public class EachCategoryModel
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoriesModel Category { get; set; }
    }
}

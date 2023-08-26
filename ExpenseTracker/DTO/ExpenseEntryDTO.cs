using ExpenseTracker.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.DTO;

public class ExpenseEntryDTO
{ 
    public decimal Amount { get; set; }

    public DateTime ExpenseDate { get; set; }
    public int CategoryId { get; set; } 
}
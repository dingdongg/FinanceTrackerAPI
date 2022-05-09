using System.ComponentModel.DataAnnotations;

namespace FinanceTrackerAPI.DTOs
{
    public class TransactionCreateDTO
    {
        [Required]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Enter a non-negative amount")]
        public double Amount { get; set; }

        [Required]
        [Range(1900, int.MaxValue, ErrorMessage = "Enter a year greater than {0}")]
        public int Year { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Enter a month between {0} and {1}")]
        public int Month { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "Enter a day between {0} and {1}")]
        public int Day { get; set; }

        public string? Description { get; set; }
    }
}

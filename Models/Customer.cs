using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_ALB.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "The name customer is required.")]
        [MaxLength(100)]
        [StringLength(100, ErrorMessage =
            "The name customer must be maximum 100 characters.")]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The age customer is required.")]
        [Display(Name = "Age", Description = "The age customer must be between 1 and 100.")]
        [Range(1, 100)]
        public int Age { get; set; }
        
    }
}
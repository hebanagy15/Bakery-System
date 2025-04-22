using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakery_System.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        
        [StringLength(500)]
        public string Comment { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        
        [Required]
        [ForeignKey("BakeryItemId")]
        public int BakeryItemId { get; set; }
        public BakeryItem BakeryItem { get; set; }
    }
}

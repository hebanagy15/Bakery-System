using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bakery_System.Models
{
    public class BakeryItem
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        public int SalesCount { get; set; } = 0;

        public int Discount { get; set; } = 0;

        [Required]
        [Range(0, 1000)]
        [Display(Name = "Available Quantity")]
        public int QuantityInStock { get; set; }

        [Required]
        [StringLength(250)]
        public string ImageURL { get; set; }


        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}

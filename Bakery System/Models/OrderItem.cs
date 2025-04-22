using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakery_System.Models
{
    public class OrderItem
    {
        public int ID { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        [ForeignKey("BakeryItemId")]
        public int BakeryItemId { get; set; }
        public BakeryItem BakeryItem { get; set; }

    }
}

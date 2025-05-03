using System.ComponentModel.DataAnnotations;

namespace Bakery_System.Models
{
    public class Order
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [Range(0.01, 10000)]
        public decimal TotalPrice { get; set; }

       
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }



        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

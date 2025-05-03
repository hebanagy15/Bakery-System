using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakery_System.ViewModels
{
    public class CheckoutViewModel
    {
        [Required]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        public List<ProductSelection> SelectedProducts { get; set; } = new List<ProductSelection>();
    }

    public class ProductSelection
    {
        public int BakeryItemId { get; set; }

        public string BakeryItemName { get; set; }

        public decimal Price { get; set; }

        [Range(0, 1000)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; } = 0;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Bakery_System.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Address { get; set; }

        

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public decimal TotalPrice { get; set; } = 0;

        [Required]
        public string Status { get; set; } = "Pending";

        
    }

}

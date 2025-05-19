using System.ComponentModel.DataAnnotations;

namespace Bakery_System.Models
{
    public class ContactUs
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(1000)]
        public string Message { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

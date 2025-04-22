using System.ComponentModel.DataAnnotations;

namespace Bakery_System.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]   // use regular expression
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]        // use regular expression
        public string PhoneNumber { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]         // in UI show Data Picker
        [Display(Name = "Birth Date")]
       
        public DateTime BirthDate { get; set; }


        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}

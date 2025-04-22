using System.ComponentModel.DataAnnotations;

namespace Bakery_System.Models
{
    public class Table
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Table Number")]
        [Range(1, 10)]
        public int TableNumber { get; set; }              //add in design

        [Required]
        [Range(1, 8)]
        public int Capacity { get; set; }                // change in design 
        public string Status { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}

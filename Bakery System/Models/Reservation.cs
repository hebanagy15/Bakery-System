using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bakery_System.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate {get; set;}

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Reservation Date")]
        public DateTime ReservationDate {get; set;}

        [Required]
        [Display(Name = "Reservation Period")]
        [Range(1, 3)]
        public int DurationInHours { get; set; } 

        [Required]
        [Display(Name = "Table ID")]
        public int TableId { get; set; } // Foreign Key

        [ForeignKey("TableId")]
        public Table Table { get; set; } // Navigation Property

        [Required]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; } // Foreign Key

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; } // Navigation Property

        

        
    }
}

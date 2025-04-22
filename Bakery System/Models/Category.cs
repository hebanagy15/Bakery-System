using System.ComponentModel.DataAnnotations;

namespace Bakery_System.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(250)]
        public string ImageURL { get; set; }

        
        public ICollection<BakeryItem> BakeryItems { get; set; }
    }
}

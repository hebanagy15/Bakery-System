using Bakery_System.Models;

namespace Bakery_System.ViewModels
{
    public class ProductCategoryViewModel
    {
        public List<BakeryItem> BakeryItems { get; set; }
        public List<Category> Categories { get; set; }
    }
}

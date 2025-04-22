using Bakery_System.Models;

namespace Bakery_System.ViewModels
{
    public class HomeViewModel
    {
        public List<BakeryItem> MostPopular { get; set; }
        public List<BakeryItem> Offers { get; set; }
        public List<Category> Categories { get; set; }

       
    }
}

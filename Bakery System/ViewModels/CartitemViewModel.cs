namespace Bakery_System.ViewModels
{
    public class CartitemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }  
        public decimal Price { get; set; }      
        public int Quantity { get; set; }
    }

    public class CartViewModel
    {
        public List<CartitemViewModel> CartItems { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }
}

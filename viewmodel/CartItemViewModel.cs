namespace Library_mangement_system.viewmodel
{
    public class CartItemViewModel
    {
        public int bookid { get; set; }
        public string  Titel { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal total { get; set; }
    }
}

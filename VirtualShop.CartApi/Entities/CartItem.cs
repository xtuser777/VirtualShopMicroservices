namespace VirtualShop.CartApi.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; } = 1;
        public int ProductId { get; set; }
        public Product Product { get; set; } = new Product();
        public int CartHeaderId { get; set; }
        public CartHeader CartHeader { get; set; } = new CartHeader();
    }
}

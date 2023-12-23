namespace VirtualShop.CartApi.Entities;

public class CartHeader
{
    public int Id { get; set; }
    public string UserId { get; set; } = String.Empty;
    public string CouponCode { get; set; } = String.Empty;
}

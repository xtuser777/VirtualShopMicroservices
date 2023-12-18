using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductsApi.Models;

namespace VirtualShop.ProductsApi.Context;

public class ProductsApiContext : DbContext
{
    public ProductsApiContext(DbContextOptions<ProductsApiContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}

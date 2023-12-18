using VirtualShop.ProductsApi.Models;

namespace VirtualShop.ProductsApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> FindAll();
    Task<Product> FindById(int id);
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<Product> Delete(int id);
}

using VirtualShop.ProductsApi.Models;

namespace VirtualShop.ProductsApi.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> FindAll();
    Task<IEnumerable<Category>> FindCategoriesProducts();
    Task<Category> FindById(int id);
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task<Category> Delete(int id);
}

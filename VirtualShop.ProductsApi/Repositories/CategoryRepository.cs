using Microsoft.EntityFrameworkCore;
using System;
using VirtualShop.ProductsApi.Context;
using VirtualShop.ProductsApi.Models;

namespace VirtualShop.ProductsApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ProductsApiContext _context;

    public CategoryRepository(ProductsApiContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> FindAll()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<IEnumerable<Category>> FindCategoriesProducts()
    {
        return await _context.Categories.Include(x => x.Products).ToListAsync();
    }

    public async Task<Category> FindById(int id)
    {
        return await _context.Categories.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Category> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Delete(int id)
    {
        var product = await FindById(id);
        _context.Categories.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using VirtualShop.ProductsApi.Context;
using VirtualShop.ProductsApi.Models;

namespace VirtualShop.ProductsApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductsApiContext _context;
    public ProductRepository(ProductsApiContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> FindAll()
    {
        var products = await _context.Products.Include(c => c.Category).ToListAsync();
        return products;
    }

    public async Task<Product> FindById(int id)
    {
        return await _context.Products.Include(c => c.Category).Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Delete(int id)
    {
        var product = await FindById(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }
}

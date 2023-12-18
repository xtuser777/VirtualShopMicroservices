using AutoMapper;
using VirtualShop.ProductsApi.DTOs;
using VirtualShop.ProductsApi.Models;
using VirtualShop.ProductsApi.Repositories;

namespace VirtualShop.ProductsApi.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private IProductRepository _productRepository;

    public ProductService(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.FindAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        var productEntity = await _productRepository.FindById(id);
        return _mapper.Map<ProductDTO>(productEntity);
    }
    public async Task AddProduct(ProductDTO productDto)
    {
        var productEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Create(productEntity);
        productDto.Id = productEntity.Id;
    }

    public async Task UpdateProduct(ProductDTO productDto)
    {
        var categoryEntity = _mapper.Map<Product>(productDto);
        await _productRepository.Update(categoryEntity);
    }

    public async Task RemoveProduct(int id)
    {
        var productEntity = await _productRepository.FindById(id);
        await _productRepository.Delete(productEntity.Id);
    }
}

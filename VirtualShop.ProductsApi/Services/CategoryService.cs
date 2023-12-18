using AutoMapper;
using VirtualShop.ProductsApi.DTOs;
using VirtualShop.ProductsApi.Models;
using VirtualShop.ProductsApi.Repositories;

namespace VirtualShop.ProductsApi.Services;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.FindAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesEntity = await _categoryRepository.FindCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }


    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoryEntity = await _categoryRepository.FindById(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task AddCategory(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Create(categoryEntity);
        categoryDto.CategoryId = categoryEntity.Id;
    }

    public async Task UpdateCategory(CategoryDTO categoryDto)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.Update(categoryEntity);
    }

    public async Task RemoveCategory(int id)
    {
        var categoryEntity = _categoryRepository.FindById(id).Result;
        await _categoryRepository.Delete(categoryEntity.Id);
    }
}

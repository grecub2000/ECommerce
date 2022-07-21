using AutoMapper;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using ECommerce.Interfaces;
using ECommerce.Repositories;
using ECommerce.Filters;
using ECommerce.Entities;
using ECommerce.DTOs.Brand;
using ECommerce.DTOs.Category;
using ECommerce.Helpers;
using ECommerce.DTOs.Pagination;

namespace ECommerce.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public CategoryManager(IGenericRepository<Brand> brandRepository, IGenericRepository<Category> categoryRepository, IGenericRepository<Item> itemRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CategoryDto>> ListAsync(CategoryFilter filter)
        {
            var categories = _categoryRepository.
                AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                categories = categories.Where(b => b.Name == filter.Name);
            }
            var result = await categories.MapToPagedResultAsync(filter, _mapper.Map<CategoryDto>); 
            return result;
        }
        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.
                AsQueryable().
                Where(b => b.Id == id).
                FirstOrDefaultAsync();
            var result = _mapper.Map<CategoryDto>(category);
            return result;
        }

        public async Task CreateAsync(CategoryCreateDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);

        }
        public async Task UpdateAsync(CategoryUpdateDto categoryDto)
        {
            var category = await _categoryRepository.
                AsQueryable().
                Where(u => u.Id == categoryDto.Id).
                FirstOrDefaultAsync();
                
            if (!string.IsNullOrEmpty(categoryDto.Name))
            {
                category.Name = categoryDto.Name;
            }
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category= await _categoryRepository.
                AsQueryable().
                Where(b => b.Id == id).
                FirstOrDefaultAsync();
            await _categoryRepository.DeleteAsync(category);
        }
    }
}
                                        
using ECommerce.Entities;
using ECommerce.DTOs.Category;
using ECommerce.Managers;
using ECommerce.Filters;
using ECommerce.Helpers;
using ECommerce.DTOs.Pagination;

namespace ECommerce.Interfaces
{
    public interface ICategoryManager
    {
        Task<PagedResult<CategoryDto>> ListAsync(CategoryFilter filter);
        Task<CategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateDto category);
        Task UpdateAsync(CategoryUpdateDto category);
        Task DeleteAsync(int id);
    }
}

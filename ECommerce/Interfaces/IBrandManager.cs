using ECommerce.Entities;
using ECommerce.DTOs.Brand;
using ECommerce.DTOs.Pagination;
using ECommerce.Managers;
using ECommerce.Filters;
namespace ECommerce.Interfaces
{
    public interface IBrandManager
    {
        Task<PagedResult<BrandDto>> ListAsync(BrandFilter filter);
        Task<BrandDto> GetByIdAsync(int id);
        Task CreateAsync(BrandCreateDto brand); 
        Task UpdateAsync(BrandUpdateDto brand);
        Task DeleteAsync(int id);

    }
}

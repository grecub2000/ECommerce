using ECommerce.Entities;
using ECommerce.DTOs.Item;
using ECommerce.Managers;
using ECommerce.Filters;
using ECommerce.Helpers;
using ECommerce.DTOs.Pagination;

namespace ECommerce.Interfaces
{
    public interface IItemManager
    {
        Task<PagedResult<ItemDto>> ListAsync(ItemFilter filter);
        Task<ItemDto> GetByIdAsync(int id);
        Task CreateAsync(ItemCreateDto item);
        Task UpdateAsync(ItemUpdateDto item);
        Task DeleteAsync(int id);
    }
}

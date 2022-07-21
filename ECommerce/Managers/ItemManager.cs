using AutoMapper;
using ECommerce.DTOs.Item;
using ECommerce.DTOs.Pagination;
using ECommerce.Entities;
using ECommerce.Filters;
using ECommerce.Helpers;
using ECommerce.Interfaces;
using ECommerce.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerce.Managers
{
    public class ItemManager : IItemManager
    {
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ItemManager> _logger;

        public ItemManager(IGenericRepository<Brand> brandRepository, IGenericRepository<Category> categoryRepository, IGenericRepository<Item> itemRepository, IMapper mapper, ILogger<ItemManager> logger)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PagedResult<ItemDto>> ListAsync(ItemFilter filter)
        {
            var items = _itemRepository.
                AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                items = items.Where(i => i.Name == filter.Name);
            }
            if (filter.Price is not null)
            {
                items = items.Where(i => i.Price == filter.Price);
            }
            if (filter.MinPrice is not null)
            {
                items = items.Where(i => i.Price >= filter.MinPrice);
            }
            if (filter.MaxPrice is not null)
            {
                items = items.Where(i => i.Price <= filter.MaxPrice);
            }
            if (filter.BrandId is not null)
            {
                items = items.Include(x => x.Brand).Where(x => x.Brand.Id == filter.BrandId);
            }
            if (filter.CategoryId is not null)
            {
                items = items.Where(x => x.Categories.Any(c => c.Id == filter.CategoryId));
                //var itemsFromCat = await _categoryRepository.AsQueryable().Where(u => u.Id == filter.CategoryId).Select(u => u.Items).ToListAsync(); not good
            }
            var result = await items.MapToPagedResultAsync(filter, _mapper.Map<ItemDto>);
            return result;
        }
        public async Task<ItemDto> GetByIdAsync(int id)
        {
            var item = await _itemRepository.
                AsQueryable().
                Where(b => b.Id == id).
                FirstOrDefaultAsync();
            var result = _mapper.Map<ItemDto>(item);
            return result;
        }

        public async Task CreateAsync(ItemCreateDto itemDto)
        {
            _logger.LogInformation($"Received Item {JsonConvert.SerializeObject(itemDto)}");
            var item = _mapper.Map<Item>(itemDto);
            item.Categories = await _categoryRepository.AsQueryable().Where(x => itemDto.Categories.Contains(x.Id)).ToListAsync();
            await _itemRepository.AddAsync(item);
        }
        public async Task UpdateAsync(ItemUpdateDto itemDto)
        {
            var item = await _itemRepository.
                AsQueryable().
                Where(u => u.Id == itemDto.Id).
                FirstOrDefaultAsync();

            if (!string.IsNullOrEmpty(itemDto.Name))
            {
                item.Name = itemDto.Name;
            }
            await _itemRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _itemRepository.
                AsQueryable().
                Where(b => b.Id == id).
                FirstOrDefaultAsync();
            await _itemRepository.DeleteAsync(item);
        }
    }
}

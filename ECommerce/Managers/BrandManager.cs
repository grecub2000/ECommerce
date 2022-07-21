using AutoMapper;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ECommerce.Interfaces;
using ECommerce.Repositories;
using ECommerce.Filters;
using ECommerce.Entities;
using ECommerce.DTOs.Brand;
using ECommerce.Helpers;
using ECommerce.DTOs.Pagination;



namespace ECommerce.Managers
{
    public class BrandManager : IBrandManager
    {
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandManager> _logger;

        public BrandManager(IGenericRepository<Brand> brandRepository, IGenericRepository<Category> categoryRepository, IGenericRepository<Item> itemRepository, IMapper mapper, ILogger<BrandManager> logger)
        {
            _brandRepository = brandRepository;
            _categoryRepository = categoryRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PagedResult<BrandDto>> ListAsync(BrandFilter filter)
        {

            _logger.LogInformation("Received Get Request");
            var brands = _brandRepository.
                AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                brands = brands.Where(b => b.Name == filter.Name);
            }
            //var result = await brands.Select(brand => _mapper.Map<BrandDto>(brand)).ToListAsync();
            var result = await brands.MapToPagedResultAsync(filter, _mapper.Map<BrandDto>);
            return result;
        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {
            var brand = await _brandRepository.
                AsQueryable().
                Where(b => b.Id == id).
                FirstOrDefaultAsync();
            var result = _mapper.Map<BrandDto>(brand);
            return result;
        }

        public async Task CreateAsync(BrandCreateDto brandDto)
        {
            _logger.LogInformation($"Received Brand {JsonConvert.SerializeObject(brandDto)}");
            var brand = _mapper.Map<Brand>(brandDto);
            await _brandRepository.AddAsync(brand);
        }

        public async Task UpdateAsync(BrandUpdateDto brandDto)
        {
            var brand = await _brandRepository.
                AsQueryable().
                Where(b => b.Id == brandDto.Id).
                FirstOrDefaultAsync();

            if (!string.IsNullOrEmpty(brandDto.Name))
            {
                brand.Name = brandDto.Name;
            }
            await _brandRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _brandRepository.
                AsQueryable().
                Where(b => b.Id == id).
                FirstOrDefaultAsync();
            await _brandRepository.DeleteAsync(brand);
        }

    }
}

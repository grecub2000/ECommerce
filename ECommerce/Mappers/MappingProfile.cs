using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using ECommerce.Entities;
using ECommerce.DTOs.Brand;
using ECommerce.DTOs.Category;
using ECommerce.DTOs.Item;



namespace ECommerce.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<DateTime, DateOnly>();

            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, BrandCreateDto>().ReverseMap();
            
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();

            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Item, ItemCreateDto>().ReverseMap().ForMember(x => x.Categories, opt => opt.Ignore());



        }
    }
}

using ECommerce.DTOs.Brand;
using ECommerce.DTOs.Category;

namespace ECommerce.DTOs.Item
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public BrandDto Brand { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}

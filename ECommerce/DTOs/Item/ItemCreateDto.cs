namespace ECommerce.DTOs.Item
{
    public class ItemCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public List<int> Categories { get; set; }
        public int BrandId { get; set; }
    }
}

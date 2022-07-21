namespace ECommerce.DTOs.Item
{
    public class ItemUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public List<int> CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}

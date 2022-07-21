namespace ECommerce.Filters
{
    public class ItemFilter : BaseFilter
    {
        //public int Id { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public float? MinPrice { get; set; }
        public float? MaxPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}

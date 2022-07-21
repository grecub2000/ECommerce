using ECommerce.Constants;

namespace ECommerce.Filters
{
    public class BaseFilter
    {
        public bool IsPagingEnabled { get; set; } = false;
        public int PageSize { get; set; } = PaginationConstants.DefaultPageSize;
        public int Page { get; set; } = PaginationConstants.DefaultPage;
    }
}

namespace CatalogApi.Models
{
    public class ItemsFilterDto
    {
        public int CategoryId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }
}

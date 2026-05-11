using DapperKaggle.Dtos.ProductDtos;

namespace DapperKaggle.Models
{
    public class ProductListViewModel
    {
        public List<ResultProductDto> Products { get; set; } = new();

        public string Search { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public List<string> Categories { get; set; } = new();
        public List<string> Brands { get; set; } = new();
    }
}

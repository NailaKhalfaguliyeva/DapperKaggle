using DapperKaggle.Dtos.ProductDtos;
using DapperKaggle.Models;

namespace DapperKaggle.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly ProductQueryService _query;

        public ProductService(ProductQueryService query)
        {
            _query = query;
        }

        public ProductListViewModel GetProducts(string search, string category, string brand, int page, int pageSize)
        {
            var products = _query.GetProducts(search, category, brand, page, pageSize);
            var totalCount = _query.GetTotalCount(search, category, brand);

            return new ProductListViewModel
            {
                Products = products,
                Search = search,
                Category = category,
                Brand = brand,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Categories = _query.GetCategories(),
                Brands = _query.GetBrands()
            };
        }

        public GetProductByIdDto GetProductById(string id)
            => _query.GetProductById(id);

        public void CreateProduct(CreateProductDto dto)
            => _query.CreateProduct(dto);

        public void UpdateProduct(UpdateProductDto dto)
            => _query.UpdateProduct(dto);

        public void DeleteProduct(string id)
            => _query.DeleteProduct(id);
    }
}
using DapperKaggle.Dtos.ProductDtos;
using DapperKaggle.Models;

namespace DapperKaggle.Services.ProductServices
{
    public interface IProductService
    {
        ProductListViewModel GetProducts(string search, string category, string brand, int page, int pageSize);
        GetProductByIdDto GetProductById(string id);
        void CreateProduct(CreateProductDto dto);
        void UpdateProduct(UpdateProductDto dto);
        void DeleteProduct(string id);
    }
}

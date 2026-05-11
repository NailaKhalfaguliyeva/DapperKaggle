using Dapper;
using DapperKaggle.Context;
using DapperKaggle.Dtos.ProductDtos;
using Microsoft.Data.SqlClient;

namespace DapperKaggle.Services.ProductServices
{
    public class ProductQueryService
    {
        private readonly DapperContext _context;

        public ProductQueryService(DapperContext context)
        {
            _context = context;
        }

        public List<ResultProductDto> GetProducts(string search, string category, string brand, int page, int pageSize)
        {
            using var connection = _context.CreateConnection();

            return connection.Query<ResultProductDto>(@"
                SELECT
                    ProductId,
                    ProductName,
                    Category,
                    SubCategory,
                    Brand,
                    UnitPrice
                FROM Products
                WHERE
                    (@search IS NULL OR @search = '' OR ProductName LIKE '%' + @search + '%')
                    AND (@category IS NULL OR @category = '' OR Category = @category)
                    AND (@brand IS NULL OR @brand = '' OR Brand = @brand)
                ORDER BY ProductName
                OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY
            ", new
            {
                search,
                category,
                brand,
                skip = (page - 1) * pageSize,
                take = pageSize
            }).ToList();
        }

        public int GetTotalCount(string search, string category, string brand)
        {
            using var connection = _context.CreateConnection();

            return connection.ExecuteScalar<int>(@"
                SELECT COUNT(*)
                FROM Products
                WHERE
                    (@search IS NULL OR @search = '' OR ProductName LIKE '%' + @search + '%')
                    AND (@category IS NULL OR @category = '' OR Category = @category)
                    AND (@brand IS NULL OR @brand = '' OR Brand = @brand)
            ", new { search, category, brand });
        }

        public GetProductByIdDto GetProductById(string id)
        {
            using var connection = _context.CreateConnection();

            return connection.QueryFirstOrDefault<GetProductByIdDto>(@"
                SELECT
                    ProductId,
                    ProductName,
                    Category,
                    SubCategory,
                    Brand,
                    UnitPrice
                FROM Products
                WHERE ProductId = @ProductId
            ", new { ProductId = id });
        }

        public void CreateProduct(CreateProductDto dto)
        {
            using var connection = _context.CreateConnection();

            connection.Execute(@"
        INSERT INTO Products
        (

            ProductName,
            Category,
            SubCategory,
            Brand,
            UnitPrice
        )
        VALUES
        (
            @ProductName,
            @Category,
            @SubCategory,
            @Brand,
            @UnitPrice
        )
    ", dto);
        }

        public void UpdateProduct(UpdateProductDto dto)
        {
            using var connection = _context.CreateConnection();

            connection.Execute(@"
                UPDATE Products
                SET
                    ProductName = @ProductName,
                    Category = @Category,
                    SubCategory = @SubCategory,
                    Brand = @Brand,
                    UnitPrice = @UnitPrice
                WHERE ProductId = @ProductId
            ", dto);
        }

        public void DeleteProduct(string id)
        {
            using var connection = _context.CreateConnection();

            connection.Execute(@"
                DELETE FROM Products
                WHERE ProductId = @ProductId
            ", new { ProductId = id });
        }

        public List<string> GetCategories()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<string>(@"
                SELECT DISTINCT Category
                FROM Products
                WHERE Category IS NOT NULL
                ORDER BY Category
            ").ToList();
        }

        public List<string> GetBrands()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<string>(@"
                SELECT DISTINCT Brand
                FROM Products
                WHERE Brand IS NOT NULL
                ORDER BY Brand
            ").ToList();
        }
    }
}

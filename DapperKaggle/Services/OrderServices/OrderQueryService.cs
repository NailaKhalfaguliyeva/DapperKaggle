using Dapper;
using DapperKaggle.Context;
using DapperKaggle.Dtos.OrderDtos;

namespace DapperKaggle.Services.OrderServices
{
    public class OrderQueryService
    {
        private readonly DapperContext _context;

        public OrderQueryService(DapperContext context)
        {
            _context = context;
        }

        public List<OrderListDto> GetOrders(
            string search,
            string country,
            string orderStatus,
            string paymentMethod,
            int page,
            int pageSize)
        {
            using var connection = _context.CreateConnection();

            return connection.Query<OrderListDto>(@"
        SELECT
            CAST(o.OrderId AS NVARCHAR(50)) AS OrderId,
            o.OrderDate,
            o.CustomerId,
            '-' AS CustomerName,
            o.Country,
            o.City,
            o.OrderStatus,
            o.PaymentMethod,
            o.PaymentStatus,
            o.ShippingMethod,
            o.ShippingStatus,
            o.TotalAmount
        FROM Orders o
        WHERE
            (@search IS NULL OR @search = '' 
                OR CAST(o.OrderId AS NVARCHAR(50)) LIKE '%' + @search + '%' 
                OR o.CustomerId LIKE '%' + @search + '%')
            AND (@country IS NULL OR @country = '' OR o.Country = @country)
            AND (@orderStatus IS NULL OR @orderStatus = '' OR o.OrderStatus = @orderStatus)
            AND (@paymentMethod IS NULL OR @paymentMethod = '' OR o.PaymentMethod = @paymentMethod)
        ORDER BY o.OrderDate DESC
        OFFSET @skip ROWS FETCH NEXT @take ROWS ONLY
    ", new
            {
                search,
                country,
                orderStatus,
                paymentMethod,
                skip = (page - 1) * pageSize,
                take = pageSize
            }).ToList();
        }
        public int GetTotalCount(string search, string country, string orderStatus, string paymentMethod)
        {
            using var connection = _context.CreateConnection();

            return connection.ExecuteScalar<int>(@"
        SELECT COUNT(*)
        FROM Orders o
        WHERE
            (@search IS NULL OR @search = '' 
                OR CAST(o.OrderId AS NVARCHAR(50)) LIKE '%' + @search + '%' 
                OR o.CustomerId LIKE '%' + @search + '%')
            AND (@country IS NULL OR @country = '' OR o.Country = @country)
            AND (@orderStatus IS NULL OR @orderStatus = '' OR o.OrderStatus = @orderStatus)
            AND (@paymentMethod IS NULL OR @paymentMethod = '' OR o.PaymentMethod = @paymentMethod)
    ", new
            {
                search,
                country,
                orderStatus,
                paymentMethod
            });
        }

        public List<string> GetCountries()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<string>(@"
                SELECT DISTINCT Country
                FROM Orders
                WHERE Country IS NOT NULL
                ORDER BY Country
            ").ToList();
        }

        public List<string> GetOrderStatuses()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<string>(@"
                SELECT DISTINCT OrderStatus
                FROM Orders
                WHERE OrderStatus IS NOT NULL
                ORDER BY OrderStatus
            ").ToList();
        }

        public List<string> GetPaymentMethods()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<string>(@"
                SELECT DISTINCT PaymentMethod
                FROM Orders
                WHERE PaymentMethod IS NOT NULL
                ORDER BY PaymentMethod
            ").ToList();
        }
    }
}

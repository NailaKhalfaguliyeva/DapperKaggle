using Dapper;
using DapperKaggle.Context;
using DapperKaggle.Dtos.DashboardDtos;

namespace DapperKaggle.Services.Dashboard
{
    public class DashboardChartQueryService
    {
        private readonly DapperContext _context;

        public DashboardChartQueryService(DapperContext context)
        {
            _context = context;
        }

        public List<ChartDto> GetOrdersByCountry()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<ChartDto>(@"
                SELECT TOP 10
                    Country AS Name,
                    COUNT(*) AS Value
                FROM Orders
                WHERE Country IS NOT NULL
                GROUP BY Country
                ORDER BY Value DESC
            ").ToList();
        }

        public List<ChartDto> GetRevenueByCountry()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<ChartDto>(@"
                SELECT TOP 10
                    Country AS Name,
                    ISNULL(SUM(TotalAmount), 0) AS Value
                FROM Orders
                WHERE Country IS NOT NULL
                GROUP BY Country
                ORDER BY Value DESC
            ").ToList();
        }

        public List<ChartDto> GetOrdersByStatus()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<ChartDto>(@"
                SELECT
                    OrderStatus AS Name,
                    COUNT(*) AS Value
                FROM Orders
                WHERE OrderStatus IS NOT NULL
                GROUP BY OrderStatus
                ORDER BY Value DESC
            ").ToList();
        }

        public List<ChartDto> GetProductsByCategory()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<ChartDto>(@"
                SELECT TOP 10
                    Category AS Name,
                    COUNT(*) AS Value
                FROM Products
                WHERE Category IS NOT NULL
                GROUP BY Category
                ORDER BY Value DESC
            ").ToList();
        }

        public List<ChartDto> GetPaymentMethods()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<ChartDto>(@"
                SELECT
                    PaymentMethod AS Name,
                    COUNT(*) AS Value
                FROM Orders
                WHERE PaymentMethod IS NOT NULL
                GROUP BY PaymentMethod
                ORDER BY Value DESC
            ").ToList();
        }

        public List<ChartDto> GetReviewsByRating()
        {
            using var connection = _context.CreateConnection();

            return connection.Query<ChartDto>(@"
                SELECT
                    CAST(Rating AS NVARCHAR(10)) AS Name,
                    COUNT(*) AS Value
                FROM Reviews
                WHERE Rating IS NOT NULL
                GROUP BY Rating
                ORDER BY Rating
            ").ToList();
        }
    }
}
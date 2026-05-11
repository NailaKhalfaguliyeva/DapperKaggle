using Dapper;
using DapperKaggle.Context;

namespace DapperKaggle.Services.Dashboard
{
    public class DashboardStatsQueryService
    {
        private readonly DapperContext _context;

        public DashboardStatsQueryService(DapperContext context)
        {
            _context = context;
        }

        public int GetTotalCustomers()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Customers");
        }

        public int GetTotalProducts()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Products");
        }

        public int GetTotalOrders()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Orders");
        }

        public int GetTotalOrderItems()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM OrderItems");
        }

        public int GetTotalReviews()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Reviews");
        }

        public double GetTotalRevenue()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<double>(@"
                SELECT ISNULL(SUM(TotalAmount), 0)
                FROM Orders
            ");
        }

        public double GetTotalProfit()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<double>(@"
                SELECT ISNULL(SUM(Profit), 0)
                FROM OrderItems
            ");
        }

        public double GetAverageOrderAmount()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<double>(@"
                SELECT ISNULL(AVG(TotalAmount), 0)
                FROM Orders
            ");
        }

        public double GetAverageProductPrice()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<double>(@"
                SELECT ISNULL(AVG(UnitPrice), 0)
                FROM Products
            ");
        }

        public double GetAverageRating()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<double>(@"
                SELECT ISNULL(AVG(CAST(Rating AS FLOAT)), 0)
                FROM Reviews
            ");
        }

        public int GetTotalCountries()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<int>(@"
                SELECT COUNT(DISTINCT Country)
                FROM Orders
                WHERE Country IS NOT NULL
            ");
        }

        public int GetCompletedOrders()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<int>(@"
                SELECT COUNT(*)
                FROM Orders
                WHERE OrderStatus = 'Completed'
            ");
        }

        public int GetCancelledOrders()
        {
            using var connection = _context.CreateConnection();
            return connection.ExecuteScalar<int>(@"
                SELECT COUNT(*)
                FROM Orders
                WHERE OrderStatus = 'Cancelled'
            ");
        }
    }
}
using Dapper;
using DapperKaggle.Context;

namespace DapperKaggle.Services.Dashboard
{
    public class DashboardTopQueryService
    {
        private readonly DapperContext _context;

        public DashboardTopQueryService(DapperContext context)
        {
            _context = context;
        }

        public string GetTopCountry()
        {
            using var connection = _context.CreateConnection();

            return connection.QueryFirstOrDefault<string>(@"
                SELECT TOP 1 Country
                FROM Orders
                WHERE Country IS NOT NULL
                GROUP BY Country
                ORDER BY COUNT(*) DESC
            ") ?? "-";
        }

        public string GetTopCity()
        {
            using var connection = _context.CreateConnection();

            return connection.QueryFirstOrDefault<string>(@"
                SELECT TOP 1 City
                FROM Orders
                WHERE City IS NOT NULL
                GROUP BY City
                ORDER BY COUNT(*) DESC
            ") ?? "-";
        }

        public string GetTopProduct()
        {
            using var connection = _context.CreateConnection();

            return connection.QueryFirstOrDefault<string>(@"
                SELECT TOP 1 p.ProductName
                FROM OrderItems oi
                INNER JOIN Products p 
                    ON LTRIM(RTRIM(CAST(oi.ProductId AS NVARCHAR(50)))) 
                     = LTRIM(RTRIM(CAST(p.ProductId AS NVARCHAR(50))))
                WHERE p.ProductName IS NOT NULL
                GROUP BY p.ProductName
                ORDER BY COUNT(*) DESC
            ") ?? "-";
        }

        public string GetTopCategory()
        {
            using var connection = _context.CreateConnection();

            return connection.QueryFirstOrDefault<string>(@"
                SELECT TOP 1 Category
                FROM Products
                WHERE Category IS NOT NULL
                GROUP BY Category
                ORDER BY COUNT(*) DESC
            ") ?? "-";
        }

        public string GetTopPaymentMethod()
        {
            using var connection = _context.CreateConnection();

            return connection.QueryFirstOrDefault<string>(@"
                SELECT TOP 1 PaymentMethod
                FROM Orders
                WHERE PaymentMethod IS NOT NULL
                GROUP BY PaymentMethod
                ORDER BY COUNT(*) DESC
            ") ?? "-";
        }

        public string GetMostExpensiveProduct()
        {
            using var connection = _context.CreateConnection();

            return connection.QueryFirstOrDefault<string>(@"
                SELECT TOP 1 ProductName
                FROM Products
                WHERE ProductName IS NOT NULL
                ORDER BY UnitPrice DESC
            ") ?? "-";
        }

        public string GetCheapestProduct()
        {
            using var connection = _context.CreateConnection();

            return connection.QueryFirstOrDefault<string>(@"
                SELECT TOP 1 ProductName
                FROM Products
                WHERE ProductName IS NOT NULL
                  AND UnitPrice > 0
                ORDER BY UnitPrice ASC
            ") ?? "-";
        }
    }
}
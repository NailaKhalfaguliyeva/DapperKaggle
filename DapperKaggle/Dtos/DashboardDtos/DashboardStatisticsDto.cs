namespace DapperKaggle.Dtos.DashboardDtos
{
   
        public class DashboardStatisticsDto
        {
            public int TotalCustomers { get; set; }
            public int TotalProducts { get; set; }
            public int TotalOrders { get; set; }
            public int TotalOrderItems { get; set; }
            public int TotalReviews { get; set; }

            public double TotalRevenue { get; set; }
            public double TotalProfit { get; set; }
            public double AverageOrderAmount { get; set; }
            public double AverageProductPrice { get; set; }
            public double AverageRating { get; set; }

            public int TotalCountries { get; set; }
            public string TopCountry { get; set; }
            public string TopCity { get; set; }
            public string TopProduct { get; set; }
            public string TopCategory { get; set; }
            public string TopPaymentMethod { get; set; }

            public string MostExpensiveProduct { get; set; }
            public string CheapestProduct { get; set; }

            public int CompletedOrders { get; set; }
            public int CancelledOrders { get; set; }

            public List<ChartDto> OrdersByCountry { get; set; } = new();
            public List<ChartDto> RevenueByCountry { get; set; } = new();
            public List<ChartDto> OrdersByStatus { get; set; } = new();
            public List<ChartDto> ProductsByCategory { get; set; } = new();
            public List<ChartDto> PaymentMethods { get; set; } = new();
            public List<ChartDto> ReviewsByRating { get; set; } = new();
        }
    }

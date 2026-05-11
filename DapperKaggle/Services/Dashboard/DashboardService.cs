using DapperKaggle.Dtos.DashboardDtos;

namespace DapperKaggle.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly DashboardStatsQueryService _statsQueryService;
        private readonly DashboardTopQueryService _topQueryService;
        private readonly DashboardChartQueryService _chartQueryService;

        public DashboardService(
            DashboardStatsQueryService statsQueryService,
            DashboardTopQueryService topQueryService,
            DashboardChartQueryService chartQueryService)
        {
            _statsQueryService = statsQueryService;
            _topQueryService = topQueryService;
            _chartQueryService = chartQueryService;
        }

        public DashboardStatisticsDto GetDashboardStatistics()
        
            => new DashboardStatisticsDto
            {
                TotalCustomers = _statsQueryService.GetTotalCustomers(),
                TotalProducts = _statsQueryService.GetTotalProducts(),
                TotalOrders = _statsQueryService.GetTotalOrders(),
                TotalOrderItems = _statsQueryService.GetTotalOrderItems(),
                TotalReviews = _statsQueryService.GetTotalReviews(),

                TotalRevenue = _statsQueryService.GetTotalRevenue(),
                TotalProfit = _statsQueryService.GetTotalProfit(),
                AverageOrderAmount = _statsQueryService.GetAverageOrderAmount(),
                AverageProductPrice = _statsQueryService.GetAverageProductPrice(),
                AverageRating = _statsQueryService.GetAverageRating(),

                TotalCountries = _statsQueryService.GetTotalCountries(),
                CompletedOrders = _statsQueryService.GetCompletedOrders(),
                CancelledOrders = _statsQueryService.GetCancelledOrders(),

                TopCountry = _topQueryService.GetTopCountry(),
                TopCity = _topQueryService.GetTopCity(),
                TopProduct = _topQueryService.GetTopProduct(),
                TopCategory = _topQueryService.GetTopCategory(),
                TopPaymentMethod = _topQueryService.GetTopPaymentMethod(),
                MostExpensiveProduct = _topQueryService.GetMostExpensiveProduct(),
                CheapestProduct = _topQueryService.GetCheapestProduct(),

                OrdersByCountry = _chartQueryService.GetOrdersByCountry(),
                RevenueByCountry = _chartQueryService.GetRevenueByCountry(),
                OrdersByStatus = _chartQueryService.GetOrdersByStatus(),
                ProductsByCategory = _chartQueryService.GetProductsByCategory(),
                PaymentMethods = _chartQueryService.GetPaymentMethods(),
                ReviewsByRating = _chartQueryService.GetReviewsByRating()
            };
        }
    }

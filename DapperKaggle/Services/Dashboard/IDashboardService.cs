using DapperKaggle.Dtos.DashboardDtos;

namespace DapperKaggle.Services.Dashboard
{
    public interface IDashboardService
    {
        DashboardStatisticsDto GetDashboardStatistics();
    }
}
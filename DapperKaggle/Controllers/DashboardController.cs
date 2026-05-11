using DapperKaggle.Services.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace DapperKaggle.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        
            => View(_dashboardService.GetDashboardStatistics());
        }
    }

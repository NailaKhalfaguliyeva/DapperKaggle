using DapperKaggle.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperKaggle.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index(string search, string country, string orderStatus, string paymentMethod, int page = 1)
        {
            int pageSize = 20;

            var model = _orderService.GetOrders(search, country, orderStatus, paymentMethod, page, pageSize);

            return View(model);
        }
    }
}
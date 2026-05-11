using DapperKaggle.Models;

namespace DapperKaggle.Services.OrderServices
{
    public interface IOrderService
    {
        OrderListViewModel GetOrders(
            string search,
            string country,
            string orderStatus,
            string paymentMethod,
            int page,
            int pageSize);
    }
}

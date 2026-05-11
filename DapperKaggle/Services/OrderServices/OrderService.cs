using Dapper;
using DapperKaggle.Dtos.OrderDtos;
using DapperKaggle.Models;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DapperKaggle.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly OrderQueryService _query;

        public OrderService(OrderQueryService query)
        {
            _query = query;
        }

        public OrderListViewModel GetOrders(string search, string country, string orderStatus, string paymentMethod, int page, int pageSize)
        {
            var orders = _query.GetOrders(search, country, orderStatus, paymentMethod, page, pageSize);
            var totalCount = _query.GetTotalCount(search, country, orderStatus, paymentMethod);

            return new OrderListViewModel
            {
                Orders = orders,
                Search = search,
                Country = country,
                OrderStatus = orderStatus,
                PaymentMethod = paymentMethod,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Countries = _query.GetCountries(),
                OrderStatuses = _query.GetOrderStatuses(),
                PaymentMethods = _query.GetPaymentMethods()
            };
        }
    }
}
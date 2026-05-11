using DapperKaggle.Dtos.OrderDtos;

namespace DapperKaggle.Models
{
    public class OrderListViewModel
    {
        public List<OrderListDto> Orders { get; set; } = new();

        public string Search { get; set; }
        public string Country { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentMethod { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public List<string> Countries { get; set; } = new();
        public List<string> OrderStatuses { get; set; } = new();
        public List<string> PaymentMethods { get; set; } = new();
    }
}

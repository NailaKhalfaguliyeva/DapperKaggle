namespace DapperKaggle.Dtos.OrderDtos
{

        public class OrderListDto
        {
            public string OrderId { get; set; }
            public DateTime? OrderDate { get; set; }

            public string CustomerId { get; set; }
            public string CustomerName { get; set; }

            public string Country { get; set; }
            public string City { get; set; }

            public string OrderStatus { get; set; }
            public string PaymentMethod { get; set; }
            public string PaymentStatus { get; set; }

            public string ShippingMethod { get; set; }
            public string ShippingStatus { get; set; }

            public double TotalAmount { get; set; }
        }
    }

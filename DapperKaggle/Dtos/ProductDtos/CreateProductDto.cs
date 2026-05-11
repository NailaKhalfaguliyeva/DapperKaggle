namespace DapperKaggle.Dtos.ProductDtos
{
  
        public class CreateProductDto
        {
            public string ProductName { get; set; }

            public string Category { get; set; }
            public string SubCategory { get; set; }
            public string Brand { get; set; }

            public double UnitPrice { get; set; }
        }
    }
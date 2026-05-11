using DapperKaggle.Dtos.ProductDtos;
using DapperKaggle.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace DapperKaggle.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(string search, string category, string brand, int page = 1)
        {
            int pageSize = 20;

            var model = _productService.GetProducts(search, category, brand, page, pageSize);

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto dto)
        {
            _productService.CreateProduct(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(string id)
        {
            var value = _productService.GetProductById(id);

            if (value == null)
            {
                return NotFound();
            }

            var model = new UpdateProductDto
            {
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                Category = value.Category,
                SubCategory = value.SubCategory,
                Brand = value.Brand,
                UnitPrice = value.UnitPrice
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductDto dto)
        {
            _productService.UpdateProduct(dto);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(string id)
        {
            _productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
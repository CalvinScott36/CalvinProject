using CalvinProject.Models;
using CalvinProject.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalvinProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductInterface productRepository;

        public ProductController(IProductInterface prodRepository, ILogger<HomeController> logger)
        {
            this._logger = logger;
            this.productRepository = prodRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            var products = productRepository.GetProducts();
            return Json(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product data)
        {
            var productResponse = new AddProductResponse
            {
                NewProduct = data
            };
            productRepository.AddProduct(productResponse);
            return Json(productResponse);
        }



    }
}

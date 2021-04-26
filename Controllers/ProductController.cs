using CalvinProject.Models;
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
    }
}

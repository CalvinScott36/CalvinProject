using CalvinProject.Models;
using System.Collections.Generic;

namespace CalvinProject.Response
{
    public class GetProductsResponse
    {
        public List<Product> Products { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}

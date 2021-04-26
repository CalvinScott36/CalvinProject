using CalvinProject.Models;

namespace CalvinProject.Response
{
    public class AddProductResponse
    {
        public Product NewProduct { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
        public string UrlLocation { get; set; } = "";
    }
}

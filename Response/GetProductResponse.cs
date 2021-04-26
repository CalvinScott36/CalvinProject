using CalvinProject.Models;

namespace CalvinProject.Response
{
    public class GetProductResponse
    {
        public Product Product { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}

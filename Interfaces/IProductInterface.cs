using System.Collections.Generic;

namespace CalvinProject.Models
{
    public interface IProductInterface
    {
        Product AddProduct(Product newProduct);
        Product GetProduct(Product product);
        List<Product> GetProducts();
        Product UpdateProduct(Product product);
    }
}
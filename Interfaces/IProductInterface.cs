using CalvinProject.Response;

namespace CalvinProject.Models
{
    public interface IProductInterface
    {
        Product AddProduct(AddProductResponse newProductRes);
        GetProductResponse GetProduct(Product product);
        GetProductsResponse GetProducts();
        Product UpdateProduct(Product product);
    }
}
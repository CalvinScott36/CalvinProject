using CalvinProject.Response;

namespace CalvinProject.Models
{
    public interface IProductInterface
    {
        Product AddProduct(AddProductResponse newProductRes);
        GetProductResponse GetProduct(int productId);
        GetProductsResponse GetProducts();
        Product UpdateProduct(Product product);
    }
}
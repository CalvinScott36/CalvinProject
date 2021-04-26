using CalvinProject.Response;
using System;
using System.Linq;
namespace CalvinProject.Models
{
    public class ProductSQLRepository : IProductInterface
    {
        public AppDbContext context;

        public ProductSQLRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Product AddProduct(AddProductResponse newProductRes)
        {
            using (context)
            {
                try
                {
                    if (!string.IsNullOrEmpty(newProductRes.NewProduct.Name)
                        || string.IsNullOrEmpty(newProductRes.NewProduct.Description))
                    {
                        var product = context.Products.Where(prod => prod.Name == newProductRes.NewProduct.Name && prod.Price == newProductRes.NewProduct.Price).ToList();
                        if (!product.Any())
                        {
                            context.Products.Add(newProductRes.NewProduct);
                            newProductRes.Success = context.SaveChanges() != 0;
                        }
                        else
                        {
                            newProductRes.Success = false;
                            newProductRes.ErrorMessage = $"The product {newProductRes.NewProduct.Name} already exists.";
                        }
                    }
                    else
                    {
                        newProductRes.Success = false;
                        newProductRes.ErrorMessage = "The product must have the following details: price, name and description.";
                    }
                }
                catch (Exception ex)
                {
                    newProductRes.Success = false;
                    newProductRes.ErrorMessage = $"An error has occured: {ex.Message} {ex.InnerException}";
                }

            }
            return newProductRes.NewProduct;
        }

        public GetProductResponse GetProduct(Product product)
        {
            var productSearch = new GetProductResponse();
            using (context)
            {
                productSearch.Product = context.Products.FirstOrDefault(prod => prod.Id == product.Id || prod.Name == product.Name);
                return productSearch;
            }
        }

        public GetProductsResponse GetProducts()
        {
            var productRes = new GetProductsResponse();
            using (context)
            {
                try
                {
                    productRes.Products = context.Products.ToList();
                    productRes.Success = true;
                } catch(Exception ex)
                {
                    productRes.Success =false;
                    productRes.ErrorMessage = $"An error has occured {ex.Message} {ex.InnerException}";
                }
                return productRes;
            }
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
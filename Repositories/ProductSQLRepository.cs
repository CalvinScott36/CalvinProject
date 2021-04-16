using System;
using System.Collections.Generic;
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

        public Product AddProduct(Product newProduct)
        {
            using (context)
            {
                var product = context.Products.Where(prod => prod.Name == newProduct.Name && prod.Price == newProduct.Price);
                if (product == null)
                {
                    context.Products.Add(newProduct);
                    context.SaveChanges();
                }
            }
            return newProduct;
        }

        public Product GetProduct(Product product)
        {
            var productSearch = new Product();
            using (context)
            {
                productSearch = context.Products.FirstOrDefault(prod => prod.Id == product.Id || prod.Name == product.Name);
                return productSearch;
            }
        }

        public List<Product> GetProducts()
        {
            using (context)
            {
                return context.Products.ToList();
            }
        }

        public Product UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
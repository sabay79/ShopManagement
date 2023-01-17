using SM.Business.Models;

namespace SM.Business.DataServices
{
    public class ProductService
    {
        private List<ProductModel> products = new List<ProductModel>();
        public List<ProductModel> GetAll() 
        {
            products.Add(new ProductModel { Id = 1, Name = "Product 1" });
            products.Add(new ProductModel { Id = 2, Name = "Product 2" });
            products.Add(new ProductModel { Id = 3, Name = "Product 3" });
            products.Add(new ProductModel { Id = 4, Name = "Product 4" });
            products.Add(new ProductModel { Id = 5, Name = "Product 5" });

            return products;
        }
    }
}
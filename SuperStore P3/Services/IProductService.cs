using Models;

namespace EcoPower_Logistics.Services
{
    public interface IProductService
    {
        Product GetProductById(int? id);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
    }
}

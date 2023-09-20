using Models;

namespace EcoPower_Logistics.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetProductById(int? id);
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
    }
}

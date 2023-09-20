using Data;
using Models;

namespace EcoPower_Logistics.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(SuperStoreContext context) : base(context) { }

        public Product GetProductById(int? id)
        {
            return GetAll().FirstOrDefault(m => m.ProductId == id);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }
        public void AddProduct(Product product)
        {
            Add(product);
        }
        public void UpdateProduct(Product product)
        {
            Update(product);
        }
        public void RemoveProduct(Product product)
        {
            Remove(product);
        }
    }
}

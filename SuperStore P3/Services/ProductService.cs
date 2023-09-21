using EcoPower_Logistics.Repositories;
using Models;

namespace EcoPower_Logistics.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _prodRepo;
        public ProductService(IProductRepository prodRepo) 
        { 
            _prodRepo = prodRepo;
        }

        public Product GetProductById(int? id)
        {
            return _prodRepo.GetAll().FirstOrDefault(m => m.ProductId == id);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _prodRepo.GetAll().ToList();
        }
        public void AddProduct(Product product)
        {
            _prodRepo.Add(product);
        }
        public void UpdateProduct(Product product)
        {
            _prodRepo.Update(product);
        }
        public void RemoveProduct(Product product)
        {
            _prodRepo.Remove(product);
        }
    }
}

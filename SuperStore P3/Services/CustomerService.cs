using EcoPower_Logistics.Repositories;
using Models;

namespace EcoPower_Logistics.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _custRepo;

        public CustomerService(ICustomerRepository custRepo)
        {
            _custRepo = custRepo;
        }
        public Customer GetCustomerById(int? id)
        {
            return _custRepo.GetAll().FirstOrDefault(m => m.CustomerId == id);
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _custRepo.GetAll().ToList();
        }
        public void AddCustomer(Customer customer)
        {
            _custRepo.Add(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            _custRepo.Update(customer);
        }
        public void RemoveCustomer(Customer customer)
        {
            _custRepo.Remove(customer);
        }
    }
}

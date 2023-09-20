using Models;

namespace EcoPower_Logistics.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer GetCustomerById(int? id);
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
    }
}

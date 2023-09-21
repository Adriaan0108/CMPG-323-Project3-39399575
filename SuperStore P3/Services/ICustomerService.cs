using Models;

namespace EcoPower_Logistics.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int? id);
        IEnumerable<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
    }
}

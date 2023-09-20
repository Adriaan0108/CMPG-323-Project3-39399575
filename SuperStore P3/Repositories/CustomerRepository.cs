using Data;
using Models;

namespace EcoPower_Logistics.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SuperStoreContext context) : base(context) { }

        public Customer GetCustomerById(int? id)
        {
            return GetAll().FirstOrDefault(m => m.CustomerId == id);
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return GetAll().ToList();
        }
        public void AddCustomer(Customer customer)
        {
            Add(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            Update(customer);
        }
        public void RemoveCustomer(Customer customer)
        {
            Remove(customer);
        }
    }
}

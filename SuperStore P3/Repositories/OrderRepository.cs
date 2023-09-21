using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EcoPower_Logistics.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {

        public OrderRepository(SuperStoreContext context) : base(context) { }

        public Order GetOrderById(int? id)
        {

            return GetAll().FirstOrDefault(m => m.OrderId == id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return GetAll().ToList();
        }

        public void AddOrder(Order order)
        {
            Add(order);
        }

        public void RemoveOrder(Order order)
        {
            Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            Update(order);
        }
    }
}

//using EcoPower_Logistics;
using Models;

namespace EcoPower_Logistics.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void RemoveOrder(Order order);

    }
}

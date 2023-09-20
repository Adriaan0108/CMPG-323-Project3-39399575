using Models;

namespace EcoPower_Logistics.Services
{
    public interface IOrderService
    {
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        void AddOrder(Order order);
        void RemoveOrder(Order order);
        void UpdateOrder(Order order);
    }
}

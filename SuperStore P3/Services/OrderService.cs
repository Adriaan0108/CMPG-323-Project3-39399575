using Models;
using EcoPower_Logistics.Repositories;

namespace EcoPower_Logistics.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public void AddOrder(Order order)
        {
            _orderRepo.Add(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepo.GetAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepo.GetAll().FirstOrDefault(m => m.OrderId == id);
        }

        public void RemoveOrder(Order order)
        {
            _orderRepo.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            _orderRepo.Update(order);
        }
    }
}

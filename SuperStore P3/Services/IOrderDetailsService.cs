using Models;

namespace EcoPower_Logistics.Services
{
    public interface IOrderDetailsService
    {
        OrderDetail GetOrderDetailById(int? id);
        IEnumerable<OrderDetail> GetAllOrderDetail();
        void AddOrderDetail(OrderDetail orderDetail);
        void RemoveOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
    }
}

using Data;
using EcoPower_Logistics.Services;
using Models;

namespace EcoPower_Logistics.Repositories
{
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(SuperStoreContext context) : base(context) { }

        public OrderDetail GetOrderDetailById(int? id)
        {
            return GetAll().FirstOrDefault(m => m.OrderDetailsId == id);
        }
        public IEnumerable<OrderDetail> GetAllOrderDetail()
        {
            return GetAll().ToList();
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            Add(orderDetail);
        }
        public void RemoveOrderDetail(OrderDetail orderDetail)
        {
            Remove(orderDetail);
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            Update(orderDetail);
        }
    }
}

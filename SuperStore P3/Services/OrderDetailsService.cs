using Models;

namespace EcoPower_Logistics.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository _detailsRepo;
        public OrderDetailsService(IOrderDetailsRepository detailsRepo) 
        { 
            _detailsRepo = detailsRepo;
        }
        public OrderDetail GetOrderDetailById(int? id)
        {
            return _detailsRepo.GetAll().FirstOrDefault(m => m.OrderDetailsId == id);
        }
        public IEnumerable<OrderDetail> GetAllOrderDetail()
        {
            return _detailsRepo.GetAll().ToList();
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _detailsRepo.Add(orderDetail);  
        }
        public void RemoveOrderDetail(OrderDetail orderDetail)
        {
            _detailsRepo.Remove(orderDetail);   
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _detailsRepo.Update(orderDetail);
        }
    }
}

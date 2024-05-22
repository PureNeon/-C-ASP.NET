using ASPWebExamBelsky.Storage.Entity;

namespace ASPWebExamBelsky.Storage.Service
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAll();

        public Task<Order> GetById(int id);

        public Task<Order> AddNew(Order order, Dictionary<int,int> products);

        public Task<Order> DeleteById(int id);
    }
}

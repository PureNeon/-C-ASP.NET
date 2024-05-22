using ASPWebExamBelsky.Storage.Entity;

namespace ASPWebExamBelsky.Storage.Service
{
    public interface IProductInOrderService
    {
        public Task<ProductInOrder> GetProductInOrderById(int id);
        public Task<ProductInOrder> AddNew(int productId, int orderId, int count);
        public Task<ProductInOrder> DeleteById(int id);
    }
}

using ASPWebExamBelsky.Storage.Entity;

namespace ASPWebExamBelsky.Storage.Service
{
    public interface IProductService
    {

        public Task<Product> GetById(int id);

        public Task<Product> GetByTitle(string title);

        public Task<Product> AddNew(Product? product);

        public Task<Product> UpdateById(Product product);

        public Task<Product> DeleteById(int id);

        public Task<List<Product>> GetAll();

    }
}

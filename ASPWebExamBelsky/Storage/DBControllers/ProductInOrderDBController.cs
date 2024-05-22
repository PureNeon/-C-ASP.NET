using ASPWebExamBelsky.Storage.Entity;
using ASPWebExamBelsky.Storage.Service;
using Microsoft.EntityFrameworkCore;

namespace ASPWebExamBelsky.Storage.DBControllers
{
	public class ProductInOrderDBController:IProductInOrderService
	{
		private readonly DBContext.MainDBContext _db;

		public ProductInOrderDBController(DBContext.MainDBContext db)
		{
			_db = db;
		}

		public async Task<ProductInOrder?> GetProductInOrderById(int id)
		{
			return await _db.ProductInOrder.FirstOrDefaultAsync(productInOrder => productInOrder.Id == id);
		}

		public async Task<ProductInOrder?> AddNew(int productId, int orderId, int count)
		{
			ProductInOrder productInOrder = new ProductInOrder();

			if (_db.Product.FirstOrDefault(prod => prod.Id == productId).Available)
			{
				productInOrder.ProductId = productId;
				productInOrder.OrderId = orderId;
				productInOrder.ProductsCount = count;

				_db.ProductInOrder.Add(productInOrder);
				await _db.SaveChangesAsync();

                return productInOrder;
            }
			return null;
		}

		public async Task<ProductInOrder?> DeleteById(int id)
		{
			ProductInOrder? product = await _db.ProductInOrder.FirstOrDefaultAsync(productInOrder => productInOrder.Id == id);

            if (product != null)
			{
                _db.ProductInOrder.Remove(_db.ProductInOrder.FirstOrDefault(productInOrder => productInOrder.Id == id));
                _db.ProductInOrder.Remove(_db.ProductInOrder.FirstOrDefault(productInOrder => productInOrder.ProductId == id));
                await _db.SaveChangesAsync();
            }

			return product;
		}
	}
}

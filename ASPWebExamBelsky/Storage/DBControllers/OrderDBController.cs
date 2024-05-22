using ASPWebExamBelsky.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace ASPWebExamBelsky.Storage.DBControllers
{
	public class OrderDBController : Service.IOrderService
	{
		private readonly DBContext.MainDBContext _db;


		private readonly MD5 md5;
		public OrderDBController(DBContext.MainDBContext db)
		{
			_db = db;
			md5 = MD5.Create();
        }

		public async Task<List<Order>?> GetAll()
		{
			return await _db.Order.ToListAsync();
		}

		public async Task<Order?> GetById(int id)
		{
			return await _db.Order.FirstOrDefaultAsync(order => order.Id == id);
        }

		public async Task<Order?> AddNew(Order? order, Dictionary<int,int> products)
		{
			ProductInOrderDBController productInOrderDB = new ProductInOrderDBController(_db);

			if (order != null)
			{
				
				order.CreationDate = DateOnly.FromDateTime(DateTime.UtcNow);
                order.OrderHash = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(order.ToString() + DateTime.UtcNow.ToString())));

                await _db.Order.AddAsync(order);
                await _db.SaveChangesAsync();

				int lastOrderId = (from m in _db.Order select m.Id).ToList().Last();

                foreach (var prod in products)
				{
					productInOrderDB.AddNew(prod.Key, lastOrderId, prod.Value);
				}
            }
            return order;
        }

		public async Task<Order?> DeleteById(int id)
		{
            Order? removed = await _db.Order.FirstOrDefaultAsync(category => category.Id == id);
            if (removed != null)
            {
                _db.Order.Remove(removed);
                await _db.SaveChangesAsync();
            }
            return removed;
        }
	}
}

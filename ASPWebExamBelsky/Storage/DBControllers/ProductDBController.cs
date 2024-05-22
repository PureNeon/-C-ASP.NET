using ASPWebExamBelsky.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace ASPWebExamBelsky.Storage.DBControllers
{
	public class ProductDBController:Service.IProductService
	{
		private readonly DBContext.MainDBContext _db;

		public ProductDBController(DBContext.MainDBContext db)
		{
			_db = db;
		}

		public async Task<List<Product>?> GetAll()
		{
			return await _db.Product.ToListAsync();
		}

		public async Task<Product?> GetById(int id)
		{
			return await _db.Product.FirstOrDefaultAsync(product => product.Id == id);
		}

		public async Task<Product?> GetByTitle(string title)
		{
			return await _db.Product.FirstOrDefaultAsync(product => product.Title == title);

		}

		public async Task<Product?> AddNew(Product? product)
		{
			if (product != null)
			{
				_db.Product.Add(product);
				await _db.SaveChangesAsync();
			}
			return product;
		}

		public async Task<Product?> UpdateById(Product product)
		{
			Product? prod = await _db.Product.FirstOrDefaultAsync(prod => prod.Id == product.Id);

			if (prod != null)
			{
				prod.Title = product.Title;
				prod.Price = product.Price;
				prod.Available = product.Available;
				await _db.SaveChangesAsync();
			}

			return prod;
		}

		public async Task<Product> DeleteById(int id)
		{
			Product? product = await _db.Product.FirstOrDefaultAsync(product => product.Id == id);

			if (product != null)
			{
				_db.Product.Remove(_db.Product.FirstOrDefault(product => product.Id == id));
				_db.ProductInOrder.Remove(_db.ProductInOrder.FirstOrDefault(product => product.ProductId == id));
				await _db.SaveChangesAsync();
			}

			return product;
		}
	}
}

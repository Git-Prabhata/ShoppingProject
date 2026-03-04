using Microsoft.EntityFrameworkCore;

namespace ProductServiceAPI.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private static List<Product> _products = new List<Product>
	{
		new Product { Id = 1, Name = "Laptop", Price = 50000, Stock = 10 },
		new Product { Id = 2, Name = "Mobile", Price = 20000, Stock = 25 },
		new Product { Id = 3, Name = "Headphone", Price = 2000, Stock = 50 }
	};

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await Task.FromResult(_products);
		}

		public async Task<Product> GetById(int id)
		{
			var product = _products.FirstOrDefault(p => p.Id == id);
			return await Task.FromResult(product);
		}

		public async Task Add(Product product)
		{
			product.Id = _products.Max(p => p.Id) + 1;
			_products.Add(product);
			await Task.CompletedTask;
		}
		//private readonly AppDbContext _context;

		//public ProductRepository(AppDbContext context)
		//{
		//	_context = context;
		//}

		//public async Task<IEnumerable<Product>> GetAll()
		//{
		//	return await _context.Products.ToListAsync();
		//}

		//public async Task<Product> GetById(int id)
		//{
		//	return await _context.Products.FindAsync(id);
		//}

		//public async Task Add(Product product)
		//{
		//	_context.Products.Add(product);
		//	await _context.SaveChangesAsync();
		//}
	}
}

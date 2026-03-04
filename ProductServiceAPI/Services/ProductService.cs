using ProductServiceAPI.Repositories;

namespace ProductServiceAPI.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;

		public ProductService(IProductRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Product>> GetProducts()
			=> await _repository.GetAll();

		public async Task<Product> GetProduct(int id)
			=> await _repository.GetById(id);

		public async Task CreateProduct(Product product)
			=> await _repository.Add(product);
	}
}

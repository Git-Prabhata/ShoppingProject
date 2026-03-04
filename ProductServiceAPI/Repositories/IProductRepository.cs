namespace ProductServiceAPI.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAll();
		Task<Product> GetById(int id);
		Task Add(Product product);
	}
}

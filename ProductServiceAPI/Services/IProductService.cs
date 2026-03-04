namespace ProductServiceAPI.Services
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetProducts();
		Task<Product> GetProduct(int id);
		Task CreateProduct(Product product);
	}
}

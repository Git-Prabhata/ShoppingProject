using OrderServiecAPI.Models;

namespace OrderServiecAPI.Repositories
{
	
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetAll();
		Task Add(Order order);
	}
}

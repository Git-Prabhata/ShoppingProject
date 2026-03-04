using OrderServiecAPI.Models;

namespace OrderServiecAPI.Services
{
	public interface IOrderService
	{
		Task<string> CreateOrder(Order order);
		Task<IEnumerable<Order>> GetAll();
	}
}

using OrderServiecAPI.Models;

namespace OrderServiecAPI.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private static List<Order> _orders = new List<Order>
	{
		new Order { Id = 1, ProductId = 1, Quantity = 1, OrderDate = DateTime.Now },
		new Order { Id = 2, ProductId = 2, Quantity = 2, OrderDate = DateTime.Now },
	};
		public async Task<IEnumerable<Order>> GetAll()
		{
			return await Task.FromResult(_orders);
		}

		public async Task Add(Order order)
		{
			order.Id = _orders.Count + 1;
			order.OrderDate = DateTime.UtcNow;
			_orders.Add(order);
			await Task.CompletedTask;
		}
	}
}

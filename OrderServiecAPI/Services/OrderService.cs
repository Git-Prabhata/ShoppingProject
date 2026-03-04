namespace OrderServiecAPI.Services
{
	using OrderServiecAPI.Models;
	using OrderServiecAPI.Repositories;
	using System.Text.Json;

	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _repository;
		private readonly IHttpClientFactory _httpClientFactory;

		public OrderService(IOrderRepository repository,
							IHttpClientFactory httpClientFactory)
		{
			_repository = repository;
			_httpClientFactory = httpClientFactory;
		}

		public async Task<string> CreateOrder(Order order)
		{
			var client = _httpClientFactory.CreateClient("ProductService");

			var response = await client.GetAsync($"api/Product/{order.ProductId}");

			if (!response.IsSuccessStatusCode)
				return "Product not found";

			await _repository.Add(order);

			return "Order placed successfully";
		}
		public async Task<IEnumerable<Order>> GetAll()
		{
			return await _repository.GetAll();
		}
	}
}

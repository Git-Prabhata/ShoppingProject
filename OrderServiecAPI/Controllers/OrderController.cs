using Microsoft.AspNetCore.Mvc;
using OrderServiecAPI.Models;
using OrderServiecAPI.Services;

namespace OrderServiecAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _service;

		public OrderController(IOrderService service)
		{
			_service = service;
		}

		[HttpPost]
		public async Task<IActionResult> PlaceOrder(Order order)
		{
			var result = await _service.CreateOrder(order);
			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetOrders()
		{
			return Ok(await _service.GetAll());
		}
	}
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductServiceAPI.Services;
using System.Data;

namespace ProductServiceAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _service;

		public ProductController(IProductService service)
		{
			_service = service;
		}
		//[Authorize(Roles = "Admin")]
		[HttpGet]
		public async Task<IActionResult> Get()
			=> Ok(await _service.GetProducts());

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
			=> Ok(await _service.GetProduct(id));

		[HttpPost]
		public async Task<IActionResult> Post(Product product)
		{
			await _service.CreateProduct(product);
			return Ok(product);
		}
	}
}

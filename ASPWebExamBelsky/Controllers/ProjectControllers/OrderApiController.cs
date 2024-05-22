using ASPWebExamBelsky.Controllers.ProjectControllers.ControllerJsonReadBase;
using ASPWebExamBelsky.Storage.Entity;
using ASPWebExamBelsky.Storage.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ASPWebExamBelsky.Controllers.ProjectControllers
{
	[Route("order")]
	[ApiController]
	public class OrderApiController : ControllerBase
	{

		private readonly IOrderService _orderService;

		public OrderApiController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public async Task<string?> GetAll()
		{
			var order = await _orderService.GetAll();

			string? json = JsonSerializer.Serialize(order);
			
			return json;
		}

		[HttpGet("{orderId:int}")]
		public async Task<string?> GetById(int orderId)
		{
			Order order = await _orderService.GetById(orderId);

            string? json = JsonSerializer.Serialize(order);

            return json;
		}

		[HttpPut]
		public async Task<string?> AddNew()
		{
			WebOrder? webOrder = await Request.ReadFromJsonAsync<WebOrder?>();
			
			if (webOrder == null) { return null; }
				
			Order order = new Order();
			order.ClientName = webOrder.ClientName;
			await _orderService.AddNew(order, webOrder.Products);

			Console.WriteLine(webOrder);
            string? json = JsonSerializer.Serialize(order);

            return json;
		}

		[HttpDelete("{orderId:int}")]
		public async Task<string?> DeleteById(int orderId)
		{
			var order = await _orderService.DeleteById(orderId);

			string? json = JsonSerializer.Serialize(order);

			return json;
		}
	}
}

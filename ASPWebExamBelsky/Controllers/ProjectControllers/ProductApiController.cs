using ASPWebExamBelsky.Storage.Entity;
using ASPWebExamBelsky.Storage.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ASPWebExamBelsky.Controllers.ProjectControllers
{
    [Route("product")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<string?> GetAll()
        {
            List<Product> products = await _productService.GetAll();
            string? json = JsonSerializer.Serialize(products);
            return json;
        }

        [HttpGet("productId/{productId:int}")]
        public async Task<string?> GetById(int productId)
        {
            var product = await _productService.GetById(productId);

            string? json = JsonSerializer.Serialize(product);
            return json;
        }

        [HttpGet("productTitle/{productTitle}")]
        public async Task<string?> GetByTitle(string productTitle)
        {
            var product = await _productService.GetByTitle(productTitle);

            string? json = JsonSerializer.Serialize(product);
            return json;
        }

        [HttpPut]
        public async Task<string?> AddNew()
        {
            Product? product = await _productService.AddNew(await Request.ReadFromJsonAsync<Product?>());
            string? json = JsonSerializer.Serialize(product);
            return json;
        }

        [HttpPatch]
        public async Task<string?> UpdateById()
        {
            Product? product = await _productService.UpdateById(await Request.ReadFromJsonAsync<Product?>());
            string? json = JsonSerializer.Serialize(product);
            return json;
        }

        [HttpDelete("productId/{productId:int}")]
        public async Task<string?> DeleteById(int productId)
        {
            Product? product = await _productService.DeleteById(productId);
            string? json = JsonSerializer.Serialize(product);
            return json;
        }
    }
}

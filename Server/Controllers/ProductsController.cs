using Microsoft.AspNetCore.Mvc;
using Server.Service.Products;
using Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public IProductsService service { get; set; }
        public ProductsController(IProductsService service)
        {
            this.service = service;
        }

        [HttpGet("getproducts")]
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            var lista = await service.GetProductsAsync();
            return Ok(lista);
        }

        [HttpGet("getproductbyid/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await service.GetProductByIdAsync(id);
            return product is null ? NotFound() : Ok(product);
        }
        
        [HttpPost("createproduct")]
        public async Task<ActionResult<Product>> CreateProductAsync([FromBody] Product producto)
        {
            var created = await service.CreateProductAsync(producto);
            return CreatedAtAction(nameof(GetProductById), new { id = created.ProductId },created);
        }

        [HttpPut("updateproduct/{id}")]
        public async Task<ActionResult<Product>> UpdateProductAsync(int id, [FromBody] Product producto)
        {
            var updated = await service.UpdateProductAsync(id, producto);
            return updated is null ? NotFound() :Ok(updated);
        }

       
        [HttpDelete("deleteproduct/{id}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var ok = await service.DeleteProductAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}

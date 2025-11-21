using Microsoft.AspNetCore.Mvc;
using Server.Service.Supplier;
using Shared.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        public ISuppliersService service { get; set; }

        public SuppliersController(ISuppliersService service)
        {
            this.service = service;
        }

        [HttpGet("getsuppliers")]
        public async Task<ActionResult<List<Proveedor>>> GetSuppliersAsync() 
        {
            var lista = await service.GetSuppliersAsync();
            return Ok(lista);
        }

        [HttpGet("getsupplierbyid/{id}",Name = "GetSupplierById")]
        public async Task<ActionResult<Proveedor>> GetCustomerByIdAsync(int id) 
        {
            var supplier = await service.GetSupplierByIdAsync(id);
            return supplier is null ? NotFound() : Ok(supplier);
        }

        [HttpPost("createsupplier")]
        public async Task<ActionResult<Proveedor>> CreateSupplierAsync([FromBody] Proveedor supplier) 
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var created = await service.CreateSupplierAsync(supplier);
            return CreatedAtRoute("GetSupplierById", new { id = created.SupplierId }, created);
        }

        [HttpPut("updatesupplier/{id}")]
        public async Task<ActionResult<Proveedor>> UpdateSupplierAsync(int id, [FromBody] Proveedor supplier) 
        {
            var updated = await service.UpdatesSupplierAsync(id, supplier);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpDelete("deletesupplier/{id}")]
        public async Task<ActionResult> DeleteSupplierAsync(int id) 
        {
            var ok = await service.DeleteSupplierAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}

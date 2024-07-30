using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockTracking.Business;
using StockTracking.Models.DTOs;

namespace StockTracking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WarehousesController : ControllerBase
    {
        private readonly WarehouseService _warehouseService;

        public WarehousesController(WarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet("GetWarehouses")]
        public async Task<IActionResult> GetWarehouses()
        {
            var warehouses = await _warehouseService.GetWarehousesAsync();
            return Ok(warehouses);
        }

        [HttpGet("GetWarehouse/{id}")]
        public async Task<IActionResult> GetWarehouse(int id)
        {
            var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            return Ok(warehouse);
        }

        [HttpPost("AddWarehouse")]
        public async Task<IActionResult> AddWarehouse([FromBody] WarehouseDTO warehouseDto)
        {
            await _warehouseService.AddWarehouseAsync(warehouseDto);
            return CreatedAtAction(nameof(GetWarehouse), new { id = warehouseDto.Id }, warehouseDto);
        }

        [HttpPut("UpdateWarehouse/{id}")]
        public async Task<IActionResult> UpdateWarehouse(int id, [FromBody] WarehouseDTO warehouseDto)
        {
            if (id != warehouseDto.Id)
            {
                return BadRequest();
            }

            await _warehouseService.UpdateWarehouseAsync(id, warehouseDto);
            return Ok(warehouseDto);
        }

        [HttpDelete("DeleteWarehouse/{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            await _warehouseService.DeleteWarehouseAsync(id);
            return Ok("warehouse deleted successfully");
        }
    }
}

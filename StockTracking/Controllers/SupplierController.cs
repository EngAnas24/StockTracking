using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockTracking.Business;
using StockTracking.Models;
using StockTracking.Models.DTOs;
using System;

namespace StockTracking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class SupplierController : ControllerBase
    {
        private readonly SuppliersService _SuppliersService;

        public SupplierController(SuppliersService SuppliersService)
        {
           _SuppliersService = SuppliersService;
        }

        [HttpGet("GetSuppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var Supplierss = await _SuppliersService.GetSuppliersAsync();
            return Ok(Supplierss);
        }


        [HttpGet("GetSupplier/{id}")]
    public async Task<IActionResult> GetSupplier(int id)
    {
        var Suppliers = await _SuppliersService.GetSuppliersByIdAsync(id);
        if (Suppliers == null)
        {
            return NotFound();
        }
        return Ok(Suppliers);
    }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier( SuppliersDTO SuppliersDTO)
        {
          
            if (SuppliersDTO == null)
            {
                return BadRequest("Suppliers data is null.");
            }

          
            await _SuppliersService.AddSuppliersAsync(SuppliersDTO);
            return CreatedAtAction(nameof(GetSuppliers), new { id = SuppliersDTO.Id }, SuppliersDTO);
        }


        [HttpPut("UpdateSupplier/{id}")]
    public async Task<IActionResult> UpdateSupplier(int id, SuppliersDTO SuppliersDTO)
    {
        if (id != SuppliersDTO.Id)
        {
            return BadRequest();
        }
            
            await _SuppliersService.UpdateSuppliersAsync(id, SuppliersDTO);
           return Ok(SuppliersDTO);
    }

    [HttpDelete("DeleteSupplier/{id}")]
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        await _SuppliersService.DeleteSuppliersAsync(id);
        return Ok("Suppliers deleted successfully");
    }
}
}

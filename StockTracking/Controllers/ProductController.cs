using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockTracking.Models.DTOs;

namespace StockTracking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductController : ControllerBase
    {
        private readonly ProductService _ProductService;

        public ProductController(ProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var Products = await _ProductService.GetProductsAsync();
            return Ok(Products);
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var Product = await _ProductService.GetProductByIdAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO ProductDto)
        {
            var addedProduct = await _ProductService.AddProductAsync(ProductDto);
            ProductDto.Id = addedProduct.Id;
            return Ok(ProductDto);
        }


        [HttpPut("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO ProductDto)
        {
            if (id != ProductDto.Id)
            {
                return BadRequest();
            }

            await _ProductService.UpdateProductAsync(id, ProductDto);
            return Ok(ProductDto);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _ProductService.DeleteProductAsync(id);
            return Ok("Product deleted successfully");
        }
    }
}

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

    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService CategoryService)
        {
           _categoryService = CategoryService;
        }
        [HttpGet("GetCategorys")]
        public async Task<IActionResult> GetCategorys()
        {
            var Categorys = await _categoryService.GetCategorysAsync();
            return Ok(Categorys);
        }


        [HttpGet("GetCategory/{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var Category = await _categoryService.GetCategoryByIdAsync(id);
        if (Category == null)
        {
            return NotFound();
        }
        return Ok(Category);
    }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory( CategoryDTO CategoryDTO)
        {
          
            if (CategoryDTO == null)
            {
                return BadRequest("Category data is null.");
            }

          
            await _categoryService.AddCategoryAsync(CategoryDTO);
            return CreatedAtAction(nameof(GetCategory), new { id = CategoryDTO.Id }, CategoryDTO);
        }


        [HttpPut("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDTO CategoryDTO)
    {
        if (id != CategoryDTO.Id)
        {
            return BadRequest();
        }
            
            await _categoryService.UpdateCategoryAsync(id, CategoryDTO);
           return Ok(CategoryDTO);
    }

    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return Ok("Category deleted successfully");
    }
}
}

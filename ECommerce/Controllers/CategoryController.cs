using ECommerce.DTOs;
using ECommerce.DTOs.Brand;
using ECommerce.DTOs.Category;
using ECommerce.Filters;
using ECommerce.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http;
using System.Security.Claims;

namespace ECommerce.Controllers
{

    [SwaggerTag("Category Controller")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryManager _categoryManager;
        private static readonly HttpClient client = new HttpClient();

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] CategoryFilter filter)
        {
            var res = await _categoryManager.ListAsync(filter);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await _categoryManager.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CategoryCreateDto brandDto)
        {
            await _categoryManager.CreateAsync(brandDto);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            await _categoryManager.UpdateAsync(categoryUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _categoryManager.DeleteAsync(id);
            return Ok();
        }

    }
}

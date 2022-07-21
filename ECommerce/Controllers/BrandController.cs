using ECommerce.DTOs;
using ECommerce.DTOs.Brand;
using ECommerce.Filters;
using ECommerce.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http;
using System.Security.Claims;

namespace ECommerce.Controllers
{

    [SwaggerTag("Brand Controller")]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly IBrandManager _brandManager;
        private static readonly HttpClient client = new HttpClient();

        public BrandController(IBrandManager brandManager)
        {
            _brandManager = brandManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] BrandFilter filter)
        {
            var res = await _brandManager.ListAsync(filter);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await _brandManager.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(BrandCreateDto brandDto)
        {
            await _brandManager.CreateAsync(brandDto);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(BrandUpdateDto brandUpdateDto)
        {
            await _brandManager.UpdateAsync(brandUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _brandManager.DeleteAsync(id);
            return Ok();
        }

    }
}

using ECommerce.DTOs;
using ECommerce.DTOs.Item;
using ECommerce.Filters;
using ECommerce.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http;
using System.Security.Claims;

namespace ECommerce.Controllers
{

    [SwaggerTag("Item Controller")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IItemManager _itemManager;
        private static readonly HttpClient client = new HttpClient();

        public ItemController(IItemManager itemManager)
        {
            _itemManager = itemManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] ItemFilter filter)
        {
            var res = await _itemManager.ListAsync(filter);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await _itemManager.GetByIdAsync(id);
            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(ItemCreateDto itemDto)
        {
            await _itemManager.CreateAsync(itemDto);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(ItemUpdateDto itemUpdateDto)
        {
            await _itemManager.UpdateAsync(itemUpdateDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _itemManager.DeleteAsync(id);
            return Ok();
        }
    }
}

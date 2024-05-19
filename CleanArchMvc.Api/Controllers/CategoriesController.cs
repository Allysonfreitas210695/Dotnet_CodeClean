using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;
        public CategoriesController(ICategoryService categoryRepository)
        {
            this._categoryServices = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _categoryServices.GetCategories();
            if(categories == null) return NotFound();

            return Ok(categories);
        }

        [HttpGet("id")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _categoryServices.GetById(id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] CategoryDto category)
        {
            if(category == null) return BadRequest("Invalid Data");
            await _categoryServices.Add(category);
            return Ok();
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryDto category)
        {
            if (id != category.Id) return BadRequest();
            if(category == null) return BadRequest();

            await _categoryServices.Update(category);
            return Ok(category);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            if(await _categoryServices.GetById(id) == null) return NotFound();    
            await _categoryServices.Remove(id);
            return NoContent();
        }
    }
}

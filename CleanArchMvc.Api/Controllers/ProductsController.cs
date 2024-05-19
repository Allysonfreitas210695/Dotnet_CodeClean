using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var product = await _productService.GetProducts();
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost()]
        public async Task<ActionResult> Post([FromBody] ProductDto product)
        {
            if (product == null) return BadRequest("Invalid Data");
            await _productService.Add(product);
            return Ok();
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDto product)
        {
            if (id != product.Id) return BadRequest();
            if (product == null) return BadRequest();

            await _productService.Update(product);
            return Ok(product);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            if (await _productService.GetById(id) == null) return NotFound();
            await _productService.Remove(id);
            return NoContent();
        }
    }
}

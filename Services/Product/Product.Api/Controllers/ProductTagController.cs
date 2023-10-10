using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.ProductTag;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("api/producttags")]
    public class ProductTagController : ControllerBase
    {
        private readonly IAppProductTagService _productTagService;

        public ProductTagController(IAppProductTagService productTagService)
        {
            _productTagService = productTagService ?? throw new ArgumentNullException(nameof(productTagService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductTags()
        {
            var products = await _productTagService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductTagById(int id)
        {
            var product = await _productTagService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductTag([FromBody] CreateProductTagDto createDto)
        {
            var createdProduct = await _productTagService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetProductTagById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductTag(int id, [FromBody] UpdateProductTagDto updateDto)
        {
            await _productTagService.UpdateAsync(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTag(int id)
        {
            await _productTagService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("tag/{tagId}/products")]
        public async Task<IActionResult> GetProductsByTag(int tagId)
        {
            var products = await _productTagService.GetProductsByTagAsync(tagId);
            return Ok(products);
        }

        [HttpGet("product/{productId}/tags")]
        public async Task<IActionResult> GetTagsByProduct(int productId)
        {
            var tags = await _productTagService.GetTagsByProductAsync(productId);
            return Ok(tags);
        }
    }
}

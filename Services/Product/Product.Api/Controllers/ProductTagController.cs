using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.ProductTag;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
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
            try
            {
                var tags = await _productTagService.GetAllAsync();
                if (tags == null || !tags.Any())
                {
                    return NotFound();
                }
                return Ok(tags);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductTagById(int id)
        {
            try
            {
                var productTag = await _productTagService.GetByIdAsync(id);
                if (productTag == null)
                {
                    return NotFound();
                }

                return Ok(productTag);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductTag([FromBody] CreateProductTagDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdProductTag = await _productTagService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetProductTagById), new { id = createdProductTag.Id }, createdProductTag);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductTag(int id, [FromBody] UpdateProductTagDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedProductTag = await _productTagService.UpdateAsync(id, updateDto);
                if (!updatedProductTag)
                {
                    return StatusCode(422, "Could Not Update ProductTag - Unprocessable Content");
                }
                return Ok(updatedProductTag);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTag(int id)
        {
            try
            {
                var deletedProductTag = await _productTagService.DeleteAsync(id);
                if (!deletedProductTag)
                {
                    return StatusCode(422, "Could Not Delete ProductTag - Unprocessable Content");
                }

                return Ok(deletedProductTag);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("tag/{tagId}/products")]
        public async Task<IActionResult> GetProductsByTag(int tagId)
        {
            try
            {
                var products = await _productTagService.GetProductsByTagAsync(tagId);
                if (products == null || !products.Any())
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("product/{productId}/tags")]
        public async Task<IActionResult> GetTagsByProduct(int productId)
        {
            try
            {
                var tags = await _productTagService.GetTagsByProductAsync(productId);
                if (tags == null || !tags.Any())
                {
                    return NotFound();
                }
                return Ok(tags);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

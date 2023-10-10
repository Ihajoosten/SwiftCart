using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.ItemImage;
using Product.Application.Dto.ItemImage;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("api/itemimages")]
    public class ItemImageController : ControllerBase
    {
        private readonly IAppItemImageService _itemImageService;

        public ItemImageController(IAppItemImageService itemImageService)
        {
            _itemImageService = itemImageService ?? throw new ArgumentNullException(nameof(itemImageService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemImages()
        {
            var products = await _itemImageService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemImageById(int id)
        {
            var product = await _itemImageService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemImage([FromBody] CreateItemImageDto createDto)
        {
            var createdProduct = await _itemImageService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetItemImageById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemImage(int id, [FromBody] UpdateItemImageDto updateDto)
        {
            await _itemImageService.UpdateAsync(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemImage(int id)
        {
            await _itemImageService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("product/{productId}/images")]
        public async Task<IActionResult> GetImagesByProductId(int productId)
        {
            var images = await _itemImageService.GetImagesByProductIdAsync(productId);
            return Ok(images);
        }
    }
}

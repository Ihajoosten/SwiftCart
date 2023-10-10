using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var images = await _itemImageService.GetAllAsync();
                if (images == null || !images.Any())
                {
                    return NotFound();
                }
                return Ok(images);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemImageById(int id)
        {
            try
            {
                var image = await _itemImageService.GetByIdAsync(id);
                if (image == null)
                {
                    return NotFound();
                }

                return Ok(image);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemImage([FromBody] CreateItemImageDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdImage = await _itemImageService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetItemImageById), new { id = createdImage.Id }, createdImage);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemImage(int id, [FromBody] UpdateItemImageDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var udpatedImage = await _itemImageService.UpdateAsync(id, updateDto);
                if (!udpatedImage)
                {
                    return StatusCode(422, "Could Not Update Image - Unprocessable Content");
                }
                return Ok(udpatedImage);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemImage(int id)
        {
            try
            {
                var deletedImage = await _itemImageService.DeleteAsync(id);
                if (!deletedImage)
                {
                    return StatusCode(422, "Could Not Delete Image - Unprocessable Content");
                }

                return Ok(deletedImage);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("product/{productId}/images")]
        public async Task<IActionResult> GetImagesByProductId(int productId)
        {
            try
            {
                var images = await _itemImageService.GetImagesByProductIdAsync(productId);
                if (images == null || !images.Any())
                {
                    return NotFound();
                }
                return Ok(images);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.Tag;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
    [Route("api/tags")]
    public class TagController : ControllerBase
    {
        private readonly IAppTagService _tagService;

        public TagController(IAppTagService tagService)
        {
            _tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            try
            {
                var tags = await _tagService.GetAllAsync();
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
        public async Task<IActionResult> GetTagById(int id)
        {
            try
            {
                var tag = await _tagService.GetByIdAsync(id);
                if (tag == null)
                {
                    return NotFound();
                }
                return Ok(tag);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTag([FromBody] CreateTagDto createReviewDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var review = await _tagService.CreateAsync(createReviewDto);
                return CreatedAtAction(nameof(GetTagById), new { id = review.Id }, review);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, [FromBody] UpdateTagDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedProduct = await _tagService.UpdateAsync(id, updateDto);
                if (!updatedProduct)
                {
                    return StatusCode(422, "Could Not Update Tag - Unprocessable Content");
                }
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            try
            {
                var deletedProduct = await _tagService.DeleteAsync(id);
                if (!deletedProduct)
                {
                    return StatusCode(422, "Could Not Delete Tag - Unprocessable Content");
                }

                return Ok(deletedProduct);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("popular/{count}")]
        public async Task<IActionResult> GetPopularTags(int count)
        {
            try
            {
                var popularTags = await _tagService.GetPopularTagsAsync(count);
                if (popularTags == null || !popularTags.Any())
                {
                    return NotFound();
                }
                return Ok(popularTags);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

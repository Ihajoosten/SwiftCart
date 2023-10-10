using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.Review;
using Product.Application.Dto.Tag;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagController : ControllerBase
    {
        private readonly IAppTagService _tagService;

        public TagController(IAppTagService tagService)
        {
            _tagService = tagService ?? throw new ArgumentNullException(nameof(tagService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var review = await _tagService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var reviews = await _tagService.GetAllAsync();
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> AddTag([FromBody] CreateTagDto createReviewDto)
        {
            var review = await _tagService.CreateAsync(createReviewDto);
            return CreatedAtAction(nameof(GetTagById), new { id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, [FromBody] UpdateTagDto updateDto)
        {
            await _tagService.UpdateAsync(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("popular/{count}")]
        public async Task<IActionResult> GetPopularTags(int count)
        {
            var popularTags = await _tagService.GetPopularTagsAsync(count);
            return Ok(popularTags);
        }
    }
}

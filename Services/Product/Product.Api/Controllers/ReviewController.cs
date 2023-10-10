using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.Review;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IAppReviewService _reviewService;

        public ReviewController(IAppReviewService reviewService)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllAsync();
            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] CreateReviewDto createReviewDto)
        {
            var review = await _reviewService.CreateAsync(createReviewDto);
            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewDto updateDto)
        {
            await _reviewService.UpdateAsync(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteAsync(id);
            return NoContent();
        }


        [HttpGet("{productId}")]
        public async Task<IActionResult> GetReviewsByProduct(int productId)
        {
            var reviews = await _reviewService.GetReviewsByProductIdAsync(productId);
            return Ok(reviews);
        }

        [HttpGet("{productId}/average-rating")]
        public async Task<IActionResult> GetAverageRatingByProductId(int productId)
        {
            var averageRating = await _reviewService.GetAverageRatingByProductIdAsync(productId);
            return Ok(averageRating);
        }
    }
}

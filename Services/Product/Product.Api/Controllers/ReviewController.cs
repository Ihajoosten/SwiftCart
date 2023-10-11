using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.Review;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Authorize(Policy = "AdminPolicy, CustomerPolicy")]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly IAppReviewService _reviewService;

        public ReviewController(IAppReviewService reviewService)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                var reviews = await _reviewService.GetAllAsync();
                if (reviews == null || !reviews.Any())
                {
                    return NotFound();
                }

                return Ok(reviews);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            try
            {
                var review = await _reviewService.GetByIdAsync(id);
                if (review == null)
                {
                    return NotFound();
                }

                return Ok(review);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] CreateReviewDto createReviewDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var review = await _reviewService.CreateAsync(createReviewDto);
                return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedReview = await _reviewService.UpdateAsync(id, updateDto);
                if (!updatedReview)
                {
                    return StatusCode(422, "Could Not Update Review - Unprocessable Content");
                }
                return Ok(updatedReview);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                var deletedReview = await _reviewService.DeleteAsync(id);
                if (!deletedReview)
                {
                    return StatusCode(422, "Could Not Delete Review - Unprocessable Content");
                }

                return Ok(deletedReview);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpGet("{productId}")]
        public async Task<IActionResult> GetReviewsByProduct(int productId)
        {
            try
            {
                var reviews = await _reviewService.GetReviewsByProductIdAsync(productId);
                if (reviews == null || !reviews.Any())
                {
                    return NotFound();
                }
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{productId}/average-rating")]
        public async Task<IActionResult> GetAverageRatingByProductId(int productId)
        {
            var averageRating = await _reviewService.GetAverageRatingByProductIdAsync(productId);
            return Ok(averageRating);
        }
    }
}

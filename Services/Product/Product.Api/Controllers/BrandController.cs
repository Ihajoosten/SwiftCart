using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.Brand;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IAppBrandService _brandService;

        public BrandController(IAppBrandService brandService)
        {
            _brandService = brandService ?? throw new ArgumentNullException(nameof(brandService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var brands = await _brandService.GetAllAsync();
                if (brands == null || !brands.Any())
                {
                    return NotFound();
                }
                return Ok(brands);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                var brand = await _brandService.GetByIdAsync(id);
                if (brand == null)
                {
                    return NotFound();
                }

                return Ok(brand);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdBrand = await _brandService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetBrandById), new { id = createdBrand.Id }, createdBrand);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] UpdateBrandDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedProduct = await _brandService.UpdateAsync(id, updateDto);
                if (!updatedProduct)
                {
                    return StatusCode(422, "Could Not Update Brand - Unprocessable Content");
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
        public async Task<IActionResult> DeleteBrand(int id)
        {
            try
            {
                var deletedBrand = await _brandService.DeleteAsync(id);
                if (!deletedBrand)
                {
                    return StatusCode(422, "Could Not Delete Brand - Unprocessable Content");
                }

                return Ok(deletedBrand);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("popular/{count}")]
        public async Task<IActionResult> GetPopularBrands(int count)
        {
            try
            {
                var brands = await _brandService.GetPopularBrandsAsync(count);
                if (brands == null || !brands.Any())
                {
                    return NotFound();
                }
                return Ok(brands);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}

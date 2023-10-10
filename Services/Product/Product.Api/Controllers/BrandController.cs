using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.Brand;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
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
            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandDto createDto)
        {
            var createdBrand = await _brandService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetBrandById), new { id = createdBrand.Id }, createdBrand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] UpdateBrandDto updateDto)
        {
            await _brandService.UpdateAsync(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("popular/{count}")]
        public async Task<IActionResult> GetPopularBrands(int count)
        {
            var brands = await _brandService.GetPopularBrandsAsync(count);
            return Ok(brands);
        }
    }
}

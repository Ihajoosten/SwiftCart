using Microsoft.AspNetCore.Mvc;
using Product.Application.Dto.Product;
using Product.Application.Interfaces;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IAppProductService _productService;

        public ProductController(IAppProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createDto)
        {
            var createdProduct = await _productService.CreateAsync(createDto);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateDto)
        {
            await _productService.UpdateAsync(id, updateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("byBrand/{brandId}")]
        public async Task<IActionResult> GetProductsByBrand(int brandId)
        {
            var products = await _productService.GetProductsByBrandAsync(brandId);
            return Ok(products);
        }

        [HttpGet("byCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        [HttpGet("byTag/{tagId}")]
        public async Task<IActionResult> GetProductsByTag(int tagId)
        {
            var products = await _productService.GetProductsByTagAsync(tagId);
            return Ok(products);
        }

        [HttpGet("byRating/{minRating}")]
        public async Task<IActionResult> GetProductsByRating(int minRating)
        {
            var products = await _productService.GetProductsByRatingAsync(minRating);
            return Ok(products);
        }

        [HttpGet("topSelling/{count}")]
        public async Task<IActionResult> GetTopSellingProducts(int count)
        {
            var products = await _productService.GetTopSellingProductsAsync(count);
            return Ok(products);
        }

        [HttpGet("newArrivals/{count}")]
        public async Task<IActionResult> GetNewArrivalProducts(int count)
        {
            var products = await _productService.GetNewArrivalProductsAsync(count);
            return Ok(products);
        }
    }
}

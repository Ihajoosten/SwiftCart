using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "AdminPolicy, MarketingPolicy, Customer")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllAsync();
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

        [HttpGet("{id}")]
        [Authorize(Policy = "AdminPolicy, MarketingPolicy, Customer")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdProduct = await _productService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatedProduct = await _productService.UpdateAsync(id, updateDto);
                if (!updatedProduct)
                {
                    return StatusCode(422, "Could Not Update Product - Unprocessable Content");
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
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var deletedProduct = await _productService.DeleteAsync(id);
                if (!deletedProduct)
                {
                    return StatusCode(422, "Could Not Delete Product - Unprocessable Content");
                }

                return Ok(deletedProduct);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("byBrand/{brandId}")]
        [Authorize(Policy = "AdminPolicy, MarketingPolicy")]
        public async Task<IActionResult> GetProductsByBrand(int brandId)
        {
            try
            {
                var products = await _productService.GetProductsByBrandAsync(brandId);
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

        [HttpGet("byCategory/{categoryId}")]
        [Authorize(Policy = "AdminPolicy, MarketingPolicy")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            try
            {
                var products = await _productService.GetProductsByCategoryAsync(categoryId);
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

        [HttpGet("byTag/{tagId}")]
        [Authorize(Policy = "AdminPolicy, MarketingPolicy")]
        public async Task<IActionResult> GetProductsByTag(int tagId)
        {
            try
            {
                var products = await _productService.GetProductsByTagAsync(tagId);
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

        [HttpGet("byRating/{minRating}")]
        [Authorize(Policy = "AdminPolicy, MarketingPolicy")]
        public async Task<IActionResult> GetProductsByRating(int minRating)
        {
            try
            {
                var products = await _productService.GetProductsByRatingAsync(minRating);
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

        [HttpGet("topSelling/{count}")]
        [Authorize(Policy = "AdminPolicy, MarketingPolicy")]
        public async Task<IActionResult> GetTopSellingProducts(int count)
        {
            try
            {
                var products = await _productService.GetTopSellingProductsAsync(count);
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

        [HttpGet("newArrivals/{count}")]
        [Authorize(Policy = "AdminPolicy, MarketingPolicy")]
        public async Task<IActionResult> GetNewArrivalProducts(int count)
        {
            try
            {
                var products = await _productService.GetNewArrivalProductsAsync(count);
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
    }
}

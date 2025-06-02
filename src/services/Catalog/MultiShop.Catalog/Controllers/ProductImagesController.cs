using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImages;

namespace MultiShop.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductImageDto>>> GetAll()
        {
            var productImages = await _productImageService.GetAllAsync();
            return Ok(productImages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImageDto>> GetById(string id)
        {
            try
            {
                var productImage = await _productImageService.GetByIdAsync(id);
                return Ok(productImage);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<ProductImageDto>>> GetByProductId(string productId)
        {
            try
            {
                var productImages = await _productImageService.GetByProductIdAsync(productId);
                return Ok(productImages);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductImageDto>> Create([FromBody] CreateProductImageDto createProductImageDto)
        {
            try
            {
                var productImage = await _productImageService.CreateAsync(createProductImageDto);
                return CreatedAtAction(nameof(GetById), new { id = productImage.Id }, productImage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductImageDto>> Update(string id, [FromBody] UpdateProductImageDto updateProductImageDto)
        {
            try
            {
                var productImage = await _productImageService.UpdateAsync(id, updateProductImageDto);
                return Ok(productImage);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                await _productImageService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("product/{productId}")]
        public async Task<ActionResult> DeleteByProductId(string productId)
        {
            try
            {
                await _productImageService.DeleteAllByProductIdAsync(productId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
} 
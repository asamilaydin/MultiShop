using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetails;

namespace MultiShop.Catalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetailDto>>> GetAll()
        {
            var productDetails = await _productDetailService.GetAllAsync();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailDto>> GetById(string id)
        {
            try
            {
                var productDetail = await _productDetailService.GetByIdAsync(id);
                return Ok(productDetail);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<ProductDetailDto>> GetByProductId(string productId)
        {
            try
            {
                var productDetail = await _productDetailService.GetByProductIdAsync(productId);
                return Ok(productDetail);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductDetailDto>> Create([FromBody] CreateProductDetailDto createProductDetailDto)
        {
            try
            {
                var productDetail = await _productDetailService.CreateAsync(createProductDetailDto);
                return CreatedAtAction(nameof(GetById), new { id = productDetail.Id }, productDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDetailDto>> Update(string id, [FromBody] UpdateProductDetailDto updateProductDetailDto)
        {
            try
            {
                var productDetail = await _productDetailService.UpdateAsync(id, updateProductDetailDto);
                return Ok(productDetail);
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
                await _productDetailService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
} 
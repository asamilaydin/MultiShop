using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;
using System;
using System.Threading.Tasks;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public DiscountsController(ICouponService couponService) 
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _couponService.GetAllCouponsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(Guid id)
        {
            var value = await _couponService.GetCouponByIdAsync(id);
            if (value == null)
            {
                return NotFound("Coupon not found.");
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon([FromBody] CreateCouponDto createCouponDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _couponService.CreateCouponAsync(createCouponDto);
            return StatusCode(StatusCodes.Status201Created, "Coupon created successfully."); 
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon([FromBody] UpdateCouponDto updateCouponDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _couponService.UpdateCouponAsync(updateCouponDto);
            if (!result)
            {
                return NotFound("Coupon not found for update or update failed.");
            }
            return Ok("Coupon updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(Guid id)
        {
            var result = await _couponService.DeleteCouponAsync(id);
            if (!result)
            {
                return NotFound("Coupon not found for deletion or delete failed.");
            }
            return Ok("Coupon deleted successfully.");
        }
    }
} 
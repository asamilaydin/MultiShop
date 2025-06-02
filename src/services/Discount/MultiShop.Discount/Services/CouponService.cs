using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;
using MultiShop.Discount.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.Discount.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        // Constructor injection for ICouponRepository
        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            // Manual mapping from CreateCouponDto to Coupon entity
            var coupon = new Coupon
            {
                Id = Guid.NewGuid(), // Generate a new Id for the coupon
                Code = createCouponDto.Code,
                Rate = createCouponDto.Rate,
                IsActive = createCouponDto.IsActive,
                ValidDate = createCouponDto.ValidDate
            };
            await _couponRepository.CreateAsync(coupon);
            // No need to return DTO as CreateAsync in ICouponService is void
        }

        public async Task<bool> DeleteCouponAsync(Guid id)
        {
            return await _couponRepository.DeleteAsync(id);
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            var coupons = await _couponRepository.GetAllAsync();
            // Manual mapping from IEnumerable<Coupon> to List<ResultCouponDto>
            return coupons.Select(coupon => new ResultCouponDto
            {
                Id = coupon.Id,
                Code = coupon.Code,
                Rate = coupon.Rate,
                IsActive = coupon.IsActive,
                ValidDate = coupon.ValidDate
            }).ToList();
        }

        public async Task<ResultCouponDto> GetCouponByIdAsync(Guid id)
        {
            var coupon = await _couponRepository.GetByIdAsync(id);
            if (coupon == null)
            {
                return null; // Or throw a custom NotFoundException
            }
            // Manual mapping from Coupon to ResultCouponDto
            return new ResultCouponDto
            {
                Id = coupon.Id,
                Code = coupon.Code,
                Rate = coupon.Rate,
                IsActive = coupon.IsActive,
                ValidDate = coupon.ValidDate
            };
        }

        public async Task<bool> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            // Manual mapping from UpdateCouponDto to Coupon entity
            var coupon = new Coupon
            {
                Id = updateCouponDto.Id, // Use the Id from the DTO
                Code = updateCouponDto.Code,
                Rate = updateCouponDto.Rate,
                IsActive = updateCouponDto.IsActive,
                ValidDate = updateCouponDto.ValidDate
            };
            return await _couponRepository.UpdateAsync(coupon);
        }
    }
} 
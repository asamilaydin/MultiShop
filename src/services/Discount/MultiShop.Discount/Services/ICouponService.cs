using MultiShop.Discount.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiShop.Discount.Services
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task<ResultCouponDto> GetCouponByIdAsync(Guid id);
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<bool> UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<bool> DeleteCouponAsync(Guid id);
    }
} 
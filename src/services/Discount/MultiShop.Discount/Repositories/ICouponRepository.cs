using MultiShop.Discount.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiShop.Discount.Repositories
{
    public interface ICouponRepository
    {
        Task<IEnumerable<Coupon>> GetAllAsync();
        Task<Coupon> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Coupon coupon); // Returns the ID of the created coupon
        Task<bool> UpdateAsync(Coupon coupon);
        Task<bool> DeleteAsync(Guid id);
    }
} 
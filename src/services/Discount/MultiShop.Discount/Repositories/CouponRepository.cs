using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.Discount.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DapperContext _context;

        public CouponRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Coupon coupon)
        {
            string query = "INSERT INTO Coupons (Id, Code, Rate, IsActive, ValidDate) VALUES (@Id, @Code, @Rate, @IsActive, @ValidDate)";
            using (IDbConnection connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, coupon);
                return coupon.Id; // Dapper doesn't auto-return ID for GUIDs like this, ID is set in service layer
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            string query = "DELETE FROM Coupons WHERE Id = @Id";
            using (IDbConnection connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(query, new { Id = id });
                return affectedRows > 0;
            }
        }

        public async Task<IEnumerable<Coupon>> GetAllAsync()
        {
            string query = "SELECT * FROM Coupons";
            using (IDbConnection connection = _context.CreateConnection())
            {
                var coupons = await connection.QueryAsync<Coupon>(query);
                return coupons.ToList();
            }
        }

        public async Task<Coupon> GetByIdAsync(Guid id)
        {
            string query = "SELECT * FROM Coupons WHERE Id = @Id";
            using (IDbConnection connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Coupon>(query, new { Id = id });
            }
        }

        public async Task<bool> UpdateAsync(Coupon coupon)
        {
            string query = "UPDATE Coupons SET Code = @Code, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE Id = @Id";
            using (IDbConnection connection = _context.CreateConnection())
            {
                var affectedRows = await connection.ExecuteAsync(query, coupon);
                return affectedRows > 0;
            }
        }
    }
} 
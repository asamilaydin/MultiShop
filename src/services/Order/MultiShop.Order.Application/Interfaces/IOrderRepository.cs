using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IOrderRepository : IGenericRepository<MultiShop.Order.Domain.Entities.Order>
    {
    }
} 
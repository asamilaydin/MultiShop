namespace MultiShop.Discount.Dtos
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; } = true; // Default to active
        public DateTime ValidDate { get; set; }
    }
} 
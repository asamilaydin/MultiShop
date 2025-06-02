using System;

namespace MultiShop.Order.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
} 
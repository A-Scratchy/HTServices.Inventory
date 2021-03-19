using System;

namespace Inventory.Domain.Models.ProductAggregate
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public Uri ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public Category Category { get; set; }
        
        public int Quantity { get; set; }
        
        public DateTime LastUpdated { get; set; }
    }
}
using System;

namespace Inventory.Application.ViewModels
{
    public class ProductVm
    {
        public Guid ProductId { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}
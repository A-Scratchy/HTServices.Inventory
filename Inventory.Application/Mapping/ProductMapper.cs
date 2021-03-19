using Inventory.Application.ViewModels;
using Inventory.Domain.Models.ProductAggregate;

namespace Inventory.Application.Mapping
{
    public static class ProductMapper
    {
        public static ProductVm MapToProductVm(Product product) =>
            new ProductVm()
            {
                ProductId = product.ProductId,
                Reference = product.Reference,
                Name = product.Name,
                ImageUrl = product.ImageUrl?.ToString(),
                Price = product.Price,
                Cost = product.Cost,
                Category = product.Category.ToString(),
                Quantity = product.Quantity
            };
    }
}
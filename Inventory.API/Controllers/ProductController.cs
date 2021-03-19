using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Application.Interfaces;
using Inventory.Application.Mapping;
using Inventory.Application.ViewModels;
using Inventory.Domain.Models.ProductAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IInventoryDbContext _context;

        public ProductController(IInventoryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Product>>> Get()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();
            var productVMs = new List<ProductVm>();
            products.ForEach(p => productVMs.Add(ProductMapper.MapToProductVm(p)));
            return Ok(productVMs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVm>> Get(Guid id) =>
            Ok(await _context.Products.FindAsync(id));

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            product.ProductId = new Guid();
            _context.Products.Add(product);
            await _context.SaveChangesAsync(CancellationToken.None);
            return NoContent();
        }
    }
}
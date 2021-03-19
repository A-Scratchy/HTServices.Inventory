using Inventory.Application.Interfaces;
using Inventory.Domain.Models;
using Inventory.Domain.Models.ProductAggregate;
using Microsoft.EntityFrameworkCore;


namespace Inventory.Infrastructure
{
    public class InventoryDbContext: DbContext, IInventoryDbContext 
    {
        public DbSet<Product> Products { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Inventory;Integrated Security=True");
        }
    }
}
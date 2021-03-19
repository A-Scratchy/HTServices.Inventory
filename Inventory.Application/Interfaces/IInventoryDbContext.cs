using System.Threading;
using System.Threading.Tasks;
using Inventory.Domain.Models;
using Inventory.Domain.Models.ProductAggregate;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Interfaces
{
    public interface IInventoryDbContext 
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
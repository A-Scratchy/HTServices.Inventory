using System.Threading.Tasks;
using Inventory.Application.Interfaces;
using Inventory.Domain.Models.ProductAggregate;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using OrderPipelineContracts;

namespace Inventory.Events
{
    public class InventoryEventProcessor
    {
        private readonly IInventoryDbContext _context;
        private const string InQueue = "orderplacednew ";
        private const string OutQueue = "orderplacedpendingapproval";

        public InventoryEventProcessor(IInventoryDbContext context)
        {
            _context = context;
        }

        [FunctionName("AddProductInfoToPlacedOrderMessage")]
        [return: ServiceBus(OutQueue, Connection = "ServiceBusConnection")]
        public async Task<OrderPlacedPendingApproval> AddProductInfoToPlacedOrderMessage(
            [ServiceBusTrigger(InQueue, Connection = "ServiceBusConnection")]
            OrderPlacedNew order, ILogger log)
        {
            log.LogInformation(
                $"C# ServiceBus queue trigger function processed message from orders: {order.FirstName} {order.LastName}");

            var orderPlacedPendingApproval = new OrderPlacedPendingApproval(order);

            foreach (var (productId, quantity) in order.Products)
            {
                var product = await _context.Products.FindAsync(productId);

                if (product != null)
                {
                    orderPlacedPendingApproval.OrderItems.Add(new OrderPlacedPendingApproval.OrderItem()
                    {
                        Name = product.Name,
                        ProductId = product.ProductId,
                        Quantity = quantity
                    });
                }
            }

            return orderPlacedPendingApproval;
        }
    }
}
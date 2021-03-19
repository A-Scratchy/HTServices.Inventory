using Inventory.Application.Interfaces;
using Inventory.Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Inventory.Events.Startup))]

namespace Inventory.Events
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //TODO add mediator pattern with mediatR or Brighter
            builder.Services.AddTransient<IInventoryDbContext, InventoryDbContext>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.eShopWeb.ApplicationCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Microsoft.eShopWeb.Infrastructure.Services.OrderItemsReserver;

public interface IOrderItemsReserverService
{
    public Task ReserveAsync(string buyerId, Dictionary<string, int> items);
}

public class OrderItemsReserverService : IOrderItemsReserverService
{
    private readonly ConnectionSettings _connectionSettings;

    public OrderItemsReserverService(IOptionsSnapshot<ConnectionSettings> settings)
    {
        _connectionSettings = settings.Value;
    }

    public async Task ReserveAsync(string buyerId, Dictionary<string, int> items)
    {
        var orderItems = items.Select(item => new OrderItemDto(item.Key, item.Value)).ToList();
        var order = new OrderDto(buyerId, orderItems);

        try
        {
            await using var client = new ServiceBusClient(_connectionSettings.OrderItemsReserverServiceBusUrl);
            //TODO: add queue name to configuration
            await using var sender = client.CreateSender("reservedorderitemsqueue");

            var message = new ServiceBusMessage(JsonConvert.SerializeObject(order));
            await sender.SendMessageAsync(message);
        }
        catch (Exception exception)
        {
            // TODO: add logs
            // ignored
        }
    }
}

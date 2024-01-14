using Microsoft.eShopWeb.ApplicationCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.Infrastructure.Services.OrderItemsDelivery;

public interface IOrderItemsDeliveryService
{
    public Task CreateDeliveryAsync(Order order);
}

public class OrderItemsDeliveryService: IOrderItemsDeliveryService
{
    private readonly HttpClient _httpClient;
    private readonly ConnectionSettings _connectionSettings;

    public OrderItemsDeliveryService(IOptionsSnapshot<ConnectionSettings> settings, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _connectionSettings = settings.Value;
    }

    public async Task CreateDeliveryAsync(Order order)
    {
        var addressDto = new AddressDto(
            order.ShipToAddress.Street,
            order.ShipToAddress.City,
            order.ShipToAddress.State,
            order.ShipToAddress.Country,
            order.ShipToAddress.ZipCode);

        var items = order.OrderItems.Select(o =>
            new ItemDto(o.ItemOrdered.CatalogItemId, o.ItemOrdered.ProductName, o.UnitPrice)).ToList();

        var orderDto = new OrderDto(addressDto, order.Total(), items);

        await _httpClient.PostAsync(_connectionSettings.OrderItemsDeliveryUrl, Serialize(orderDto));
    }

    private static HttpContent Serialize(object payload)
    {
        return new StringContent(
            JsonConvert.SerializeObject(payload),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
    }
}

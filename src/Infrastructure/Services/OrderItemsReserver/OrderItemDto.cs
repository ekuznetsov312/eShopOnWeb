using Newtonsoft.Json;

namespace Microsoft.eShopWeb.Infrastructure.Services.OrderItemsReserver;

public class OrderItemDto(string id, int quantity)
{
    [JsonProperty("id")]
    public string Id { get; } = id;

    [JsonProperty("quantity")]
    public int Quantity { get; } = quantity;
}

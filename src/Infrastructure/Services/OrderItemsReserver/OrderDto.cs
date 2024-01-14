using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.eShopWeb.Infrastructure.Services.OrderItemsReserver;

public class OrderDto(string buyerId, List<OrderItemDto> orderItems)
{
    [JsonProperty("buyer_id")]
    public string BuyerId { get; } = buyerId;

    [JsonProperty("order_items")]
    public List<OrderItemDto> OrderItems { get; } = orderItems;
}

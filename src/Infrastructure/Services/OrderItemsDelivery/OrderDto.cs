using System.Collections.Generic;

namespace Microsoft.eShopWeb.Infrastructure.Services.OrderItemsDelivery;

public class OrderDto
{
    public AddressDto Address { get; }

    public List<ItemDto> Items { get; }

    public decimal TotalPrice { get; }

    public OrderDto(AddressDto address, decimal totalPrice, List<ItemDto> items)
    {
        Address = address;
        TotalPrice = totalPrice;
        Items = items;
    }
}
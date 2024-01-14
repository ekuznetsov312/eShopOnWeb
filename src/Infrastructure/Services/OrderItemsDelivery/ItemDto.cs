namespace Microsoft.eShopWeb.Infrastructure.Services.OrderItemsDelivery;

public class ItemDto
{
    public int CatalogItemId { get; }

    public string ProductName { get; }

    public decimal UnitPrice { get; }

    public ItemDto(int catalogItemId, string productName, decimal unitPrice)
    {
        CatalogItemId = catalogItemId;
        ProductName = productName;
        UnitPrice = unitPrice;
    }
}
namespace Microsoft.eShopWeb.Infrastructure.Services.OrderItemsDelivery;

public class AddressDto
{
    public string Street { get; }

    public string City { get; }

    public string State { get; }

    public string Country { get; }

    public string ZipCode { get; }

    public AddressDto(string street, string city, string state, string country, string zipcode)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipcode;
    }
}

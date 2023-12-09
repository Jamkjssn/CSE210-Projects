public class Address
{
    private string _streetAddress;
    private string _city;
    public Address(string streetAddress, string city)
    {
        _streetAddress = streetAddress;
        _city = city;
    }
    public string GetFullAddress()
    {
        string address = $"{_streetAddress}, {_city}";
        return address;
    }
}
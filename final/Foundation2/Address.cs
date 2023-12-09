public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;
    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }
    public bool InUSA()
    {
        if (_country.ToLower() == "usa" || _country.ToLower() == "united states")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string GetFullAddress()
    {
        string address = $"{_streetAddress}\n{_city}, {_state}";
        return address;
    }
}
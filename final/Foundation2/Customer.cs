public class Customer
{
    private string _name;
    private Address _address;
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }
    public bool InUSA()
    {
        return _address.InUSA();
    }
    public string CreateShippingLabel()
    {
        string fulladdress = _address.GetFullAddress(); //Returns a string with address info
        return $"{_name}\n{fulladdress}";
    }
}
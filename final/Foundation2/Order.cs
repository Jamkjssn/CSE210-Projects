public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private double _finalPrice;
    private bool _inUSA;
    private bool _priceCalculated;
    public Order(Customer customer)
    {
        _products = new();
        _customer = customer;
        _inUSA = customer.InUSA();
        _priceCalculated = false;
    }
    public void DisplayShippingLablel()
    {
        Console.WriteLine($"{_customer.CreateShippingLabel()}");
    }
    public void DisplayPackingLabel()
    {
        foreach (Product product in _products)
        {
            product.DisplayProductInfo();
        }
    }
    public void CalculatePrice()
    {
        _finalPrice = 0;
        foreach(Product product in _products)
        {
            _finalPrice += product.GetPrice();
        }
        if (_inUSA)
        {
            _finalPrice += 5;
        }
        else
        {
            _finalPrice += 35;
        }
        _priceCalculated = true;
    }
    public void DisplayPrice()
    {
        if(!_priceCalculated)
        {
            CalculatePrice();
        }
        Console.WriteLine($"Total Price: ${_finalPrice}");
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}
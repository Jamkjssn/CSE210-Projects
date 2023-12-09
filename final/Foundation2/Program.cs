using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n\tFoundation 2, Online Shopping");

        Product apples = new("Apple", 00013, 2.95, 5);
        Product keys = new("Key", 00201, 8.50, 1);
        Product candel = new("Candel", 16495, 12.00, 2);
        Product chocolate = new("Chocolate", 51867, 1.50, 6);
        Product blanket = new("Blanket", 02167, 15.23, 2);
        Product cardboard = new("Cardboard", 99999, 1500.26, 1);

        Address Address1 = new("1425 Mountain Rd", "Rexburg", "Idaho", "USA");
        Customer customer1 = new("John Parker", Address1);
        Order order1 = new(customer1);
        order1.AddProduct(apples);
        order1.AddProduct(candel);
        order1.AddProduct(blanket);

        Order order2 = new(customer1);
        order2.AddProduct(cardboard);
        order2.AddProduct(apples);
        order2.AddProduct(keys);
        order2.AddProduct(chocolate);

        List<Order> orders = new()
        {
            order1,
            order2
        };
        int index = 1;
        foreach(Order order in orders)
        {
        Console.WriteLine($"\nOrder #{index}:");
        Console.WriteLine("\t\tShipping Label:");
        order1.DisplayShippingLablel();
        Console.WriteLine("\t\tPacking Label:");
        order1.DisplayPackingLabel();
        index++;
        }
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        Console.WriteLine($"Your name is {name}");

        if (name == "Jacob")
        {
            Console.WriteLine("Thats the name of who wrote this program");
        
        }

    }
}

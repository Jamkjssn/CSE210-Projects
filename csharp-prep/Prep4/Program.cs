using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new();

        Console.Write("Enter a number: ");
        string numberString = Console.ReadLine();
        int number = int.Parse(numberString);

        while (number != 0){
            // Append
            numbers.Add(number);

            // Get new number
            Console.Write("Enter a number: ");
            numberString = Console.ReadLine();
            number = int.Parse(numberString);
        }

        int sum = 0;
        int largest = 0;

        foreach (int num in numbers){
            sum += num;
            if (num > largest){
                largest = num;
            }
        }
        int average = sum/numbers.Count;

        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The agerage is {average}");
        Console.WriteLine($"The largest number is {largest}");

    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");

        Fraction fraction1 = new();
        Fraction fraction2 = new(5);
        Fraction fraction3 = new(2,3);

        int a = fraction1.GetTop();
        fraction2.SetTop(6);
        int b = fraction2.GetTop();
        int c = fraction3.GetBottom();
        fraction3.SetBottom(3);
        int d = fraction3.GetBottom();

        Console.WriteLine($"1 = {a}, 6 = {b}, 3 = {c}, 4 = {d}");

        DisplayFractions(fraction3);

        fraction3.SetTop(12);
        fraction3.SetBottom(10);

        DisplayFractions(fraction3);

        fraction3.SetTop(1);
        fraction3.SetBottom(2);

        DisplayFractions(fraction3);
    }
    static void DisplayFractions(Fraction fraction)
    {
        string stringfraction = fraction.GetFractionString();
        double doublefraction = fraction.GetDecimalValue();
        Console.WriteLine($"{stringfraction}, {doublefraction}");
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> Shapelist = new();

        Square square = new("Red", 12);
        Square square2 = new("Black", 6);
        Rectangle rectangle = new("Green", 10, 5);
        Rectangle rectangle2 = new("Magenta", 3, 5);
        Circle circle = new("Blue", 14);
        Circle circle2 = new("Orange", 3.1415962);

        Shapelist.Add(square);
        Shapelist.Add(square2);
        Shapelist.Add(rectangle);
        Shapelist.Add(rectangle2);
        Shapelist.Add(circle);
        Shapelist.Add(circle2);

        foreach (Shape shape in Shapelist)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"Color: {color}\tArea: {area}");
        }
    }
}
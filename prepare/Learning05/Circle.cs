using System.Formats.Asn1;
using System.Net.NetworkInformation;

public class Circle : Shape
{
    private double _radius;
    public Circle(string color, double side) : base(color)
    {
        _radius = side;
    }
    public override double GetArea()
    {
        double area = Math.PI * (_radius*_radius);
        return area;
    }
}
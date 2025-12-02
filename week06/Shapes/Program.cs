using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> list = new List<Shape>();
        list.Add(new Square("red", 14));
        list.Add(new Rectangle("blue", 5, 12));
        list.Add(new Circle("black", 4));

        foreach(Shape shape in list)
        {
            Console.WriteLine($"Color: {shape.GetColor()},  Area: {shape.GetArea():F2}");
        }
        
        Square sq1 = new Square("red", 14);
        Console.WriteLine($"The area of the {sq1.GetColor()} square is {sq1.GetArea()}");

        Rectangle rect1 = new Rectangle("blue", 5, 12);
        Console.WriteLine($"The area of the {rect1.GetColor()} rectangle is {rect1.GetArea()}");

        Circle circle1 = new Circle("black", 4);
        Console.WriteLine($"The area of the {circle1.GetColor()} circle is {circle1.GetArea():F2}");
    }
}
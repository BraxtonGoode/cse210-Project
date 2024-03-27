using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("blue", 4);
        Rectangle rectangle = new Rectangle("red",5,4);
        Circle circle = new Circle("purple", 3);

        List<Shape> shapes = new List<Shape>();

        shapes.Add(circle);
        shapes.Add(rectangle);
        shapes.Add(square);

        foreach (Shape shape in shapes)
        {
            // Notice that all shapes have a GetColor method from the base class
            string color = shape.GetColor();

            // Notice that all shapes have a GetArea method, but the behavior is
            // different for each type of shape
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
            
        }

   

    }
}
List<Shape> shapes = new List<Shape>();
shapes.Add(new Square("Red", 4));
shapes.Add(new Rectangle("Blue", 5, 2));
shapes.Add(new Circle("Green", 3));

foreach (Shape shape in shapes)
{
    Console.WriteLine($"{shape.GetColor()} area: {shape.GetArea()}");
}

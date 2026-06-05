using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "Kenneth";
        int age = 23;

        Console.WriteLine(name);
        Console.WriteLine(age);
        Console.WriteLine("Hello " + name);

        int top = 3;
        int bottom = 4;
        Console.WriteLine($"{top}/{bottom}");
        Console.WriteLine((double)top / bottom);

        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        fraction4.SetTop(6);
        fraction4.SetBottom(7);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());
    }
}

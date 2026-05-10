using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (number != 0)
        {
            Console.Write("Enter number: ");
            string numberInput = Console.ReadLine();
            number = int.Parse(numberInput);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum = 0;
        int largestNumber = numbers[0];
        int smallestPositiveNumber = int.MaxValue;

        foreach (int value in numbers)
        {
            sum += value;

            if (value > largestNumber)
            {
                largestNumber = value;
            }

            if (value > 0 && value < smallestPositiveNumber)
            {
                smallestPositiveNumber = value;
            }
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");

        if (smallestPositiveNumber != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositiveNumber}");
        }

        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int value in numbers)
        {
            Console.WriteLine(value);
        }
    }
}

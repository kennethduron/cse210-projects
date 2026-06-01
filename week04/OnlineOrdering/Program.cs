using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address firstAddress = new Address(
            "125 Maple Street",
            "Boise",
            "Idaho",
            "USA");
        Customer firstCustomer = new Customer("Emma Johnson", firstAddress);
        Order firstOrder = new Order(firstCustomer);
        firstOrder.AddProduct(new Product("Wireless Mouse", "WM-204", 24.99, 2));
        firstOrder.AddProduct(new Product("USB-C Cable", "UC-115", 8.50, 3));

        Address secondAddress = new Address(
            "48 Avenida Central",
            "Tegucigalpa",
            "Francisco Morazan",
            "Honduras");
        Customer secondCustomer = new Customer("Carlos Martinez", secondAddress);
        Order secondOrder = new Order(secondCustomer);
        secondOrder.AddProduct(new Product("Notebook", "NB-310", 5.75, 4));
        secondOrder.AddProduct(new Product("Desk Lamp", "DL-420", 32.50, 1));
        secondOrder.AddProduct(new Product("Pen Set", "PS-108", 7.25, 2));

        List<Order> orders = new List<Order> { firstOrder, secondOrder };

        foreach (Order order in orders)
        {
            Console.WriteLine($"Total Price: ${order.CalculateTotalPrice():F2}");
            Console.WriteLine();
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
    }
}

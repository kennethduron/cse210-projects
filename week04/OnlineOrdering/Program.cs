using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA customer)
        Address address1 = new Address("123 Main St", "Miami", "FL", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P100", 800, 1));
        order1.AddProduct(new Product("Mouse", "P200", 20, 2));

        // Order 2 (International customer)
        Address address2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Maria Lopez", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P300", 600, 1));
        order2.AddProduct(new Product("Headphones", "P400", 150, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine("==================================");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());

            Console.WriteLine("\nShipping Label:");
            Console.WriteLine(order.GetShippingLabel());

            Console.WriteLine($"\nTotal Cost: ${order.CalculateTotalCost()}");
            Console.WriteLine();
        }
    }
}

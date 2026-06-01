using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;

        foreach (Product product in _products)
        {
            totalPrice += product.CalculateTotalCost();
        }

        if (_customer.GetAddress().IsInUsa())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        StringBuilder packingLabel = new StringBuilder();

        foreach (Product product in _products)
        {
            packingLabel.AppendLine($"{product.GetName()} - {product.GetProductId()}");
        }

        return packingLabel.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}

using System;
using System.Collections.Generic;

class Order
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

    public Customer GetCustomer() => _customer;
    public void SetCustomer(Customer customer) => _customer = customer;

    public List<Product> GetProducts() => _products;

    public decimal GetTotalCost()
    {
        decimal total = 0;

        // Sum all product costs
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        if (_customer.IsInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL\n";
        label += "==============\n";
        
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL\n";
        label += "===============\n";
        label += $"{_customer.GetName()}\n";
        label += _customer.GetAddress().GetFullAddress();
        
        return label;
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create Order 1 Customer in USA
        Address address1 = new Address("123 Main Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        
        Product product1 = new Product("Laptop", "SKU-001", 999.99m, 1);
        Product product2 = new Product("Mouse", "SKU-002", 29.99m, 2);
        Product product3 = new Product("Keyboard", "SKU-003", 79.99m, 1);
        
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Console.WriteLine("========== ORDER 1 ==========");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        // Create Order 2 Customer outside USA
        Address address2 = new Address("456 Oxford Street", "London", "England", "United Kingdom");
        Customer customer2 = new Customer("Jane Doe", address2);
        
        Product product4 = new Product("Monitor", "SKU-004", 349.99m, 1);
        Product product5 = new Product("USB Cable", "SKU-005", 12.99m, 3);
        
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine("========== ORDER 2 ==========");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}");
    }
}
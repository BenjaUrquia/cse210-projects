using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private int productId;
    private decimal price;
    private int quantity;

    public Product(string name, int productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal TotalCost()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public int GetProductId()
    {
        return productId;
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}, {city}, {state}, {country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetFullAddress()
    {
        return address.GetFullAddress();
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;
    private decimal shippingCost;

    public Order(Customer customer, List<Product> products)
    {
        this.customer = customer;
        this.products = products;
        shippingCost = customer.IsInUSA() ? 5m : 35m;
    }

    public decimal TotalCost()
    {
        decimal total = 0m;
        foreach (Product product in products)
        {
            total += product.TotalCost();
        }
        return total + shippingCost;
    }

    public string PackingLabel()
    {
        string label = "";
        foreach (Product product in products)
        {
            label += $"Name: {product.GetName()}, ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"Name: {customer.GetName()}\nAddress: {customer.GetFullAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("1600 Burrstone Rd", "Utica", "NY", "USA");
        Customer customer1 = new Customer("Charles Harmon", address1);

        List<Product> products1 = new List<Product>
        {
            new Product("Widget", 1, 10.50m, 2),
            new Product("Gadget", 2, 15.75m, 1)
        };

        Order order1 = new Order(customer1, products1);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Total Price: $" + order1.TotalCost());
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine();

        Address address2 = new Address("8370 Côte Saint Luc Rd", "Montreal", "QB", "Canada");
        Customer customer2 = new Customer("Jhon Meadowbrook", address2);

        List<Product> products2 = new List<Product>
        {
            new Product("Thingamajig", 3, 20.25m, 3),
            new Product("Doodad", 4, 8.99m, 4)
        };

        Order order2 = new Order(customer2, products2);

        Console.WriteLine("Order 2:");
        Console.WriteLine("Total Price: $" + order2.TotalCost());
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.ShippingLabel());
    }
}
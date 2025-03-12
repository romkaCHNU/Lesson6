using System;
using System.Collections.Generic;

abstract class OrderItem
{
    public string Name { get; }
    public double Price { get; }

    protected OrderItem(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public abstract void Prepare();
}
enum PizzaSize
{
    Small,
    Medium,
    Large
}
class Pizza : OrderItem
{
    public PizzaSize Size { get; }

    public Pizza(string name, double price, PizzaSize size) : base(name, price)
    {
        Size = size;

    }

    public override void Prepare()
    {
        Console.WriteLine($"Baking {Size} pizza: {Name}");
    }
}

class Drink : OrderItem
{
    public bool IsCold { get; }

    public Drink(string name, double price, bool isCold) : base(name, price)
    {
        IsCold = isCold;
    }

    public override void Prepare()
    {
        Console.WriteLine($"Pouring {(IsCold ? "cold" : "hot")} drink: {Name}");
    }
}

class Dessert : OrderItem
{
    public Dessert(string name, double price) : base(name, price) { }

    public override void Prepare()
    {
        Console.WriteLine($"Making dessert: {Name}");
    }
}

class Order
{
    public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
    public string Status { get; private set; } = "Pending";

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }

    public void ProcessOrder()
    {
        Console.WriteLine("Processing order...");
        Status = "In Progress";
        Console.WriteLine(new string('-', 100));
        foreach (var item in Items)
        {
            item.Prepare();
        }
        Console.WriteLine(new string('-', 100));

        Status = "Completed";
        Console.WriteLine("Order completed!");
    }
}

class Program
{
    static void CreateSampleOrder()
    {
        Order order = new Order();

        order.AddItem(new Pizza("Pepperoni", 10.99, PizzaSize.Large));
        order.AddItem(new Drink("Cola", 2.99, true));
        order.AddItem(new Dessert("Cheesecake", 5.49));

        Console.WriteLine("New order created!");
        order.ProcessOrder();
    }

    static void Main()
    {
        CreateSampleOrder();
    }
}

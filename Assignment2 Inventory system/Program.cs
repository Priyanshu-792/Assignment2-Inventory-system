using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }

    public override string ToString()
    {
        return $"{Name}, {Price} RS, {Quantity}, {Type}";
    }
}

public class InventoryManager
{
    private List<Product> products = new List<Product>();

    public void AddProduct(string name, decimal price, int quantity, string type)
    {
        products.Add(new Product { Name = name, Price = price, Quantity = quantity, Type = type });
    }

    public void PrintTotalProducts()
    {
        Console.WriteLine($"\nTotal number of products: {products.Count}");
    }

    public void PrintAllProducts()
    {
        Console.WriteLine("\nList of all products:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }



    public void PrintProductsByType(string type)
    {
        var filteredProducts = products.Where(p => p.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"\nProducts of type {type}:");
        foreach (var product in filteredProducts)
        {
            Console.WriteLine(product);
        }
    }

    public void RemoveProduct(string name)
    {
        products.RemoveAll(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
      
    }

    public int UpdateProductQuantity(string name, int additionalQuantity)
    {
        var product = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product != null)
        {
            product.Quantity += additionalQuantity;
            return product.Quantity;
        }
        return -1; // Product not found
    }

    public void CalculateTotalPrice(List<(string, decimal)> items)
    {
        decimal totalPrice = 0;
        foreach (var (itemName, quantity) in items)
        {
            var product = products.FirstOrDefault(p => p.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                totalPrice += product.Price * quantity;
            }
        }
        Console.WriteLine($"Total price for the purchase: {Math.Round(totalPrice)} RS");
    }

    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();

            // Input
            manager.AddProduct("lettuce", 10.5m, 50, "Leafy green");
            manager.AddProduct("cabbage", 20m, 100, "Cruciferous");
            manager.AddProduct("pumpkin", 30m, 30, "Marrow");
            manager.AddProduct("cauliflower", 10m, 25, "Cruciferous");
            manager.AddProduct("zucchini", 20.5m, 50, "Marrow");
            manager.AddProduct("yam", 30m, 50, "Root");
            manager.AddProduct("spinach", 10m, 100, "Leafy green");
            manager.AddProduct("broccoli", 20.2m, 75, "Cruciferous");
            manager.AddProduct("garlic", 30m, 20, "Leafy green");
            manager.AddProduct("silverbeet", 10m, 50, "Marrow");

            // Output
            manager.PrintTotalProducts();
            manager.AddProduct("Potato", 10m, 50, "Root");
            manager.PrintAllProducts();
            manager.PrintTotalProducts();
            manager.PrintProductsByType("Leafy green");
            manager.RemoveProduct("garlic");
            Console.Write("\nAfter Removing Garlic");
            manager.PrintTotalProducts();
            Console.WriteLine($"\nFinal quantity of cabbage after adding 50 more quantity: {manager.UpdateProductQuantity("cabbage", 50)}");

            // Calculating total price
            List<(string, decimal)> purchaseItems = new List<(string, decimal)>
        {
            ("lettuce", 1),
            ("zucchini", 2),
            ("broccoli", 1)
        };
            manager.CalculateTotalPrice(purchaseItems);

        }
    }
}

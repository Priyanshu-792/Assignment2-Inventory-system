using System;
class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product("lettuce", 10.5, 50, "Leafy green"),
            new Product("cabbage", 20, 100, "Cruciferous"),
            new Product("pumpkin", 30, 30, "Marrow"),
            new Product("cauliflower", 10, 25, "Cruciferous"),
            new Product("zucchini", 20.5, 50, "Marrow"),
            new Product("yam", 30, 50, "Root"),
            new Product("spinach", 10, 100, "Leafy green"),
            new Product("broccoli", 20.2, 75, "Cruciferous"),
            new Product("garlic", 30, 20, "Leafy green"),
            new Product("silverbeet", 10, 50, "Marrow")
        };

        
        Console.WriteLine($"Total number of products: {products.Count}");


        Product newProduct = new Product("Potato", 10, 50, "Root");
        products.Add(newProduct);
        Console.WriteLine("\nAdded a new product:");
        PrintProducts(products);

        Console.WriteLine("\nLeafy green products:");
        var leafyGreenProducts = products.Where(p => p.Type == "Leafy green");
        PrintProducts(leafyGreenProducts);


        products.RemoveAll(p => p.Name == "garlic");
        Console.WriteLine("\nRemoved Garlic from the list:");
        PrintProducts(products);

        // Add 50 cabbages to the inventory
        Product cabbage = products.FirstOrDefault(p => p.Name == "cabbage");
        if (cabbage != null)
        {
            cabbage.Quantity += 50;
        }
        Console.WriteLine("\nAdded 50 cabbages to the inventory:");
        PrintProducts(products);

        // Calculate the total price for the purchase
        double lettucePrice = products.FirstOrDefault(p => p.Name == "lettuce")?.Price ?? 0;
        double zucchiniPrice = products.FirstOrDefault(p => p.Name == "zucchini")?.Price ?? 0;
        double broccoliPrice = products.FirstOrDefault(p => p.Name == "broccoli")?.Price ?? 0;

        double totalPrice = 1 * lettucePrice + 2 * zucchiniPrice + 1 * broccoliPrice;
        Console.WriteLine($"\nThe total price for the purchase is: {totalPrice} RS");
        Console.ReadLine();
    }

    static void PrintProducts(IEnumerable<Product> products)
    {
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name}, {product.Price} RS, {product.Quantity}, {product.Type}");
        }
        Console.WriteLine($"Total number of products: {products.Count()}");

    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; }

    public Product(string name, double price, int qty, string type)
    {
        Name = name;
        Price = price;
        Quantity = qty;
        Type = type;
    }
}
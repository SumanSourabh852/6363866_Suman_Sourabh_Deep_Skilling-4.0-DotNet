using System;

class Program
{
    static void Main(string[] args)
    {
        Product[] products = new Product[]
        {
            new Product(101, "Shoes", "Footwear"),
            new Product(102, "T-Shirt", "Apparel"),
            new Product(103, "Laptop", "Electronics"),
            new Product(104, "Book", "Education")
        };

        // Sort products by ProductName for binary search
        Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));

        Console.WriteLine("Searching for 'Laptop'...");

        var resultLinear = SearchDemo.LinearSearch(products, "Laptop");
        Console.WriteLine("Linear Search Result: " + (resultLinear != null ? resultLinear.ToString() : "Not found"));

        var resultBinary = SearchDemo.BinarySearch(products, "Laptop");
        Console.WriteLine("Binary Search Result: " + (resultBinary != null ? resultBinary.ToString() : "Not found"));

        Console.ReadLine();
    }
}

using WebApp.Models;

namespace WebApp.Data;

public class TestData
{
    public static ICollection<Product> Products { get; } = Enumerable.Range(1, 100)
       .Select(i => new Product
        {
            Id = i,
            Name = $"Product-{i}",
            Price = i * 1000,
        })
       .ToList();
}
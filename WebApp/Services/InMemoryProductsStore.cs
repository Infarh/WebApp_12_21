using WebApp.Data;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services;

public class InMemoryProductsStore : IProductsStore
{
    private readonly ILogger<InMemoryProductsStore> _Logger;
    private readonly ICollection<Product> _Products;
    private int _LastFreeId;

    public InMemoryProductsStore(ILogger<InMemoryProductsStore> Logger)
    {
        _Logger = Logger;
        _Products = TestData.Products;

        _LastFreeId = _Products.Count == 0 ? 1 : _Products.Max(p => p.Id) + 1;
    }

    public IEnumerable<Product> GetAll() => _Products;

    public Product? GetById(int id)
    {
        var product = _Products.FirstOrDefault(p => p.Id == id);
        return product;
    }

    public int Add(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        if (_Products.Contains(product))
            return product.Id;

        product.Id = _LastFreeId++;
        _Products.Add(product);

        return product.Id;
    }

    public bool Update(Product product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        if (_Products.Contains(product))
            return true;

        var db_product = GetById(product.Id);
        if (db_product is null)
            return false;

        db_product.Name = product.Name;
        db_product.Price = product.Price;

        return true;
    }

    public bool Delete(int id)
    {
        var db_product = GetById(id);
        if (db_product is null)
            return false;

        _Products.Remove(db_product);

        return true;
    }
}
using WebApp.Models;

namespace WebApp.Services.Interfaces;

public interface IProductsStore
{
    IEnumerable<Product> GetAll();

    Product? GetById(int id);

    int Add(Product product);

    bool Update(Product product);

    bool Delete(int id);
}
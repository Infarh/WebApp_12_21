using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class CatalogController : Controller
{
    private readonly ILogger<CatalogController> _Logger;
    private readonly ICollection<Product> _Products;

    public CatalogController(ILogger<CatalogController> Logger)
    {
        _Products = TestData.Products;
        _Logger = Logger;
    }

    public IActionResult Index()
    {
        return View(_Products);
    }

    public IActionResult Edit(int id)
    {
        var product = _Products.FirstOrDefault(p => p.Id == id);
        if (product is null)
            return NotFound();

        var model = new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(ProductViewModel Model)
    {
        if (!ModelState.IsValid)
            return View(Model);

        var product = _Products.FirstOrDefault(p => p.Id == Model.Id);
        if (product is null)
            return NotFound();

        product.Name = Model.Name;
        product.Price = Model.Price;

        return RedirectToAction(nameof(Index));
    }
}
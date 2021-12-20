using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services.Interfaces;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class CatalogController : Controller
{
    private readonly ILogger<CatalogController> _Logger;
    private readonly IProductsStore _Products;

    public CatalogController(IProductsStore Products, ILogger<CatalogController> Logger)
    {
        _Products = Products;
        _Logger = Logger;
    }

    public IActionResult Index()
    {
        var products = _Products.GetAll();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _Products.GetById(id);
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

    public IActionResult Edit(int id)
    {
        var product = _Products.GetById(id);
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

        var product = new Product
        {
            Id = Model.Id,
            Name = Model.Name,
            Price = Model.Price,
        };

        _Products.Update(product);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var product = _Products.GetById(id);
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
    public IActionResult DeleteConfirmed(int id)
    {
        _Products.Delete(id);
        return RedirectToAction("Index");
    }
}
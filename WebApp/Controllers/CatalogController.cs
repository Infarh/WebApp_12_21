using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

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
}
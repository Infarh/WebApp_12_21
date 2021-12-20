using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

//[Controller]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _Logger;

    public HomeController(ILogger<HomeController> Logger) => _Logger = Logger;

    public IActionResult Index()
    {
        //return StatusCode(123, new { Message = "Странный статусный код" });
        //return BadRequest();
        //return NotFound();
        return View();
        //return File()
        //return new FileStreamResult()
        //return Json(new { ServerTime = DateTime.Now, Message = "Hello World!" });
        //return Content("Hello World!");
    }

    public DateTime ServerTime()
    {
        //HttpContext.Response.Headers["Time"] = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        //HttpContext.Response.Cookies.Append("Time", DateTime.Now.ToString());
        return DateTime.Now;
    }
}
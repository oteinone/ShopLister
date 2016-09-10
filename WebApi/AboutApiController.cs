
using Microsoft.AspNetCore.Mvc;

[Route("api/about")]
public class AboutController : Controller
{
    [HttpGet]   
    public IActionResult About()
    {
        return Content("You have connected to ShopLister api!");
    }
}
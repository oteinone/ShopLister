
using Microsoft.AspNetCore.Mvc;

namespace ShopLister.MVC
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content(CreateHTMLPage("ShopLister home page", "This is a temporary home page for ShopLister!"), "text/html");
        }
        
        private static string CreateHTMLPage(string title, string content)
        {
            return $"<html><head><title>{title}</title></head><body>{content}</body></html>";
        }
    }
}
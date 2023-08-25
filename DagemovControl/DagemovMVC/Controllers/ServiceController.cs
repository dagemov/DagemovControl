using Microsoft.AspNetCore.Mvc;

namespace DagemovMVC.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

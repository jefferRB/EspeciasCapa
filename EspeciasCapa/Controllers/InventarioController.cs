using Microsoft.AspNetCore.Mvc;

namespace EspeciasCapa.Controllers
{
    public class InventarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

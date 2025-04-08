using Microsoft.AspNetCore.Mvc;

namespace EspeciasCapa.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

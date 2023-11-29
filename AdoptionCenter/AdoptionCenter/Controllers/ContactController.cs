using Microsoft.AspNetCore.Mvc;

namespace AdoptionCenter.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace  PierrsBakery.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using PierrsBakery.Models;

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
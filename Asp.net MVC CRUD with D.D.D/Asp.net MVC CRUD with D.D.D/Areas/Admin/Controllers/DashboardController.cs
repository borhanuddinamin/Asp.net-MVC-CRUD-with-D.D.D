using Microsoft.AspNetCore.Mvc;

namespace Asp.net_MVC_CRUD_with_D.D.D.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

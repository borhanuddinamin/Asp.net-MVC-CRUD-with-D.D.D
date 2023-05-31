using Autofac;
using CRUD.Infrastructure;
using CRUD.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {

        ILifetimeScope _lifetimeScope;
        public CourseController(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }
        public IActionResult Index()
        {
            var model = _lifetimeScope.Resolve<CourseListModel>();
            return View(model);
        }

        public async Task<JsonResult> GetCourses()
        {
            var dataTableModel = new DataTableAjaxRequestUtility(Request);
            var model = _lifetimeScope.Resolve<CourseListModel>();

            var data = await model.GetPagedCoursesAsync(dataTableModel);
            return Json(data);

        }
    }
}

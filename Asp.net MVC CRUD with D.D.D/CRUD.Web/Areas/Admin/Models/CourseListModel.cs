
using Asp.net_MVC_CRUD_with_D.D.D.Models;
using CRUD.Domain.Services;

namespace CRUD.Web.Areas.Admin.Models
{

    public class CourseListModel
    {
        private readonly ICourseServices _CourseServices;
        public CourseListModel(ICourseServices courseServices)
        {
            _CourseServices = courseServices;

        }


        public IList<Course> GetCourses()
        {
            return _CourseServices.GetCourses();

        }
    }
}

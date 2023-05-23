using Asp.net_MVC_CRUD_with_D.D.D.Models;
using CRUD.Domain.Services;

namespace Asp.net_MVC_CRUD_with_D.D.D.Areas.Admin.Models
{
    public class CourseListModel
    {
        private ICourseServices _CourseServices;
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

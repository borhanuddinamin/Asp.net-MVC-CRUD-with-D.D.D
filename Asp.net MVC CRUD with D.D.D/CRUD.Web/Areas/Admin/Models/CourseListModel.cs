
using Asp.net_MVC_CRUD_with_D.D.D.Models;
using CRUD.Domain.Services;
using CRUD.Infrastructure;

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

        public async Task<object> GetPagedCoursesAsync
            (DataTableAjaxRequestUtility dataTableAjaxRequest)
        {
            var data = await _CourseServices.GetPageCourseAsync(
                dataTableAjaxRequest.PageIndex,
                dataTableAjaxRequest.PageSize,
                dataTableAjaxRequest.SearchText,
                dataTableAjaxRequest.GetShortText(
                    new string[] { "Name", "Fee" }));

            return new
            {
                recordTotal = data.total,
                recordsFiltered = data.totalDispplay,
                data = (from record in data.records
                        select new string[]
                        {
                           record.Name,
                           record.Fees.ToString(),
                           record.id.ToString()
                        }.ToArray())
            };
        }
    }
}

using Asp.net_MVC_CRUD_with_D.D.D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Services
{
    public  interface ICourseServices
    {
        public IList<Course> GetCourses();
    }
}

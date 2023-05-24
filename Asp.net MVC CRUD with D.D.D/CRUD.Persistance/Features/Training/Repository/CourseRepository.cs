using Asp.net_MVC_CRUD_with_D.D.D.Models;
using CRUD.Applicatiion.Features.Training.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Persistance.Features.Training.Repository
{
    public class CourseRepository : Repository<Course, int>, ICourseRepository
    {
        public CourseRepository(DbContext dbContext) : base(dbContext)
        {
        }
       
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

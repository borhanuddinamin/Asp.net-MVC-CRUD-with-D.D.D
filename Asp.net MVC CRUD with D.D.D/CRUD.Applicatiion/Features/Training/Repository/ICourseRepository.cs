using Asp.net_MVC_CRUD_with_D.D.D.Models;
using CRUD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Applicatiion.Features.Training.Repository
{
    public interface ICourseRepository : IRepository<Course, int>
    {
    }
}

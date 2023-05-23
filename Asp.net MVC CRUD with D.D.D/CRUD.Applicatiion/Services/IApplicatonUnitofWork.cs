using Asp.net_MVC_CRUD_with_D.D.D.Models;
using CRUD.Applicatiion.Features.Training.Repository;
using CRUD.Domain.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Applicatiion.Services
{
    public  interface IApplicatonUnitofWork
    {
        ICourseRepository Courses { get; }

    }
}

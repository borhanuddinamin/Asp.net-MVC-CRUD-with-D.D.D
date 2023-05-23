
using CRUD.Applicatiion.Features.Training.Repository;
using CRUD.Applicatiion.Services;
using CRUD.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Persistance
{
    public  class ApplicatonUnitofWork:UnitofWork, IApplicatonUnitofWork
    {
        

        public ICourseRepository Courses { get; } 

        public ApplicatonUnitofWork(IApplicationDbContext dbContext,
                    ICourseRepository courseRepository) : base((DbContext)dbContext)
        {
            Courses = courseRepository;
        }

       
    }
}

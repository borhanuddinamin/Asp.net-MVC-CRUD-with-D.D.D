

using Asp.net_MVC_CRUD_with_D.D.D.Models;
using Autofac;
using CRUD.Applicatiion.Features.Training.Repository;
using CRUD.Applicatiion.Services;
using CRUD.Domain.Services;

namespace CRUD.Applicatiion
{
    public  class ApplicationModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CourseServices>().As<ICourseServices>().InstancePerLifetimeScope();
        }
    }
}

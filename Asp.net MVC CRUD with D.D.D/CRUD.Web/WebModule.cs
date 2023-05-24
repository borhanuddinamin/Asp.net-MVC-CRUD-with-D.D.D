using CRUD.Web.Models;
using CRUD.Web.Data;
using Autofac;

using Autofac.Core.Registration;
using CRUD.Web.Areas.Admin.Models;
using CRUD.Applicatiion.Features.Training.Repository;
using CRUD.Persistance.Features.Training.Repository;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CourseListModel>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerLifetimeScope();
    }
}
using Asp.net_MVC_CRUD_with_D.D.D.Areas.Admin.Models;
using Asp.net_MVC_CRUD_with_D.D.D.Models;
using Autofac;

using Autofac.Core.Registration;


public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CourseListModel>().AsSelf().InstancePerLifetimeScope();
    }
}
using Autofac;
using CRUD.Applicatiion.Features.Training.Repository;
using CRUD.Applicatiion.Services;
using CRUD.Persistance.Features.Training.Repository;
using CRUD.Persistence;


namespace CRUD.Persistance
{
    public class PersistanceModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationString;

        public  PersistanceModule(string ConnectionString, string migration){
            _connectionString=ConnectionString;
            _migrationString = migration;

    }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connection", _connectionString)
                .WithParameter("migration", _migrationString).InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connection", _connectionString)
                .WithParameter("migration",_migrationString).InstancePerLifetimeScope();

            builder.RegisterType<ApplicatonUnitofWork>().As<IApplicatonUnitofWork>()
               .InstancePerLifetimeScope();

          



        }
    }
}

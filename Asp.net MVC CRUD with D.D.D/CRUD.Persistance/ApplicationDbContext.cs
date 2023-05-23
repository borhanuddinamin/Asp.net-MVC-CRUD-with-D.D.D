using Asp.net_MVC_CRUD_with_D.D.D.Models;
using CRUD.Persistence;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public readonly string _Connectionstring;
        public readonly string _migration;

        public ApplicationDbContext(string connection,string migration)
        {
            _Connectionstring = connection;
            _migration = migration;
        }

        public DbSet<Course> Courses { get ; set ; }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_Connectionstring, (x) => x.MigrationsAssembly(_migration));
            }


        }
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
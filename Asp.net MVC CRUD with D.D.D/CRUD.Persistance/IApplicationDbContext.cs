using Asp.net_MVC_CRUD_with_D.D.D.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Course> Courses { get; set; }
    }
}
using CRUD.Domain.Unit_of_work;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Persistance
{
    public abstract class UnitofWork : IUnitofWork
    {
        public readonly DbContext _dbContext;
        public UnitofWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void save() => _dbContext?.SaveChanges();
        public void Dispose ()=> _dbContext?.Dispose();
    }
}

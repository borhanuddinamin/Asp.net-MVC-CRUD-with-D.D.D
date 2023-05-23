using CRUD.Domain.Entities;
using CRUD.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Persistance
{
    public abstract class Repository<TEntity, Tkey> : IRepository<TEntity, Tkey>
        where TEntity : class, IEntity<Tkey>
    {
        public readonly DbContext _dbContext;
        public readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();

        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual IList<TEntity> Getall()
        {
            return _dbSet.ToList();
        }

        public virtual void Remove(TEntity removeEntity)
        {
            if (_dbContext.Entry(removeEntity).State == EntityState.Detached)
            {
                _dbSet.Attach(removeEntity);
            }
            _dbSet.Remove(removeEntity);
        }

        public virtual void RemovebyId(Tkey id)
        {
            var DelectItems = _dbSet.Find(id);
            Remove(DelectItems);
        }

        public virtual void Update(TEntity updateEntity)
        {
            if (_dbContext.Entry(updateEntity).State == EntityState.Detached)
            {
                _dbSet.Attach(updateEntity);
            }

            _dbContext.Entry(updateEntity).State = EntityState.Modified;
        }
    }
}

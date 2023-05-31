using CRUD.Domain.Entities;
using CRUD.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Query;

namespace CRUD.Persistance
{
    public abstract class Repository<TEntity, Tkey> : IRepository<TEntity, Tkey>
        where TEntity : class, IEntity<Tkey>
    {
        protected  DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;
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


        public virtual (IList<TEntity> data, int total, int totalDisplay) GetDynamic
            (Expression<Func<TEntity, bool>> filter = null, string orderBy = null,
            Func<IQueryable<TEntity>,IIncludableQueryable<TEntity ,object>>include=null,
            int pageIndex = 1, int pageSize = 10, bool istrackingoff = false)
        {

            IQueryable<TEntity> query = _dbSet;
            var total = query.Count();
            var totalDisplay = query.Count();
            if (filter!= null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();

            }
            if (include != null)
            {
                query = include(query);
            }

            //foreach( var includeProperty in includeProperties.Split(new char
            //    [] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //{
            //    query = query.Include(includeProperty);
            //}
            if (orderBy != null)
            {
                var result = query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (istrackingoff)
                {
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                }
                else
                {
                    return (result.ToList(), total, totalDisplay);

                }

            }
            else
            {
                var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (istrackingoff)
                {
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                }
                else
                {
                    return (result.ToList(), total, totalDisplay);
                }
            
            
            }

        }

        public virtual  IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter
            = null, string orderBy = null, string includesProperties = "",
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool isTrackingOff = false)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if(include!=null)
            {
                query = include(query);
            }

            if(orderBy!= null)
            {
                var result = query.OrderBy(orderBy);
                if (isTrackingOff)
                {
                    return result.AsNoTracking().ToList();
                }
                else
                {
                    return result.ToList();
                }
            }
            else
            {
                if (isTrackingOff)
                {
                    return query.AsNoTracking().ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
        }
    }
}

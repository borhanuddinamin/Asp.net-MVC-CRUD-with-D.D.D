using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Repository
{
    public  interface IRepository<TEntity,Tkey>
        where TEntity :class, IEntity<Tkey>
    {

        void Add(TEntity entity);
        void Update(TEntity updateEntity);
        void Remove(TEntity removeEntity);
        void RemovebyId(Tkey id);
         IList<TEntity> Getall( );
        (IList<TEntity> data, int total, int totalDisplay) GetDynamic
            (Expression<Func<TEntity, bool>> filter = null, string orderBy = null,
            Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>include= null,
            int pageIndex = 1, int pageSize = 10, bool istrackingoff = false);

        IList<TEntity>GetDynamic(Expression<Func<TEntity,
            bool>> filter = null, string orderBy = null, string includesProperties = "",
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,object>>include=null,
            bool isTrackingOff = false);

    }
}

using CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}

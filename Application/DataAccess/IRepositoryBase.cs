using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess
{
    internal interface IRepositoryBase<TEntity> : IReadonlyRepositoryBase<TEntity>
        where TEntity : EntityBase, IEntity<TEntity>
    {
        public void Add(TEntity item);
        public void Remove(TEntity item);
    }
}

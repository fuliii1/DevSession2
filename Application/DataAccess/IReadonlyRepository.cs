using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess
{
    internal interface IReadonlyRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        public void Attach(TEntity item);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetAsync(long id);
    }
}
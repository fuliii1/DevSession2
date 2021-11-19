using Application.DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class ReadonlyManagerBase<TEntity> : IReadonlyManagerBase<TEntity>
        where TEntity : EntityBase
    {
        protected readonly IReadonlyRepositoryBase<TEntity> _repository;
        public ReadonlyManagerBase(IReadonlyRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
    }

    public interface IReadonlyManagerBase<TEntity>
    where TEntity : EntityBase
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
    }
}

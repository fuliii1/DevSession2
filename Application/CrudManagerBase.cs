using Application.DataAccess;
using Domain;
using Domain.Exceptions;

namespace Application
{
    internal class CrudManagerBase<TEntity> : ReadonlyManagerBase<TEntity>, ICrudManagerBase<TEntity>
        where TEntity : EntityBase, IEntity<TEntity>, new()
    {
        protected readonly IUnitOfWork _unitOfWork;
        public CrudManagerBase(IRepositoryBase<TEntity> repository, IUnitOfWork unitOfWork) : base(repository)
        {
            _unitOfWork = unitOfWork;
        }

        protected IRepositoryBase<TEntity> Repository { get => _repository as IRepositoryBase<TEntity>; }

        public virtual async Task<TEntity> AddAsync(TEntity item)
        {
            var newItem = new TEntity();
            newItem.Update(item);
            Repository.Add(newItem);
            await _unitOfWork.SaveChangesAsync();
            return newItem;
        }

        public async Task<TEntity> GetAsync(long id)
        {
            var item = await _repository.GetAsync(id);
            if (item == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }
            return item;
        }

        public virtual async Task RemoveAsync(long id)
        {
            var item = await GetAsync(id);
            Repository.Remove(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity item)
        {
            var existingItem = await GetAsync(item.Id);
            existingItem.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public interface ICrudManagerBase<TEntity> : IReadonlyManagerBase<TEntity>
    where TEntity : EntityBase, IEntity<TEntity>
    {
        public Task<TEntity> AddAsync(TEntity item);
        public Task UpdateAsync(TEntity item);
        public Task RemoveAsync(long id);
        public Task<TEntity> GetAsync(long id);
    }

}
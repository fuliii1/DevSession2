using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IEntity<TEntity>
    {
        public void Update(TEntity item)
        {
            var entityBase = item as IEntity<TEntity>;
            entityBase.Validate();
            Mapping(item);
        }

        protected void Mapping(TEntity item);

        public void Validate()
        {
            var validationErrors = new List<string>();

            ValidateModel(validationErrors);

            if (validationErrors.Any())
            {
                throw new ValidationException(GetType(), validationErrors);
            }
        }

        protected void ValidateModel(ICollection<string> validationErrors);
    }
}

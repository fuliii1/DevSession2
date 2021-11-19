using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class EntityBase 
    {
        protected long _id;
        public long Id { get => _id; protected set => _id = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class NetworkItemBase : EntityBase
    {
        private long _networkId;
        public long NetworkId { get => _networkId; private set => _networkId = value; }
    }
}

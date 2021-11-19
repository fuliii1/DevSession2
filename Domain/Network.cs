using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Network : EntityBase
    {
        private long _companyId;
        public long CompanyId { get => _companyId; }

        public long _networkServiceTypeId;
        public long NetworkServiceTypeId { get => _networkServiceTypeId; }
        private NetworkServiceType _networkServiceType;
        public NetworkServiceType NetworkServiceType { get => _networkServiceType; }

        private long _networkTypeId;
        public long NetworkTypeId { get => _networkTypeId; }
        private NetworkType _networkType;
        public NetworkType NetworkType { get => _networkType; }

        private readonly List<NetworkItemBase> _items = new List<NetworkItemBase>();
        public IEnumerable<NetworkItemBase> Items 
        { 
            get => _items;
            set
            {
                _items.Clear();
                _items.AddRange(value);
            }
        }

        public Network()
        {
        }

        public Network(long companyId, long networkServiceTypeId, long networkTypeId)
        {
            _companyId = companyId;
            _networkServiceTypeId = networkServiceTypeId;
            _networkTypeId = networkTypeId;
        }

        internal TNetworkItem AddItem<TNetworkItem>(TNetworkItem item)
            where TNetworkItem : NetworkItemBase, IEntity<TNetworkItem>, new()
        {
            var newItem = new TNetworkItem();
            newItem.Update(item);
            _items.Add(newItem);
            return newItem;
        }

        internal void UpdateItem<TNetworkItem>(TNetworkItem item)
            where TNetworkItem : NetworkItemBase, IEntity<TNetworkItem>
        {
            var existingItem = Items.FirstOrDefault(x => x.Id == item.Id);
            if (existingItem == null)
            {
                throw new EntityNotFoundException(typeof(TNetworkItem), item.Id);
            }

            var existingItemEntity = (IEntity<TNetworkItem>)existingItem;

            existingItemEntity.Update(item);
        }

        internal void RemoveItem<TNetworkItem>(TNetworkItem item)
            where TNetworkItem : NetworkItemBase
        {
            var existingItem = Items.FirstOrDefault(x => x.Id == item.Id);
            if (existingItem == null)
            {
                throw new EntityNotFoundException(typeof(TNetworkItem), item.Id);
            }

            _items.Remove(existingItem);
        }
    }
}

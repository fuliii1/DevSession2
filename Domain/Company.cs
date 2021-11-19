using Domain.Exceptions;

namespace Domain
{
    public class Company : EntityBase, IEntity<Company>
    {
        public const int NameMaxLength = 250;
        public const int TaxNumberMaxLength = 15;
        public const int CompanyRegisterNumberMaxLength = 30;
        public const int PrefixMaxLength = 5;

        private string _name;
        public string Name { get => _name; private set => _name = value; }

        private string _taxNumber;
        public string TaxNumber { get => _taxNumber; private set => _taxNumber = value; }

        private string _companyRegisterNumber;
        public string CompanyRegisterNumber { get => _companyRegisterNumber; private set => _companyRegisterNumber = value; }

        private long _nmhhId;
        public long NmhhId { get => _nmhhId; private set => _nmhhId = value; }

        private string _prefix;
        public string Prefix { get => _prefix; private set => _prefix = value; }

        private bool _isUniversalPostService;
        public bool IsUniversalPostService { get => _isUniversalPostService; private set => _isUniversalPostService = value; }

        private bool _isUniversalPostServiceSubstitution;
        public bool IsUniversalPostServiceSubstitution { get => _isUniversalPostServiceSubstitution; private set => _isUniversalPostServiceSubstitution = value; }

        private bool _isUniversalPostServiceNonSubstitution;
        public bool IsUniversalPostServiceNonSubstitution { get => _isUniversalPostServiceNonSubstitution; private set => _isUniversalPostServiceNonSubstitution = value; }

        private readonly List<Network> _networks = new List<Network>();
        public IEnumerable<Network> Networks
        {
            get => _networks;
            private set
            {
                _networks.Clear();
                _networks.AddRange(value);
            }
        }

        void IEntity<Company>.Mapping(Company item)
        {
            Name = item.Name;
            TaxNumber = item.TaxNumber;
            CompanyRegisterNumber = item.CompanyRegisterNumber;
            NmhhId = item.NmhhId;
            Prefix = item.Prefix;
            IsUniversalPostService = item.IsUniversalPostService;
            IsUniversalPostServiceSubstitution = item.IsUniversalPostServiceSubstitution;
            IsUniversalPostServiceNonSubstitution = item.IsUniversalPostServiceNonSubstitution;
        }

        void IEntity<Company>.ValidateModel(ICollection<string> validationErrors)
        {
            if (string.IsNullOrEmpty(Name) || Name.Length < 3)
            {
                validationErrors.Add("Name cannot be empty. The length cannot be less than 3 character.");
            }
            if (Name.Length > NameMaxLength)
            {
                validationErrors.Add($"The {Name} length cannot be greater than {NameMaxLength} character.");
            }
            if (NmhhId <= 0)
            {
                validationErrors.Add("NmhhId cannot be less than 0.");
            }
            if (!IsUniversalPostService && !IsUniversalPostServiceNonSubstitution && !IsUniversalPostServiceSubstitution)
            {
                validationErrors.Add("NmhhId cannot be less than 0.");
            }
        }

        public Network AddNetwork(long networkServiceTypeId, long networkTypeId)
        {
            var network = Networks.FirstOrDefault(item => item.NetworkServiceTypeId == networkServiceTypeId && item.NetworkTypeId == networkTypeId);
            if (network == null)
            {
                network = new Network(Id, networkServiceTypeId, networkTypeId);
                _networks.Add(network);
            }
            return network;
        }

        public void RemoveNetwork(long networkId)
        {
            var network = GetNetwork(networkId);
            _networks.Remove(network);
        }

        public TNetworkItem AddNetworkItem<TNetworkItem>(long networkId, TNetworkItem item)
            where TNetworkItem : NetworkItemBase, IEntity<TNetworkItem>, new()
        {
            var network = GetNetwork(networkId);
            return network.AddItem(item);
        }

        public void UpdateNetworkItem<TNetworkItem>(long networkId, TNetworkItem item)
            where TNetworkItem : NetworkItemBase, IEntity<TNetworkItem>
        {
            var network = GetNetwork(networkId);

            network.UpdateItem(item);
        }

        public void RemoveNetworkItem<TNetworkItem>(long networkId, TNetworkItem item)
            where TNetworkItem : NetworkItemBase, IEntity<TNetworkItem>
        {
            var network = GetNetwork(networkId);

            network.RemoveItem(item);
        }

        private Network GetNetwork(long networkId)
        {
            var result = Networks.FirstOrDefault(item => item.Id == networkId);
            if (result == null)
            {
                throw new EntityNotFoundException(typeof(Network), networkId);
            }

            return result;
        }
    }
}
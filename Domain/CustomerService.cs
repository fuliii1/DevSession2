using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CustomerService : NetworkItemBase, IEntity<CustomerService>
    {
        private string _phone;
        public string Phone { get => _phone; private set => _phone = value; }

        private string _web;
        public string Web { get => _web; private set => _web = value; }

        private string _email;
        public string Email { get => _email; private set => _email = value; }

        private bool _isBarrierFree;
        public bool IsBarrierFree { get => _isBarrierFree; private set => _isBarrierFree = value; }

        private bool _isCourier;
        public bool IsCourier { get => _isCourier; private set => _isCourier = value; }

        private bool _isExpress;
        public bool IsExpress { get => _isExpress; private set => _isExpress = value; }

        private bool _isEms;
        public bool IsEms { get => _isEms; private set => _isEms = value; }

        private bool _isOther;
        public bool IsOther { get => _isOther; private set => _isOther = value; }

        private string _xmlOutRef;
        public string XmlOutRef { get => _xmlOutRef; private set => _xmlOutRef = value; }

        void IEntity<CustomerService>.Mapping(CustomerService item)
        {
            Phone = item.Phone;
            Web = item.Web;
            Email = item.Email;
            IsBarrierFree = item.IsBarrierFree;
            IsCourier = item.IsCourier;
            IsExpress = item.IsExpress;
            IsEms = item.IsEms;
            IsOther = item.IsOther;
        }

        void IEntity<CustomerService>.ValidateModel(ICollection<string> validationErrors)
        {
        }
    }
}



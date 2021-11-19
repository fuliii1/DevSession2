using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Post
{
    public class ProcessingPoint : NetworkItemBase, IEntity<ProcessingPoint>
    {
        private string _xmlOutRef;
        public string XmlOutRef { get => _xmlOutRef; private set => _xmlOutRef = value; }

        void IEntity<ProcessingPoint>.Mapping(ProcessingPoint item)
        {
        }

        void IEntity<ProcessingPoint>.ValidateModel(ICollection<string> validationErrors)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    [Serializable]
    public sealed class ValidationException : Exception
    {
        public ValidationException(Type type, IEnumerable<string> validationMessages) : base($"{type.Name} has validation error(s): {string.Join(Environment.NewLine, validationMessages)}")
        {
        }

        private ValidationException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}

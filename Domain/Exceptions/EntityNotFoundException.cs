using System;

namespace Domain.Exceptions
{
    [Serializable]
    public sealed class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(Type type, long id) : base($"{type.Name} has not found with id: {id}")
        {
        }

        public EntityNotFoundException(string type, long id) : base($"{type} has not found with id: {id}")
        {
        }

        private EntityNotFoundException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}
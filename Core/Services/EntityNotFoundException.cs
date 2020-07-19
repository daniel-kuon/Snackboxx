using System;

namespace Core.Services
{
    public class EntityNotFoundException<T>: Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(Guid? id)
        {
            Id = id?.ToString();
        }

        public EntityNotFoundException(string id)
        {
            Id = id;
        }

        public string EntityName => typeof(T).Name;
        public string? Id { get; set; }
    }
}
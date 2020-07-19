using System;

namespace Core.DatabaseModel
{
    public interface IUpdateableEntity : IEntity
    {
        DateTime LastUpdatedAt { get; set; }
    }
}
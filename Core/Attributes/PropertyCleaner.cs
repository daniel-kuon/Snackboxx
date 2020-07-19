using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.DatabaseModel;

namespace Core.Attributes
{
    public class PropertyCleaner
    {
        private readonly List<IEntity> _scannedEntities=new List<IEntity>();

        public void CleanProperties(IEntity entity)
        {
            if (entity == null)
                return;
            if (_scannedEntities.Contains(entity))
                return;
            _scannedEntities.Add(entity);
            (entity as ISensitiveDataEntity)?.CleanSensitiveData();
            foreach (var property in entity.GetType().GetProperties())
            {
                var value = property.GetValue(entity);
                if (value == null)
                    continue;
                if(property.GetCustomAttributes<NonPublicDataAttribute>().Any())
                    property.SetValue(entity,null);
                else if (value is IEntity iEntity)
                    CleanProperties(entity);
                else if (value is IEnumerable enumerable)
                    CleanProperties(enumerable.OfType<IEntity>());
            }
        }

        private void CleanProperties(IEnumerable<IEntity> entities)
        {
            foreach (var entity in entities)
            {
                CleanProperties(entity);
            }
        }
    }
}
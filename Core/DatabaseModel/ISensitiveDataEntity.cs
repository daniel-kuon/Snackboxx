namespace Core.DatabaseModel
{
    public interface ISensitiveDataEntity : IEntity
    {
        void CleanSensitiveData();
    }
}
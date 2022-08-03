namespace PizzaApi.Services.Implementations
{
    public interface IMetadataService
    {
        Task SaveMetadata<T>(T obj);
    }
}

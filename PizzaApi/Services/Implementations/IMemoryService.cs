using PizzaApi.Models;

namespace PizzaApi.Services.Implementations
{
    public interface IMemoryService
    {
        Task SaveDeletedPizza(Pizza pizza);
        Task SaveObject<T>(T obj);
    }
}

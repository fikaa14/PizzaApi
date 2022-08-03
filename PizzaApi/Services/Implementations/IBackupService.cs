using PizzaApi.Models;

namespace PizzaApi.Services.Implementations
{
    public interface IBackupService
    {
        Task SaveDeletedPizza(Pizza pizza);
        Task SaveObject<T>(T obj); 
    }

    
}

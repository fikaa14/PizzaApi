using PizzaApi.Models;

namespace PizzaApi.Services.Implementations
{
    public interface IPizzaService
    {
        Task<List<Pizza>> GetAsync();
        Task<Pizza> GetByIdAsync(string id);
        Task CreateAsync(Pizza pizza);
        Task RemoveAsync(string id);
    }
}

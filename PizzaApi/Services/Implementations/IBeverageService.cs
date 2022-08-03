using PizzaApi.Models;

namespace PizzaApi.Services.Implementations
{
    public interface IBeverageService
    {

        Task CreateBeverage(Beverage beverage);
        Task<List<Beverage>> GetAsync();

    }
}

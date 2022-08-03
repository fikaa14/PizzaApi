using PizzaApi.Models;
using PizzaApi.Services.Implementations;

namespace PizzaApi.Services
{
    public class MemoryPizzaService: IMemoryService
    {
        private readonly IBackupService _backupService;
        public MemoryPizzaService(IBackupService backupService)
        {
            _backupService = backupService;
        }
        
        public async Task SaveDeletedPizza(Pizza pizza)
        {
            await _backupService.SaveDeletedPizza(pizza);
        }

        public async Task SaveObject<T>(T obj)
        {
            await _backupService.SaveObject<T>(obj);
        }
    }
}

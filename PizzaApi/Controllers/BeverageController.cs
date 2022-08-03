using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using PizzaApi.Services.Implementations;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("api/beverage")]
    public class BeverageController: ControllerBase
    {
        private readonly IBeverageService _beverageService;
        private readonly IBackupService _backupService;
        private readonly IMetadataService _metadataService;

        public BeverageController(IBeverageService beverageService, IBackupService backupService, IMetadataService metadataService)
        {
            _beverageService = beverageService;
            _backupService = backupService;
            _metadataService = metadataService;
        }

        [HttpGet]
        public async Task<List<Beverage>> Get() =>
            await _beverageService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(Beverage beverage)
        {
            if(beverage is null)
            {
                return BadRequest();
            }

            await _beverageService.CreateBeverage(beverage);
            await _backupService.SaveObject(beverage);
            await _metadataService.SaveMetadata(beverage);

            return CreatedAtAction(nameof(Get), new { id = beverage.Id }, beverage);
        }
    }
}

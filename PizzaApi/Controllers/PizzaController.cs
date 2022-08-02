using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using PizzaApi.Services.Implementations;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("api/pizza")]
    public class PizzaController: ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<List<Pizza>> Get() =>
            await _pizzaService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<Pizza> GetById(string id) =>
            await _pizzaService.GetByIdAsync(id);

        [HttpPost]
        public async Task<IActionResult> Post(Pizza pizza)
        {
            await _pizzaService.CreateAsync(pizza);

            return CreatedAtAction(nameof(Get), new { id = pizza._id }, pizza);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var pizza = await _pizzaService.GetByIdAsync(id);

            if(pizza is null)
            {
                return NotFound();
            }

            await _pizzaService.RemoveAsync(id);

            return NoContent();

        }
    }
}

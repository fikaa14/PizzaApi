using AutoMapper;
using PizzaApi.Models;
using PizzaApi.Services.Implementations;
using System.Text.Json;

namespace PizzaApi.Services
{
    public class MetadataService : IMetadataService
    {
        private readonly IMapper _mapper;
        private readonly IMapPizza _mapPizza;
        private readonly IMapBeverage _mapBeverage;

        public MetadataService(IMapper mapper, IMapPizza mapPizza, IMapBeverage mapBeverage)
        { 
            _mapper = mapper;
            _mapPizza = mapPizza;
            _mapBeverage = mapBeverage;
        }

        public async Task SaveMetadata<T>(T obj)
        {
        
            if (typeof(T).Equals(typeof(Pizza)) )
            {
                Metadata newMetadata = _mapper.Map<Metadata>(obj);
                await File.AppendAllTextAsync("Metadata.txt", $"Pizza: {JsonSerializer.Serialize(newMetadata)}\r\n"); 
            } 
            else if(typeof(T).Equals(typeof(Beverage)))
            {
                Metadata newMetadata = _mapper.Map<Metadata>(obj);
                await File.AppendAllTextAsync("Metadata.txt", $"Beverage: {JsonSerializer.Serialize(newMetadata)}\r\n");
            }    

        }
    }
}

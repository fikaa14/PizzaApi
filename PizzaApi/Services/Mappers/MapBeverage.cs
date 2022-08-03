using AutoMapper;
using PizzaApi.Models;
using PizzaApi.Services.Implementations;

namespace PizzaApi.Services.Mappers
{
    public class MapBeverage: Profile, IMapBeverage
    {
        public MapBeverage()
        {
            CreateMap<Beverage, Metadata>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => "Beverage"))
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.Date,
                    opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}

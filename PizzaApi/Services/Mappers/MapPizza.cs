using AutoMapper;
using PizzaApi.Models;
using PizzaApi.Services.Implementations;

namespace PizzaApi.Services.Mappers
{
    public class MapPizza : Profile, IMapPizza
    {
        public MapPizza()
        {
            CreateMap<Pizza, Metadata>()
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => "Pizza"))
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest =>
                    dest.Date,
                    opt => opt.MapFrom(src => DateTime.Now)); 
        }

    }
}

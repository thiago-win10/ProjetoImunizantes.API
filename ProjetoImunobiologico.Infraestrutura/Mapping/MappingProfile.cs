using AutoMapper;
using ProjetoImunobiologico.Entidades.Models;
using ProjetoImunobiologico.Entidades.ViewModels;
using ProjetoImunobiologico.Entidades.Enum;
namespace ProjetoImunobiologico.Infraestrutura.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Imunizante, ImunizanteViewModel>()
             .ForMember(dest => dest.Fabricante, map =>
             map.MapFrom(src => src.Fabricante == TipoImunizante.PFIZER ? "PFIZER" : "SINOVAC"))
             .ReverseMap();
        }
    }
}
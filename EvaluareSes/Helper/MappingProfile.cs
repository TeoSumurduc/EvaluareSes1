using AutoMapper;
using EvaluareSes.Dto;
using EvaluareSes.Models;

namespace EvaluareSes.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Autori, AutoriDto>();
            CreateMap<Carti, CartiDto>();
            CreateMap<Editura, EdituraDto>();
        }
    }
}

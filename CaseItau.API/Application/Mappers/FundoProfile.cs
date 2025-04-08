using AutoMapper;
using CaseItau.API.Application.Services.Model;
using CaseItau.API.Entities;

namespace CaseItau.API.Application.Mappers
{
    public class FundoProfile : Profile
    {
        public FundoProfile() 
        {
            CreateMap<FundoModel, FundoEntity>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForMember(dest => dest.Patrimonio, opt => opt.MapFrom(src => src.Patrimonio))
                .ReverseMap();
        }           
    }
}

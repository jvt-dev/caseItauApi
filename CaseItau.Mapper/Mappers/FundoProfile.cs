using AutoMapper;
using CaseItau.API.Domain.Entities;
using CaseItau.API.Shared.Dtos;
using CaseItau.API.Shared.Models;

namespace CaseItau.API.Mapper.Mappers
{
    public class FundoProfile : Profile
    {
        public FundoProfile()
        {
            CreateMap<FundoModel, FundoDto>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForMember(dest => dest.Patrimonio, opt => opt.MapFrom(src => src.Patrimonio))
                .ForPath(dest => dest.CodigoTipo, opt => opt.MapFrom(src => src.CodigoTipo))
                .ReverseMap();

            CreateMap<FundoDto, FundoEntity>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForMember(dest => dest.Patrimonio, opt => opt.MapFrom(src => src.Patrimonio))
                .ForMember(dest => dest.CodigoTipo, opt => opt.MapFrom(src => src.CodigoTipo))
                .ReverseMap();
        }
    }
}

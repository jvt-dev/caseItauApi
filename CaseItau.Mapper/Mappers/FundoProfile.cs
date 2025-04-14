using AutoMapper;
using CaseItau.API.Domain.Entities;
using CaseItau.API.Shared.Dtos;
using CaseItau.API.Shared.Models;
using CaseItau.Shared.Dtos;
using CaseItau.Shared.Models;

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
                .ForMember(dest => dest.CodigoTipo, opt => opt.MapFrom(src => src.CodigoTipo))
                .ForPath(dest => dest.TipoFundo.Codigo, opt => opt.MapFrom(src => src.CodigoTipo))
                .ForPath(dest => dest.TipoFundo.Nome, opt => opt.MapFrom(src => src.NomeTipo))
                .ReverseMap();

            CreateMap<FundoDto, FundoEntity>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForMember(dest => dest.Patrimonio, opt => opt.MapFrom(src => src.Patrimonio))
                .ForMember(dest => dest.CodigoTipo, opt => opt.MapFrom(src => src.CodigoTipo))
                .ForMember(dest => dest.TipoFundo, opt => opt.MapFrom(src => new TipoFundoDto
                {
                    Codigo = src.TipoFundo.Codigo,
                    Nome = src.TipoFundo.Nome
                }))
                .ReverseMap();

            CreateMap<TipoFundoEntity, TipoFundoDto>()
                 .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                 .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                 .ReverseMap();

            CreateMap<TipoFundoModel, TipoFundoDto>()
                 .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                 .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                 .ReverseMap();
        }
    }
}

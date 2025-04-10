using AutoMapper;
using CaseItau.API.Domain.Entities;
using CaseItau.API.Infrastructure.Repositories;
using CaseItau.API.Shared.Dtos;
using CaseItau.Application.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.Application.Services
{
    public class FundoService : IFundoService
    {
        private readonly IFundoRepository _fundoRepository;
        private readonly IMapper _mapper;

        public FundoService(IFundoRepository fundoRepository, IMapper mapper)
        {
            _fundoRepository = fundoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FundoDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<FundoDto>>(await _fundoRepository.GetAll());
        }

        public async Task<FundoDto> GetAsync(string codigo)
        {
            FundoDto fundoEntity = _mapper.Map<FundoDto>(await _fundoRepository.GetEntityById(codigo));

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            return fundoEntity;
        }

        public async Task PostAsync(FundoDto dto)
        {
            FundoEntity fundoEntity = _mapper.Map<FundoEntity>(dto);

            await _fundoRepository.CreateAsync(fundoEntity);
        }

        public async Task PutAsync(string codigo, FundoDto dto)
        {
            FundoEntity fundoEntity = await _fundoRepository.GetEntityById(codigo);

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            fundoEntity.UpdateNome(dto.Nome);
            fundoEntity.UpdateCnpj(dto.Cnpj);
            fundoEntity.UpdateCodigoTipo(dto.CodigoTipo);

            await _fundoRepository.UpdateAsync(fundoEntity);
        }

        public async Task DeleteAsync(string codigo)
        {
            FundoEntity fundoEntity = await _fundoRepository.GetEntityById(codigo);

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            await _fundoRepository.DeleteAsync(fundoEntity);
        }

        public async Task MovimentarPatrimonioAsync(string codigo, decimal valorPatrimonio)
        {
            FundoEntity fundoEntity = await _fundoRepository.GetEntityById(codigo);

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            fundoEntity.UpdatePatrimonio(valorPatrimonio);

            await _fundoRepository.UpdateAsync(fundoEntity);
        }
    }
}

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
            return _mapper.Map<IEnumerable<FundoDto>>(await _fundoRepository.GetAllAsync());
        }

        public async Task<FundoDto> GetByIdAsync(string codigo)
        {
            FundoDto fundoEntity = _mapper.Map<FundoDto>(await _fundoRepository.GetEntityByIdAsync(codigo));

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            return fundoEntity;
        }

        public async Task<bool> PostAsync(FundoDto dto)
        {
            FundoEntity fundoEntity = _mapper.Map<FundoEntity>(dto);

            return await _fundoRepository.CreateAsync(fundoEntity) > 0;
        }

        public async Task<bool> PutAsync(string codigo, FundoDto dto)
        {
            FundoEntity fundoEntity = await _fundoRepository.GetEntityByIdAsync(codigo);

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            fundoEntity.UpdateNome(dto.Nome);
            fundoEntity.UpdateCnpj(dto.Cnpj);
            fundoEntity.UpdateCodigoTipo(dto.CodigoTipo);

            return await _fundoRepository.UpdateAsync(fundoEntity) > 0;
        }

        public async Task<bool> DeleteAsync(string codigo)
        {
            FundoEntity fundoEntity = await _fundoRepository.GetEntityByIdAsync(codigo);

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            return await _fundoRepository.DeleteAsync(fundoEntity) > 0;
        }

        public async Task<bool> MovimentarPatrimonioAsync(string codigo, decimal valorPatrimonio)
        {
            FundoEntity fundoEntity = await _fundoRepository.GetEntityByIdAsync(codigo);

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            fundoEntity.UpdatePatrimonio(valorPatrimonio);

            return await _fundoRepository.UpdateAsync(fundoEntity) > 0;
        }
    }
}

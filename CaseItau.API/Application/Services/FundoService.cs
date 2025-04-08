using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CaseItau.API.Application.Exceptions;
using CaseItau.API.Application.Repositories;
using CaseItau.API.Application.Services.Model;
using CaseItau.API.Entities;

namespace CaseItau.API.Application.Services
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

        public async Task<IEnumerable<FundoModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<FundoModel>>(await _fundoRepository.GetAll());
        }

        public async Task<FundoModel> GetAsync(string codigo)
        {
            return _mapper.Map<FundoModel>(await _fundoRepository.GetEntityById(codigo));
        }

        public async Task PostAsync(FundoModel model)
        {
            var fundoEntity = _mapper.Map<FundoEntity>(model);

            await _fundoRepository.PostAsync(fundoEntity);
        }

        public async Task PutAsync(FundoModel model)
        {
            var fundoEntity = await _fundoRepository.GetEntityById(model.Codigo);

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            await _fundoRepository.PutAsync(fundoEntity);
        }

        public async Task DeleteAsync(string codigo)
        { 
            var fundoEntity = await _fundoRepository.GetEntityById(codigo);

            if (fundoEntity is null)
            {
                throw new NotFoundException("Fundo não encontrado!");
            }

            await _fundoRepository.DeleteAsync(fundoEntity);
        }
    }
}

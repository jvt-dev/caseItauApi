using AutoMapper;
using CaseItau.Infrastructure.Repositories;
using CaseItau.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.Application.Services
{
    public class TipoFundoService : ITipoFundoService
    {
        private readonly ITipoFundoRepository _tipoFundoRepository;
        private readonly IMapper _mapper;

        public TipoFundoService(ITipoFundoRepository tipoFundoRepository, IMapper mapper)
        {
            _tipoFundoRepository = tipoFundoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoFundoDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TipoFundoDto>>(await _tipoFundoRepository.GetAllAsync());
        }
    }
}

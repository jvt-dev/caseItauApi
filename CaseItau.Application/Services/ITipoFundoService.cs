using CaseItau.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseItau.Application.Services
{
    public interface ITipoFundoService
    {
        Task<IEnumerable<TipoFundoDto>> GetAllAsync();
    }
}
